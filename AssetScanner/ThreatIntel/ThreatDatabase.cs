using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetScanner.ThreatIntel;

/// <summary>
/// Manages downloading and caching offline threat intelligence databases.
/// Uses public, freely available lists from abuse.ch (no uploads, no API keys).
/// </summary>
public sealed class ThreatDatabase
{
    private static readonly HttpClient Http = new();

    private readonly string _dbDirectory;
    private HashSet<string> _malwareHashes = new(StringComparer.OrdinalIgnoreCase);
    private HashSet<string> _maliciousUrls = new(StringComparer.OrdinalIgnoreCase);
    private HashSet<string> _maliciousDomains = new(StringComparer.OrdinalIgnoreCase);
    private HashSet<string> _maliciousIps = new(StringComparer.OrdinalIgnoreCase);

    public bool IsLoaded { get; private set; }

    public ThreatDatabase(string? dbDirectory = null)
    {
        _dbDirectory = dbDirectory ?? Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "VrcStorageScanner",
            "ThreatDB");
        Directory.CreateDirectory(_dbDirectory);
    }

    /// <summary>
    /// Load all cached databases from disk. Call this on startup.
    /// </summary>
    public void Load()
    {
        _malwareHashes = LoadHashSet(Path.Combine(_dbDirectory, "malwarebazaar_full.csv"));
        _maliciousUrls = LoadHashSet(Path.Combine(_dbDirectory, "urlhaus.csv"));
        _maliciousDomains = LoadHashSet(Path.Combine(_dbDirectory, "urlhaus_domains.csv"));
        _maliciousIps = LoadHashSet(Path.Combine(_dbDirectory, "feodo_tracker.csv"));
        IsLoaded = true;
    }

    /// <summary>
    /// Download fresh threat intel lists from public sources.
    /// </summary>
    public async Task UpdateAsync(CancellationToken ct = default)
    {
        Directory.CreateDirectory(_dbDirectory);

        // MalwareBazaar 鈥?full SHA-256 hash list of known malware
        await DownloadIfAvailable(
            "https://bazaar.abuse.ch/export/txt/sha256/recent/",
            Path.Combine(_dbDirectory, "malwarebazaar_full.csv"),
            ct);

        // URLhaus 鈥?recent malicious URLs
        await DownloadIfAvailable(
            "https://urlhaus.abuse.ch/downloads/csv_recent/",
            Path.Combine(_dbDirectory, "urlhaus.csv"),
            ct);

        // URLhaus 鈥?domains only
        await DownloadIfAvailable(
            "https://urlhaus.abuse.ch/downloads/hostfile/",
            Path.Combine(_dbDirectory, "urlhaus_domains.csv"),
            ct);

        // Feodo Tracker 鈥?botnet C2 IPs
        await DownloadIfAvailable(
            "https://feodotracker.abuse.ch/downloads/ipblocklist_recommended.txt",
            Path.Combine(_dbDirectory, "feodo_tracker.csv"),
            ct);

        Load();
    }

    /// <summary>
    /// Check if a SHA-256 hash is known malware.
    /// </summary>
    public bool IsKnownMalware(string sha256)
    {
        if (!IsLoaded) Load();
        return _malwareHashes.Contains(sha256);
    }

    /// <summary>
    /// Check if a URL is known malicious.
    /// </summary>
    public bool IsMaliciousUrl(string url)
    {
        if (!IsLoaded) Load();
        return _maliciousUrls.Contains(url) || _maliciousDomains.Any(d => url.Contains(d, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Check if a domain is known malicious.
    /// </summary>
    public bool IsMaliciousDomain(string domain)
    {
        if (!IsLoaded) Load();
        return _maliciousDomains.Contains(domain);
    }

    /// <summary>
    /// Check if an IP is known malicious.
    /// </summary>
    public bool IsMaliciousIp(string ip)
    {
        if (!IsLoaded) Load();
        return _maliciousIps.Contains(ip);
    }

    /// <summary>
    /// Statistics for the loaded databases.
    /// </summary>
    public ThreatDbStats GetStats()
    {
        if (!IsLoaded) Load();
        return new ThreatDbStats(
            _malwareHashes.Count,
            _maliciousUrls.Count,
            _maliciousDomains.Count,
            _maliciousIps.Count);
    }

    private static HashSet<string> LoadHashSet(string path)
    {
        var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        if (!File.Exists(path)) return set;

        foreach (var line in File.ReadLines(path))
        {
            var trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed)) continue;
            if (trimmed.StartsWith("#")) continue; // comment
            set.Add(trimmed);
        }
        return set;
    }

    private static async Task DownloadIfAvailable(string url, string destination, CancellationToken ct)
    {
        try
        {
            using var response = await Http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, ct);
            if (!response.IsSuccessStatusCode) return;

            await using var fs = new FileStream(destination, FileMode.Create, FileAccess.Write);
            await response.Content.CopyToAsync(fs);
        }
        catch
        {
            // If download fails, keep existing cached file if present
        }
    }
}

public sealed record ThreatDbStats(int MalwareHashes, int MaliciousUrls, int MaliciousDomains, int MaliciousIps);

