using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AssetScanner.Config;
using AssetScanner.Models;
using AssetScanner.Utils;

namespace AssetScanner.Analysis.Dll;

/// <summary>
/// Analyses PE/DLL binaries for suspicious characteristics.
/// </summary>
public static class DllAnalyzer
{
    public static List<Finding> Analyze(byte[] data, string location)
    {
        var findings = new List<Finding>();

        var pe = new PeParser(data);
        if (!pe.IsValid)
        {
            findings.Add(new Finding(
                FindingId.PeInvalidHeader,
                Severity.Low,
                ScannerConfig.PtsPeInvalidHeader,
                location,
                "PE file does not start with valid MZ header"));
            return findings;
        }

        // Section analysis
        foreach (var section in pe.Sections)
        {
            var secData = ExtractSectionData(data, section);
            var entropy = PeParser.ComputeEntropy(secData);

            // High entropy
            if (entropy >= ScannerConfig.EntropyPeHigh)
            {
                findings.Add(new Finding(
                    FindingId.PeHighEntropySection,
                    Severity.High,
                    ScannerConfig.PtsPeHighEntropyHigh,
                    location,
                    $"PE section '{section.Name}' has very high entropy ({entropy:F2}) 鈥?possible packing/encryption"));
            }
            else if (entropy >= ScannerConfig.EntropyPeSuspicious)
            {
                findings.Add(new Finding(
                    FindingId.PeHighEntropySection,
                    Severity.Medium,
                    ScannerConfig.PtsPeHighEntropyMedium,
                    location,
                    $"PE section '{section.Name}' has elevated entropy ({entropy:F2})"));
            }

            // W+X section
            if (section.IsWritable && section.IsExecutable)
            {
                findings.Add(new Finding(
                    FindingId.PeWriteExecuteSection,
                    Severity.High,
                    ScannerConfig.PtsPeWriteExecuteSection,
                    location,
                    $"PE section '{section.Name}' is both writable and executable"));
            }

            // Unnamed section
            if (string.IsNullOrEmpty(section.Name) || section.Name == "\0\0\0\0\0\0\0\0")
            {
                findings.Add(new Finding(
                    FindingId.PeUnnamedSection,
                    Severity.Medium,
                    ScannerConfig.PtsPeUnnamedSection,
                    location,
                    "PE section has no name"));
            }

            // Inflated section
            if (section.RawSize > 0 && section.VirtualSize > section.RawSize * ScannerConfig.PeInflatedRatio)
            {
                findings.Add(new Finding(
                    FindingId.PeInflatedSection,
                    Severity.Medium,
                    ScannerConfig.PtsPeInflatedSection,
                    location,
                    $"PE section '{section.Name}' is inflated (virtual {section.VirtualSize} > raw {section.RawSize})"));
            }
        }

        // Import table analysis
        var importFindings = AnalyzeImports(pe.Imports, location);
        findings.AddRange(importFindings);

        // String extraction analysis
        var stringFindings = AnalyzeStrings(data, location);
        findings.AddRange(stringFindings);

        return findings;
    }

    private static byte[] ExtractSectionData(byte[] data, PeSection section)
    {
        if (section.RawAddress + section.RawSize > data.Length)
            return Array.Empty<byte>();

        var result = new byte[section.RawSize];
        Buffer.BlockCopy(data, (int)section.RawAddress, result, 0, (int)section.RawSize);
        return result;
    }

    private static List<Finding> AnalyzeImports(List<ImportDescriptor> imports, string location)
    {
        var findings = new List<Finding>();
        var dllNames = imports.Select(i => i.DllName.ToLowerInvariant()).ToList();

        var dangerous = new Dictionary<string, (FindingId id, uint points, Severity sev, string msg)>(StringComparer.OrdinalIgnoreCase)
        {
            ["kernel32"] = (FindingId.DllImportCreateprocess, ScannerConfig.PtsDllImportCreateprocess, Severity.Critical,
                "Import from kernel32.dll 鈥?possible process creation (CreateProcess/WinExec/etc.)"),
            ["shell32"] = (FindingId.DllImportCreateprocess, ScannerConfig.PtsDllImportCreateprocess, Severity.Critical,
                "Import from shell32.dll 鈥?possible ShellExecute usage"),
            ["ntdll"] = (FindingId.DllImportCreateremotethread, ScannerConfig.PtsDllImportCreateremotethread, Severity.High,
                "Import from ntdll.dll 鈥?possible low-level process/thread manipulation"),
            ["ws2_32"] = (FindingId.DllImportSockets, ScannerConfig.PtsDllImportSockets, Severity.High,
                "Import from ws2_32.dll 鈥?raw socket networking"),
            ["wininet"] = (FindingId.DllImportInternet, ScannerConfig.PtsDllImportInternet, Severity.Medium,
                "Import from wininet.dll 鈥?WinInet HTTP operations"),
            ["winhttp"] = (FindingId.DllImportInternet, ScannerConfig.PtsDllImportInternet, Severity.Medium,
                "Import from winhttp.dll 鈥?WinHTTP operations"),
        };

        foreach (var dllName in dllNames)
        {
            foreach (var (key, value) in dangerous)
            {
                if (dllName.Contains(key))
                {
                    findings.Add(new Finding(
                        value.id,
                        value.sev,
                        value.points,
                        location,
                        value.msg)
                        .WithContext($"DLL: {dllName}"));
                }
            }
        }

        return findings;
    }

    private static List<Finding> AnalyzeStrings(byte[] data, string location)
    {
        var findings = new List<Finding>();
        var strings = ExtractStrings(data, ScannerConfig.DllMinStringLen);

        foreach (var str in strings)
        {
            // Suspicious system paths
            if (Patterns.SystemPath.IsMatch(str))
            {
                findings.Add(new Finding(
                    FindingId.DllStringsSuspiciousPath,
                    Severity.Low,
                    ScannerConfig.PtsDllStringsSuspiciousPath,
                    location,
                    "Suspicious system path found in DLL strings")
                    .WithContext($"String: {str}"));
            }

            // URLs
            foreach (Match m in Patterns.UrlPattern.Matches(str))
            {
                var url = m.Value;
                if (!Patterns.IsSafeDomain(url))
                {
                    findings.Add(new Finding(
                        FindingId.DllUrlUnknownDomain,
                        Severity.High,
                        ScannerConfig.PtsDllUrlUnknownDomain,
                        location,
                        "URL to unknown domain found in DLL strings")
                        .WithContext($"URL: {url}"));
                }
            }

            // IPs
            foreach (Match m in Patterns.IpPattern.Matches(str))
            {
                findings.Add(new Finding(
                    FindingId.DllIpHardcoded,
                    Severity.High,
                    ScannerConfig.PtsDllIpHardcoded,
                    location,
                    "Hardcoded IP address found in DLL strings")
                    .WithContext($"IP: {m.Value}"));
            }
        }

        return findings;
    }

    private static List<string> ExtractStrings(byte[] data, int minLength)
    {
        var strings = new List<string>();
        var sb = new System.Text.StringBuilder();

        foreach (var b in data)
        {
            if (b >= 32 && b < 127)
            {
                sb.Append((char)b);
            }
            else
            {
                if (sb.Length >= minLength)
                    strings.Add(sb.ToString());
                sb.Clear();
            }
        }
        if (sb.Length >= minLength)
            strings.Add(sb.ToString());

        return strings;
    }
}

