using System;
using System.Collections.Generic;
using System.Linq;
using AssetScanner.Config;
using AssetScanner.Models;

namespace AssetScanner.Scoring;

/// <summary>
/// Computes total risk score and classification from a list of findings.
/// </summary>
public static class RiskScorer
{
    public static (uint Score, RiskLevel Level) ComputeScore(List<Finding> findings)
    {
        var score = findings.Sum(f => (int)f.Points);
        var scoreLevel = Classify((uint)score);

        var criticalCount = findings.Count(f => f.Severity == Severity.Critical);
        var severityFloor = criticalCount switch
        {
            0 => RiskLevel.Clean,
            1 => RiskLevel.High,
            _ => RiskLevel.Critical
        };

        var level = LevelMax(scoreLevel, severityFloor);
        return ((uint)score, level);
    }

    private static RiskLevel Classify(uint score)
    {
        if (score <= ScannerConfig.ScoreCleanMax) return RiskLevel.Clean;
        if (score <= ScannerConfig.ScoreLowMax) return RiskLevel.Low;
        if (score <= ScannerConfig.ScoreMediumMax) return RiskLevel.Medium;
        if (score <= ScannerConfig.ScoreHighMax) return RiskLevel.High;
        return RiskLevel.Critical;
    }

    private static RiskLevel LevelMax(RiskLevel a, RiskLevel b)
    {
        var ordA = LevelOrd(a);
        var ordB = LevelOrd(b);
        return ordA >= ordB ? a : b;
    }

    private static int LevelOrd(RiskLevel level) => level switch
    {
        RiskLevel.Clean => 0,
        RiskLevel.Low => 1,
        RiskLevel.Medium => 2,
        RiskLevel.High => 3,
        RiskLevel.Critical => 4,
        _ => 0,
    };
}

