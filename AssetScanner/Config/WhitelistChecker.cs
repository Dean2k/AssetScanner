using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AssetScanner.Config;

/// <summary>
/// Outcome of evaluating a C# asset against the known-file whitelist.
/// </summary>
public enum WhitelistVerdict
{
    /// The asset path does not match any whitelist entry.
    NotWhitelisted,

    /// The asset SHA-256 matches a known trusted hash.
    FullyTrusted,

    /// The asset matches a whitelist entry by path, but the SHA-256 does not match.
    Modified
}

/// <summary>
/// Whitelist result with additional context.
/// </summary>
public sealed class WhitelistResult
{
    public WhitelistVerdict Verdict { get; }
    public string? Name { get; }
    public bool LineCountOk { get; }

    public WhitelistResult(WhitelistVerdict verdict, string? name = null, bool lineCountOk = false)
    {
        Verdict = verdict;
        Name = name;
        LineCountOk = lineCountOk;
    }
}

public static class WhitelistChecker
{
    public static WhitelistResult Check(string location, byte[] data, string source)
    {
        var entry = WhitelistData.Entries
            .FirstOrDefault(e => e.PathPatterns.All(pat => location.Contains(pat, StringComparison.OrdinalIgnoreCase)));

        if (entry is null)
            return new WhitelistResult(WhitelistVerdict.NotWhitelisted);

        // If hashes are registered, compute SHA-256 and compare.
        if (entry.Sha256Hashes.Length > 0)
        {
            var hashBytes = SHA256.HashData(data);
            var hash = Convert.ToHexString(hashBytes).ToLowerInvariant();
            if (entry.Sha256Hashes.Contains(hash))
                return new WhitelistResult(WhitelistVerdict.FullyTrusted, entry.Name);
        }

        // SHA-256 did not match (or no hashes registered yet) 鈫?Modified mode.
        bool lineCountOk = true;
        if (entry.ExpectedLineRange is { } range)
        {
            var lines = source.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Length;
            lineCountOk = lines >= range.Min && lines <= range.Max;
        }

        return new WhitelistResult(WhitelistVerdict.Modified, entry.Name, lineCountOk);
    }
}

