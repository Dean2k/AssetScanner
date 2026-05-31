namespace AssetScanner.Config;

/// <summary>
/// Centralised configuration constants for the scanner.
/// This is the single source of truth for every tuneable value.
/// </summary>
public static class ScannerConfig
{
    // =========================================================================
    // 1. RISK SCORE BANDS
    // =========================================================================
    public const uint ScoreCleanMax = 30;
    public const uint ScoreLowMax = 75;
    public const uint ScoreMediumMax = 100;
    public const uint ScoreHighMax = 150;
    // Scores above ScoreHighMax 鈫?Critical

    // =========================================================================
    // 2. PER-FINDING RISK POINTS
    // =========================================================================

    // Structural / path
    public const uint PtsForbiddenExtension = 250;
    public const uint PtsPathTraversal = 85;
    public const uint PtsDoubleExtension = 50;

    // C# script 鈥?critical
    public const uint PtsCsAssemblyLoadBytes = 80;
    public const uint PtsCsAssemblyLoadFile = 60;
    public const uint PtsCsProcessStart = 75;

    // C# script 鈥?high
    public const uint PtsCsFileWrite = 40;
    public const uint PtsCsBinaryFormatter = 45;
    public const uint PtsCsDllimportUnknown = 60;
    public const uint PtsCsDllimportKnown = 45;
    public const uint PtsCsShellStrings = 45;
    public const uint PtsCsUrlUnknownDomain = 50;
    public const uint PtsCsIpHardcoded = 50;
    public const uint PtsCsUnicodeEscapes = 30;

    // C# script 鈥?medium
    public const uint PtsCsReflectionEmit = 40;
    public const uint PtsCsHttpClient = 30;
    public const uint PtsCsUnsafeBlock = 30;
    public const uint PtsCsRegistryAccess = 35;
    public const uint PtsCsEnvironmentAccess = 15;
    public const uint PtsCsMarshalOps = 25;
    public const uint PtsCsBase64HighRatio = 25;
    public const uint PtsCsXorDecryption = 20;

    // C# script 鈥?low
    public const uint PtsCsObfuscatedIdentifiers = 15;
    public const uint PtsCsNoMeta = 10;

    // PE / DLL binary
    public const uint PtsPeHighEntropyHigh = 55;
    public const uint PtsPeHighEntropyMedium = 20;
    public const uint PtsPeWriteExecuteSection = 40;
    public const uint PtsPeUnnamedSection = 20;
    public const uint PtsPeInflatedSection = 20;
    public const uint PtsPeInvalidHeader = 15;
    public const uint PtsPeParseError = 5;

    // Import table (DLL)
    public const uint PtsDllImportCreateprocess = 80;
    public const uint PtsDllImportCreateremotethread = 75;
    public const uint PtsDllImportSockets = 60;
    public const uint PtsDllImportInternet = 45;
    public const uint PtsDllImportWriteProcessMem = 45;
    public const uint PtsDllImportVirtualAlloc = 35;
    public const uint PtsDllImportLoadlibrary = 25;
    public const uint PtsDllImportGetprocaddress = 20;
    public const uint PtsDllImportFileOps = 20;
    public const uint PtsDllImportRegistry = 25;
    public const uint PtsDllImportCrypto = 20;
    public const uint PtsDllImportSysinfo = 8;

    // DLL string analysis
    public const uint PtsDllStringsSuspiciousPath = 12;
    public const uint PtsDllUrlUnknownDomain = 50;
    public const uint PtsDllIpHardcoded = 50;

    // Asset scanners
    public const uint PtsMagicMismatch = 25;
    public const uint PtsMagicMismatchImage = 2;
    public const uint PtsTextureHighEntropy = 2;
    public const uint PtsAudioUnusualEntropy = 2;
    public const uint PtsAudioTrailingData = 35;
    public const uint PtsAudioSuspiciousChunk = 25;
    public const uint PtsAudioMalformedHeader = 20;
    public const uint PtsPolyglotFile = 70;

    // Metadata
    public const uint PtsMetaExternalRef = 4;
    public const uint PtsMetaFutureTimestamp = 20;

    // Prefab / ScriptableObject
    public const uint PtsPrefabInlineB64 = 1;
    public const uint PtsPrefabExcessiveGuids = 5;
    public const uint PtsPrefabManyScripts = 5;

    // Package-level
    public const uint PtsDllOutsidePlugins = 35;
    public const uint PtsDllManyDependents = 15;
    public const uint PtsExcessiveDlls = 15;

    // Threat intelligence
    public const uint PtsThreatIntelKnownMalwareHash = 200;
    public const uint PtsThreatIntelMaliciousUrl = 100;
    public const uint PtsThreatIntelMaliciousIp = 100;

    // =========================================================================
    // 3. CONTEXT SCORE REDUCTIONS
    // =========================================================================
    public const uint ReduceHttpVrc = 10;
    public const uint ReduceReflectEditor = 15;
    public const uint ReducePolyglotNoLoader = 15;

    // =========================================================================
    // 4. ENTROPY THRESHOLDS
    // =========================================================================
    public const double EntropyPeHigh = 7.2;
    public const double EntropyPeSuspicious = 6.8;
    public const double EntropyTextureHigh = 7.5;
    public const double EntropyAudioMin = 3.0;
    public const double EntropyAudioMax = 7.9;
    public const int AudioTrailingMinBytes = 64;
    public const int AudioSuspiciousChunkMinBytes = 256;

    // =========================================================================
    // 5. PACKAGE-LEVEL THRESHOLDS
    // =========================================================================
    public const int ThresholdExcessiveDlls = 10;
    public const int ThresholdDllManyDependents = 5;
    public const int ThresholdPrefabManyScripts = 20;
    public const int ThresholdPrefabExcessiveGuids = 100;
    public const ulong PeInflatedRatio = 4;
    public const int DllMinStringLen = 6;

    // =========================================================================
    // 6. OBFUSCATION DETECTION
    // =========================================================================
    public const double ObfuscBase64Ratio = 0.15;
    public const int ObfuscBase64LongLen = 200;
    public const int ObfuscMinTokens = 50;
    public const double ObfuscShortIdentRatio = 0.4;

    // =========================================================================
    // 7. FORBIDDEN EXTENSIONS
    // =========================================================================
    public static readonly string[] ForbiddenExtensions = new[]
    {
        "exe", "bat", "cmd", "ps1", "sh", "vbs", "jar", "msi", "scr", "hta", "pif"
    };

    // =========================================================================
    // 8. DOMAIN WHITELIST
    // =========================================================================
    public static readonly string[] SafeDomains = new[]
    {
        "vrchat.com",
        "unity3d.com",
        "unity.com",
        "microsoft.com",
        "github.com",
        "githubusercontent.com",
        "nuget.org",
        "visualstudio.com",
        "windowsupdate.com",
        "thryrallo.de",
        "stackexchange.com",
        "youtube.com",
        "poiyomi.com",
        "translate.googleapis.com",
        "cloud.google.com",
        "gumroad.com",
        "ko-fi.com",
        "linktr.ee",
        "twitter.com",
        "x.com",
        "discord.gg",
        "patreon.com",
    };
}

