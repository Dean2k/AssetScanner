using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AssetScanner.Config;
using AssetScanner.Models;
using AssetScanner.Utils;

namespace AssetScanner.Analysis.Scripts;

/// <summary>
/// Detects obfuscation patterns in C# source code.
/// </summary>
public static class ObfuscationAnalyzer
{
    public static List<Finding> Analyze(string source, string location)
    {
        var findings = new List<Finding>();

        // Base64 high ratio
        var base64Chars = Patterns.Base64Long.Matches(source)
            .Cast<Match>()
            .Sum(m => m.Length);
        var totalChars = source.Length;
        if (totalChars > 0 && (double)base64Chars / totalChars >= ScannerConfig.ObfuscBase64Ratio)
        {
            findings.Add(new Finding(
                FindingId.CsBase64HighRatio,
                Severity.Medium,
                ScannerConfig.PtsCsBase64HighRatio,
                location,
                $"High Base64 character ratio detected ({base64Chars}/{totalChars} chars)"));
        }
        else if (Patterns.Base64Long.Matches(source).Cast<Match>().Any(m => m.Length >= ScannerConfig.ObfuscBase64LongLen))
        {
            // Individual long Base64 string
            findings.Add(new Finding(
                FindingId.CsBase64HighRatio,
                Severity.Medium,
                ScannerConfig.PtsCsBase64HighRatio,
                location,
                "Long Base64 string detected in C# script"));
        }

        // XOR decryption loop
        if (DetectXorLoop(source))
        {
            findings.Add(new Finding(
                FindingId.CsXorDecryption,
                Severity.Medium,
                ScannerConfig.PtsCsXorDecryption,
                location,
                "XOR decryption loop detected in C# script"));
        }

        // Short identifier density
        var tokens = Tokenize(source);
        if (tokens.Count >= ScannerConfig.ObfuscMinTokens)
        {
            var shortIdents = tokens.Count(t => t.Length <= 2 && char.IsLetter(t[0]));
            var ratio = (double)shortIdents / tokens.Count;
            if (ratio >= ScannerConfig.ObfuscShortIdentRatio)
            {
                findings.Add(new Finding(
                    FindingId.CsObfuscatedIdentifiers,
                    Severity.Low,
                    ScannerConfig.PtsCsObfuscatedIdentifiers,
                    location,
                    $"High density of short identifiers detected ({shortIdents}/{tokens.Count} tokens, {ratio:P0})"));
            }
        }

        return findings;
    }

    private static bool DetectXorLoop(string source)
    {
        // Simple pattern: byte array XOR with a key in a loop
        return source.Contains("^=") && source.Contains("for") && source.Contains("byte");
    }

    private static List<string> Tokenize(string source)
    {
        // Very simple tokenisation: split on non-alphanumeric characters
        var tokens = new List<string>();
        var current = new System.Text.StringBuilder();
        foreach (var ch in source)
        {
            if (char.IsLetterOrDigit(ch) || ch == '_')
            {
                current.Append(ch);
            }
            else if (current.Length > 0)
            {
                tokens.Add(current.ToString());
                current.Clear();
            }
        }
        if (current.Length > 0)
            tokens.Add(current.ToString());
        return tokens;
    }
}

