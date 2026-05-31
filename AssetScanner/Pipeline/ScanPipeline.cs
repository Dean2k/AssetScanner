using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AssetScanner.Analysis;
using AssetScanner.Ingestion;
using AssetScanner.Models;
using AssetScanner.Reporting;
using AssetScanner.Scoring;
using AssetScanner.ThreatIntel;

namespace AssetScanner.Pipeline;

/// <summary>
/// Orchestrates the full scan pipeline: ingest 鈫?analyze 鈫?score 鈫?report.
/// </summary>
public static class ScanPipeline
{
    /// <summary>
    /// Optional threat intelligence database. When set, scan results are
    /// cross-referenced against known-malware hashes, URLs, and IPs.
    /// </summary>
    public static ThreatDatabase? ThreatDatabase { get; set; }

    /// <summary>
    /// Scan a file on disk.
    /// </summary>
    public static ScanReport RunScan(string filePath)
    {
        try
        {
            if (Directory.Exists(filePath))
            {
                return RunScanDirectory(filePath);
            }

            var record = FileRecord.FromPath(filePath);
            return RunScanWithRecord(record);
        }
        catch (Exception ex)
        {
            return new ScanReport
            {
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                Error = ex.Message,
                RiskLevel = RiskLevel.Critical,
                RiskLevelLabel = "ERROR",
                ScannedAt = DateTimeOffset.UtcNow,
            };
        }
    }

    private static ScanReport RunScanDirectory(string dirPath)
    {
        var tree = UnityPackageExtractor.ExtractDirectory(dirPath);

        ThreatIntelAnalyzer? threatIntel = null;
        if (ThreatDatabase is not null)
        {
            threatIntel = new ThreatIntelAnalyzer(ThreatDatabase);
        }

        var findings = PackageAnalyzer.Analyze(tree, threatIntel);
        var (score, level) = RiskScorer.ComputeScore(findings);

        return ScanReport.FromResults(
            dirPath,
            score,
            level,
            findings,
            tree.AllEntries.ToList());
    }

    /// <summary>
    /// Scan raw bytes (e.g. from drag-and-drop or uploaded file).
    /// </summary>
    public static ScanReport RunScanBytes(byte[] data, string path)
    {
        try
        {
            var record = FileRecord.FromBytes(data, path);
            return RunScanWithRecord(record);
        }
        catch (Exception ex)
        {
            return new ScanReport
            {
                FilePath = path,
                FileName = Path.GetFileName(path),
                Error = ex.Message,
                RiskLevel = RiskLevel.Critical,
                RiskLevelLabel = "ERROR",
                ScannedAt = DateTimeOffset.UtcNow,
            };
        }
    }

    public static async Task<ScanReport> RunScanAsync(string filePath, CancellationToken ct = default)
    {
        try
        {
            var record = await FileRecord.FromPathAsync(filePath, ct);
            return RunScanWithRecord(record);
        }
        catch (Exception ex)
        {
            return new ScanReport
            {
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                Error = ex.Message,
                RiskLevel = RiskLevel.Critical,
                RiskLevelLabel = "ERROR",
                ScannedAt = DateTimeOffset.UtcNow,
            };
        }
    }

    private static ScanReport RunScanWithRecord(FileRecord record)
    {
        var tree = UnityPackageExtractor.ExtractBytes(record.Data, record.Path);

        ThreatIntelAnalyzer? threatIntel = null;
        if (ThreatDatabase is not null)
        {
            threatIntel = new ThreatIntelAnalyzer(ThreatDatabase);
        }

        var findings = PackageAnalyzer.Analyze(tree, threatIntel);
        var (score, level) = RiskScorer.ComputeScore(findings);

        return ScanReport.FromResults(
            record.Path,
            score,
            level,
            findings,
            tree.AllEntries.ToList());
    }
}

