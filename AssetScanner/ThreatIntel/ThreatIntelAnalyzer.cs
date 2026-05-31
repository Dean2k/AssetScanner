using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AssetScanner.Config;
using AssetScanner.Models;
using AssetScanner.Utils;

namespace AssetScanner.ThreatIntel;

/// <summary>
/// Cross-references scan findings and file contents against offline threat intel databases.
/// </summary>
public sealed class ThreatIntelAnalyzer
{
    private readonly ThreatDatabase _db;

    public ThreatIntelAnalyzer(ThreatDatabase db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
        if (!_db.IsLoaded) _db.Load();
    }

    /// <summary>
    /// Check file hashes and network indicators in the package against threat intel.
    /// </summary>
    public List<Finding> Analyze(PackageTree tree)
    {
        var findings = new List<Finding>();
        var entries = tree.AllEntries.ToList();

        // 1. Check SHA-256 of every entry against MalwareBazaar
        foreach (var entry in entries)
        {
            var hash = ComputeSha256(entry.Data);
            if (_db.IsKnownMalware(hash))
            {
                findings.Add(new Finding(
                    FindingId.ThreatIntelKnownMalwareHash,
                    Severity.Critical,
                    ScannerConfig.PtsThreatIntelKnownMalwareHash,
                    entry.Path,
                    "SHA-256 matches known malware in MalwareBazaar database")
                    .WithContext($"Hash: {hash}"));
            }
        }

        // 2. Check URLs in script text against URLhaus
        foreach (var entry in entries.Where(e => e.Text is not null))
        {
            var urlFindings = CheckUrls(entry.Text!, entry.Path);
            findings.AddRange(urlFindings);

            var ipFindings = CheckIps(entry.Text!, entry.Path);
            findings.AddRange(ipFindings);
        }

        return findings;
    }

    private List<Finding> CheckUrls(string text, string location)
    {
        var findings = new List<Finding>();
        var matches = Patterns.UrlPattern.Matches(text);

        foreach (Match m in matches)
        {
            var url = m.Value.TrimEnd('\'', '\"', ')', ';', '\r', '\n');
            if (_db.IsMaliciousUrl(url))
            {
                findings.Add(new Finding(
                    FindingId.ThreatIntelMaliciousUrl,
                    Severity.Critical,
                    ScannerConfig.PtsThreatIntelMaliciousUrl,
                    location,
                    "URL matches known malicious entry in URLhaus database")
                    .WithContext($"URL: {url}"));
            }
        }

        return findings;
    }

    private List<Finding> CheckIps(string text, string location)
    {
        var findings = new List<Finding>();
        var matches = Patterns.IpPattern.Matches(text);

        foreach (Match m in matches)
        {
            var ip = m.Value;
            if (_db.IsMaliciousIp(ip))
            {
                findings.Add(new Finding(
                    FindingId.ThreatIntelMaliciousIp,
                    Severity.Critical,
                    ScannerConfig.PtsThreatIntelMaliciousIp,
                    location,
                    "IP address matches known botnet C2 in Feodo Tracker database")
                    .WithContext($"IP: {ip}"));
            }
        }

        return findings;
    }

    private static string ComputeSha256(byte[] data)
    {
        var hash = System.Security.Cryptography.SHA256.HashData(data);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}

