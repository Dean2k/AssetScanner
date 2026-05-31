using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AssetScanner.Config;
using AssetScanner.Models;
using AssetScanner.Utils;

namespace AssetScanner.Analysis.Scripts;

/// <summary>
/// Analyses C# source code for dangerous API patterns and suspicious constructs.
/// </summary>
public static class ScriptAnalyzer
{
    /// <summary>
    /// Scan C# source code for dangerous API patterns.
    /// </summary>
    public static List<Finding> Analyze(string source, string location)
    {
        var findings = new List<Finding>();

        // CRITICAL 鈥?Process execution
        if (Patterns.CsProcessStart.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsProcessStart,
                Severity.Critical,
                ScannerConfig.PtsCsProcessStart,
                location,
                "Process.Start() detected in C# script 鈥?executes arbitrary process")
                .WithLineNumbers(MatchingLines(Patterns.CsProcessStart, source)));
        }

        // CRITICAL 鈥?Assembly loading
        if (Patterns.CsAssemblyLoad.IsMatch(source))
        {
            var points = source.Contains("Assembly.Load(") && source.Contains("byte")
                ? ScannerConfig.PtsCsAssemblyLoadBytes
                : ScannerConfig.PtsCsAssemblyLoadFile;

            findings.Add(new Finding(
                FindingId.CsAssemblyLoadBytes,
                Severity.Critical,
                points,
                location,
                "Assembly.Load/LoadFile detected in C# script (dynamic assembly loading)")
                .WithLineNumbers(MatchingLines(Patterns.CsAssemblyLoad, source)));
        }

        // MEDIUM 鈥?Reflection.Emit
        if (Patterns.CsReflectionEmit.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsReflectionEmit,
                Severity.Medium,
                ScannerConfig.PtsCsReflectionEmit,
                location,
                "System.Reflection.Emit detected (runtime code generation)")
                .WithLineNumbers(MatchingLines(Patterns.CsReflectionEmit, source)));
        }

        // MEDIUM 鈥?HTTP/WebClient
        if (Patterns.CsWebclient.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsHttpClient,
                Severity.Medium,
                ScannerConfig.PtsCsHttpClient,
                location,
                "HTTP client (WebClient/HttpClient/UnityWebRequest) detected in C# script")
                .WithLineNumbers(MatchingLines(Patterns.CsWebclient, source)));
        }

        // HIGH 鈥?File system writes
        if (Patterns.CsFileWrite.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsFileWrite,
                Severity.High,
                ScannerConfig.PtsCsFileWrite,
                location,
                "File write/delete operations detected in C# script")
                .WithLineNumbers(MatchingLines(Patterns.CsFileWrite, source)));
        }

        // HIGH 鈥?BinaryFormatter
        if (Patterns.CsBinaryFormatter.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsBinaryFormatter,
                Severity.High,
                ScannerConfig.PtsCsBinaryFormatter,
                location,
                "BinaryFormatter detected (insecure deserialization 鈥?arbitrary object execution)")
                .WithLineNumbers(MatchingLines(Patterns.CsBinaryFormatter, source)));
        }

        // MEDIUM/HIGH 鈥?DllImport / P/Invoke
        foreach (Match cap in Patterns.CsDllimport.Matches(source))
        {
            var dllName = cap.Groups.Count > 1 ? cap.Groups[1].Value : "?";
            var knownDlls = new[] { "kernel32", "user32", "advapi32", "ntdll", "ws2_32", "shell32" };
            var isKnown = knownDlls.Any(k => dllName.Contains(k, StringComparison.OrdinalIgnoreCase));
            var points = isKnown ? ScannerConfig.PtsCsDllimportKnown : ScannerConfig.PtsCsDllimportUnknown;
            var severity = isKnown ? Severity.Medium : Severity.High;

            findings.Add(new Finding(
                FindingId.CsDllimportUnknown,
                severity,
                points,
                location,
                "P/Invoke ([DllImport]) detected in C# script")
                .WithContext($"DLL: {dllName}"));
        }

        // MEDIUM 鈥?Unsafe block
        if (Patterns.CsUnsafe.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsUnsafeBlock,
                Severity.Medium,
                ScannerConfig.PtsCsUnsafeBlock,
                location,
                "Unsafe block detected in C# script")
                .WithLineNumbers(MatchingLines(Patterns.CsUnsafe, source)));
        }

        // MEDIUM 鈥?Registry access
        if (Patterns.CsRegistry.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsRegistryAccess,
                Severity.Medium,
                ScannerConfig.PtsCsRegistryAccess,
                location,
                "Windows Registry access detected in C# script")
                .WithLineNumbers(MatchingLines(Patterns.CsRegistry, source)));
        }

        // MEDIUM 鈥?Environment variables / machine identity
        if (Patterns.CsEnvironment.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsEnvironmentAccess,
                Severity.Medium,
                ScannerConfig.PtsCsEnvironmentAccess,
                location,
                "System environment variable or machine identity access in C# script")
                .WithLineNumbers(MatchingLines(Patterns.CsEnvironment, source)));
        }

        // MEDIUM 鈥?Marshal
        if (Patterns.CsMarshal.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsMarshalOps,
                Severity.Medium,
                ScannerConfig.PtsCsMarshalOps,
                location,
                "Marshal operations (unsafe memory access) detected in C# script")
                .WithLineNumbers(MatchingLines(Patterns.CsMarshal, source)));
        }

        // Shell commands (in string literals)
        if (Patterns.ShellCmd.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsShellStrings,
                Severity.High,
                ScannerConfig.PtsCsShellStrings,
                location,
                "Shell command strings found in C# script")
                .WithLineNumbers(MatchingLines(Patterns.ShellCmd, source)));
        }

        // URLs to unknown domains
        var urlFindings = AnalyzeUrls(source, location);
        findings.AddRange(urlFindings);

        // Unicode escapes
        if (Patterns.CsUnicodeEscape.IsMatch(source))
        {
            findings.Add(new Finding(
                FindingId.CsUnicodeEscapes,
                Severity.Medium,
                ScannerConfig.PtsCsUnicodeEscapes,
                location,
                "Unicode escape sequences detected in C# script (possible obfuscation)")
                .WithLineNumbers(MatchingLines(Patterns.CsUnicodeEscape, source)));
        }

        // Obfuscation checks
        var obfFindings = ObfuscationAnalyzer.Analyze(source, location);
        findings.AddRange(obfFindings);

        return findings;
    }

    private static List<uint> MatchingLines(Regex pattern, string source)
    {
        var lines = new List<uint>();
        var allLines = source.Split(['\n', '\r'], StringSplitOptions.None);
        for (uint i = 0; i < allLines.Length; i++)
        {
            if (pattern.IsMatch(allLines[i]))
                lines.Add(i + 1);
        }
        return lines;
    }

    private static List<Finding> AnalyzeUrls(string source, string location)
    {
        var findings = new List<Finding>();
        var urls = new HashSet<string>();

        foreach (Match m in Patterns.UrlPattern.Matches(source))
        {
            var url = m.Value.TrimEnd('\'', '\"', ')', ';');
            if (urls.Add(url) && !Patterns.IsSafeDomain(url))
            {
                findings.Add(new Finding(
                    FindingId.CsUrlUnknownDomain,
                    Severity.High,
                    ScannerConfig.PtsCsUrlUnknownDomain,
                    location,
                    "URL pointing to unknown domain detected in C# script")
                    .WithContext($"URL: {url}"));
            }
        }

        foreach (Match m in Patterns.IpPattern.Matches(source))
        {
            var ip = m.Value;
            if (urls.Add(ip))
            {
                findings.Add(new Finding(
                    FindingId.CsIpHardcoded,
                    Severity.High,
                    ScannerConfig.PtsCsIpHardcoded,
                    location,
                    "Hardcoded IP address detected in C# script")
                    .WithContext($"IP: {ip}"));
            }
        }

        return findings;
    }
}

