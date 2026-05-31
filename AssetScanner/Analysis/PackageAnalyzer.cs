using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AssetScanner.Analysis.Dll;
using AssetScanner.Analysis.Scripts;
using AssetScanner.Config;
using AssetScanner.Models;
using AssetScanner.ThreatIntel;

namespace AssetScanner.Analysis;

/// <summary>
/// Orchestrates all analysis passes over a PackageTree.
/// </summary>
public static class PackageAnalyzer
{
    public static List<Finding> Analyze(PackageTree tree, ThreatIntelAnalyzer? threatIntel = null)
    {
        var findings = new List<Finding>();
        var entries = tree.AllEntries.ToList();

        // Structural checks
        foreach (var entry in entries)
        {
            findings.AddRange(StructuralChecks(entry));
        }

        // Script analysis
        foreach (var entry in entries.Where(e => e.Type == AssetType.Script || Path.GetExtension(e.Path).Equals(".cs", StringComparison.OrdinalIgnoreCase)))
        {
            if (entry.Text is not null)
            {
                var whitelistResult = WhitelistChecker.Check(entry.Path, entry.Data, entry.Text);
                if (whitelistResult.Verdict == WhitelistVerdict.FullyTrusted)
                    continue;

                var scriptFindings = ScriptAnalyzer.Analyze(entry.Text, entry.Path);
                if (whitelistResult.Verdict == WhitelistVerdict.Modified)
                {
                    // In Modified mode, attach extra context to every finding
                    scriptFindings = scriptFindings.Select(f =>
                        f.WithContext($"Modified whitelisted file ({whitelistResult.Name})")).ToList();
                }
                findings.AddRange(scriptFindings);
            }
        }

        // DLL / EXE analysis
        foreach (var entry in entries.Where(e => e.Type == AssetType.Dll || Path.GetExtension(e.Path).Equals(".dll", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(e.Path).Equals(".exe", StringComparison.OrdinalIgnoreCase)))
        {
            findings.AddRange(DllAnalyzer.Analyze(entry.Data, entry.Path));
        }

        // Prefab analysis
        foreach (var entry in entries.Where(e => e.Type == AssetType.Prefab))
        {
            if (entry.Text is not null)
                findings.AddRange(AnalyzePrefab(entry));
        }

        // Metadata analysis
        foreach (var entry in entries.Where(e => e.Type == AssetType.Meta || Path.GetExtension(e.Path).Equals(".meta", StringComparison.OrdinalIgnoreCase)))
        {
            if (entry.Text is not null)
                findings.AddRange(AnalyzeMeta(entry));
        }

        // Package-level checks
        findings.AddRange(PackageLevelChecks(tree));

        // Threat intelligence cross-reference
        if (threatIntel is not null)
        {
            findings.AddRange(threatIntel.Analyze(tree));
        }

        // Context reductions
        ApplyContextReductions(findings, tree);

        return findings;
    }

    private static List<Finding> StructuralChecks(PackageEntry entry)
    {
        var findings = new List<Finding>();
        var path = entry.Path;
        var fileName = Path.GetFileName(path);

        // Path traversal
        if (path.Contains("../") || path.Contains("..\\"))
        {
            findings.Add(new Finding(
                FindingId.PathTraversal,
                Severity.High,
                ScannerConfig.PtsPathTraversal,
                path,
                "Path traversal (../ or ..\\) detected in asset path"));
        }

        // Forbidden extension
        var ext = Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant();
        if (ScannerConfig.ForbiddenExtensions.Contains(ext))
        {
            findings.Add(new Finding(
                FindingId.ForbiddenExtension,
                Severity.Critical,
                ScannerConfig.PtsForbiddenExtension,
                path,
                $"Forbidden executable extension (.{ext}) detected in package"));
        }

        // Double extension (e.g. texture.png.dll)
        var nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
        if (nameWithoutExt.Contains('.') && Path.GetExtension(nameWithoutExt).TrimStart('.').ToLowerInvariant() is "png" or "jpg" or "jpeg" or "txt" or "json")
        {
            if (ext is "dll" or "exe" or "bat" or "ps1")
            {
                findings.Add(new Finding(
                    FindingId.DoubleExtension,
                    Severity.High,
                    ScannerConfig.PtsDoubleExtension,
                    path,
                    $"Double extension detected (possible disguise): {fileName}"));
            }
        }

        return findings;
    }

    private static List<Finding> AnalyzePrefab(PackageEntry entry)
    {
        var findings = new List<Finding>();
        var text = entry.Text ?? string.Empty;

        // Count GUID references
        var guidMatches = System.Text.RegularExpressions.Regex.Matches(text, @"guid:\s*([a-f0-9]{32})");
        if (guidMatches.Count > ScannerConfig.ThresholdPrefabExcessiveGuids)
        {
            findings.Add(new Finding(
                FindingId.PrefabExcessiveGuids,
                Severity.Low,
                ScannerConfig.PtsPrefabExcessiveGuids,
                entry.Path,
                $"Binary prefab has excessive GUID references ({guidMatches.Count})"));
        }

        // Count script references
        var scriptMatches = System.Text.RegularExpressions.Regex.Matches(text, @"m_Script:");
        if (scriptMatches.Count > ScannerConfig.ThresholdPrefabManyScripts)
        {
            findings.Add(new Finding(
                FindingId.PrefabManyScripts,
                Severity.Low,
                ScannerConfig.PtsPrefabManyScripts,
                entry.Path,
                $"Prefab references unusually many scripts ({scriptMatches.Count})"));
        }

        // Inline Base64
        var b64Matches = System.Text.RegularExpressions.Regex.Matches(text, @"[A-Za-z0-9+/]{100,}={0,2}");
        if (b64Matches.Count > 0)
        {
            findings.Add(new Finding(
                FindingId.PrefabInlineB64,
                Severity.Low,
                ScannerConfig.PtsPrefabInlineB64,
                entry.Path,
                $"Long inline Base64 field(s) detected in prefab ({b64Matches.Count} occurrences)"));
        }

        return findings;
    }

    private static List<Finding> AnalyzeMeta(PackageEntry entry)
    {
        var findings = new List<Finding>();
        var text = entry.Text ?? string.Empty;

        // External references
        if (text.Contains("external") || text.Contains("../../"))
        {
            findings.Add(new Finding(
                FindingId.MetaExternalRef,
                Severity.Low,
                ScannerConfig.PtsMetaExternalRef,
                entry.Path,
                ".meta file references assets not included in the package"));
        }

        return findings;
    }

    private static List<Finding> PackageLevelChecks(PackageTree tree)
    {
        var findings = new List<Finding>();
        var dlls = tree.AllEntries.Where(e => e.Type == AssetType.Dll).ToList();

        // Excessive DLLs
        if (dlls.Count > ScannerConfig.ThresholdExcessiveDlls)
        {
            findings.Add(new Finding(
                FindingId.ExcessiveDlls,
                Severity.Medium,
                ScannerConfig.PtsExcessiveDlls,
                "package",
                $"Package contains {dlls.Count} DLLs (excessive)"));
        }

        // DLL outside Plugins
        foreach (var dll in dlls)
        {
            if (!dll.Path.Contains("/Plugins/", StringComparison.OrdinalIgnoreCase) &&
                !dll.Path.Contains("\\Plugins\\", StringComparison.OrdinalIgnoreCase))
            {
                findings.Add(new Finding(
                    FindingId.DllOutsidePlugins,
                    Severity.Medium,
                    ScannerConfig.PtsDllOutsidePlugins,
                    dll.Path,
                    "DLL found outside Assets/Plugins/ folder"));
            }
        }

        return findings;
    }

    private static void ApplyContextReductions(List<Finding> findings, PackageTree tree)
    {
        var entries = tree.AllEntries.ToList();
        var hasVrchatSdk = entries.Any(e => e.Text is not null && AssetScanner.Utils.Patterns.VrchatSdk.IsMatch(e.Text));

        foreach (var finding in findings)
        {
            switch (finding.Id)
            {
                case FindingId.CsHttpClient when hasVrchatSdk:
                    finding.Points = ScannerConfig.ReduceHttpVrc;
                    break;
            }
        }
    }
}

