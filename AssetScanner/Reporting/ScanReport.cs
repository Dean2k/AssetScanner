using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using AssetScanner.Models;

namespace AssetScanner.Reporting;

/// <summary>
/// Structured scan report for JSON/console output.
/// </summary>
public sealed class ScanReport
{
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public string? Sha256 { get; set; }
    public uint Score { get; set; }
    public RiskLevel RiskLevel { get; set; }
    public string RiskLevelLabel { get; set; } = "UNKNOWN";
    public int TotalFiles { get; set; }
    public int TotalFindings { get; set; }
    public DateTimeOffset ScannedAt { get; set; }
    public List<ReportFinding> Findings { get; set; } = new();
    public List<ReportAsset> Assets { get; set; } = new();
    public string? Error { get; set; }

    public static ScanReport FromResults(string filePath, uint score, RiskLevel level, List<Finding> findings, List<PackageEntry> assets)
    {
        var report = new ScanReport
        {
            FileName = System.IO.Path.GetFileName(filePath),
            FilePath = filePath,
            Score = score,
            RiskLevel = level,
            RiskLevelLabel = level.ToString().ToUpperInvariant(),
            TotalFiles = assets.Count,
            TotalFindings = findings.Count,
            ScannedAt = DateTimeOffset.UtcNow,
            Findings = findings.Select(f => new ReportFinding
            {
                Id = f.Id.ToString(),
                Severity = f.Severity.ToString().ToUpperInvariant(),
                Points = f.Points,
                Location = f.Location,
                Message = f.Message,
                Context = f.Context,
                LineNumbers = f.LineNumbers.ToList(),
            }).ToList(),
            Assets = assets.Select(a => new ReportAsset
            {
                Path = a.Path,
                Type = a.Type.ToString(),
                SizeBytes = a.Data.Length,
            }).ToList(),
        };

        return report;
    }
}

public sealed class ReportFinding
{
    public string Id { get; set; } = "";
    public string Severity { get; set; } = "";
    public uint Points { get; set; }
    public string Location { get; set; } = "";
    public string Message { get; set; } = "";
    public string? Context { get; set; }
    public List<uint> LineNumbers { get; set; } = new();
}

public sealed class ReportAsset
{
    public string Path { get; set; } = "";
    public string Type { get; set; } = "";
    public int SizeBytes { get; set; }
}

