using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AssetScanner.Ingestion;
using AssetScanner.Models;

namespace AssetScanner.Config;

/// <summary>
/// Generates WhitelistEntry records with SHA-256 hashes from a known-good package.
/// This lets users populate hashes for legitimate packages instead of leaving arrays empty.
/// </summary>
public static class WhitelistHashGenerator
{
    public sealed class WhitelistEntryDraft
    {
        public string Name { get; set; } = "";
        public string[] PathPatterns { get; set; } = Array.Empty<string>();
        public string[] Sha256Hashes { get; set; } = Array.Empty<string>();
        public int LineCount { get; set; }
    }

    /// <summary>
    /// Scan a folder or extracted package and generate whitelist entries for all .cs files found.
    /// </summary>
    public static List<WhitelistEntryDraft> GenerateFromFolder(string folderPath, string packageName)
    {
        var results = new List<WhitelistEntryDraft>();
        var csFiles = Directory.EnumerateFiles(folderPath, "*.cs", SearchOption.AllDirectories);

        foreach (var file in csFiles)
        {
            var relativePath = Path.GetRelativePath(folderPath, file).Replace("\\", "/");
            var data = File.ReadAllBytes(file);
            var hash = ComputeSha256(data);
            var lines = File.ReadLines(file).Count();

            // Build path patterns from the relative path segments
            // We use folder names + filename (without extension) as patterns
            var segments = relativePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var patterns = segments.Select(s => s.TrimEnd()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

            // Create a human-readable name
            var fileName = Path.GetFileNameWithoutExtension(file);
            var entryName = $"{packageName} - {fileName}";

            results.Add(new WhitelistEntryDraft
            {
                Name = entryName,
                PathPatterns = patterns,
                Sha256Hashes = new[] { hash },
                LineCount = lines,
            });
        }

        return results;
    }

    /// <summary>
    /// Generate whitelist entries from an in-memory PackageTree (e.g. extracted .unitypackage).
    /// </summary>
    public static List<WhitelistEntryDraft> GenerateFromTree(PackageTree tree, string packageName)
    {
        var results = new List<WhitelistEntryDraft>();
        var csEntries = tree.AllEntries.Where(e => e.Path.EndsWith(".cs", StringComparison.OrdinalIgnoreCase));

        foreach (var entry in csEntries)
        {
            var hash = ComputeSha256(entry.Data);
            var lineCount = entry.Text?.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Length ?? 0;

            // Build path patterns from the asset path
            var segments = entry.Path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var patterns = segments.Select(s => s.TrimEnd()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

            var fileName = Path.GetFileNameWithoutExtension(entry.Path);
            var entryName = $"{packageName} - {fileName}";

            results.Add(new WhitelistEntryDraft
            {
                Name = entryName,
                PathPatterns = patterns,
                Sha256Hashes = new[] { hash },
                LineCount = lineCount,
            });
        }

        return results;
    }

    /// <summary>
    /// Format a list of drafts as C# WhitelistEntry code that can be pasted into WhitelistData.cs.
    /// </summary>
    public static string FormatAsCode(List<WhitelistEntryDraft> drafts, string packageName)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"        // == {packageName} ===============================================================");
        sb.AppendLine($"        // SHA-256 verified whitelist entries. Computed from known-good package.");
        sb.AppendLine();

        foreach (var d in drafts)
        {
            var patterns = string.Join(", ", d.PathPatterns.Select(p => $"\"{EscapeString(p)}\""));
            var hashes = string.Join(", ", d.Sha256Hashes.Select(h => $"\"{h}\""));
            var lineRange = d.LineCount > 0 ? $", ({d.LineCount}, {d.LineCount + 1})" : ", null";

            sb.AppendLine($"        new WhitelistEntry(\"{EscapeString(d.Name)}\",");
            sb.AppendLine($"            new[] {{ {patterns} }},");
            sb.AppendLine($"            new[] {{ {hashes} }}{lineRange}),");
            sb.AppendLine();
        }

        return sb.ToString();
    }

    private static string ComputeSha256(byte[] data)
    {
        var hash = SHA256.HashData(data);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    private static string EscapeString(string s)
    {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
    }
}

