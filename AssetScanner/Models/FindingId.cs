namespace AssetScanner.Models;

/// <summary>
/// Identifies the type of security finding detected during analysis.
/// </summary>
public enum FindingId
{
    // Structural / path
    ForbiddenExtension,
    PathTraversal,
    DoubleExtension,

    // C# script 鈥?critical
    CsProcessStart,
    CsAssemblyLoadBytes,
    CsAssemblyLoadFile,

    // C# script 鈥?high
    CsFileWrite,
    CsBinaryFormatter,
    CsDllimportUnknown,
    CsDllimportKnown,
    CsShellStrings,
    CsUrlUnknownDomain,
    CsIpHardcoded,

    // C# script 鈥?medium
    CsReflectionEmit,
    CsHttpClient,
    CsUnsafeBlock,
    CsRegistryAccess,
    CsEnvironmentAccess,
    CsMarshalOps,
    CsBase64HighRatio,
    CsXorDecryption,
    CsUnicodeEscapes,

    // C# script 鈥?low
    CsObfuscatedIdentifiers,
    CsNoMeta,

    // PE / DLL binary
    PeHighEntropySection,
    PeWriteExecuteSection,
    PeUnnamedSection,
    PeInflatedSection,
    PeInvalidHeader,
    PeParseError,

    // Import table (DLL)
    DllImportCreateprocess,
    DllImportCreateremotethread,
    DllImportSockets,
    DllImportInternet,
    DllImportWriteProcessMem,
    DllImportVirtualAlloc,
    DllImportLoadlibrary,
    DllImportGetprocaddress,
    DllImportFileOps,
    DllImportRegistry,
    DllImportCrypto,
    DllImportSysinfo,

    // DLL string analysis
    DllStringsSuspiciousPath,
    DllUrlUnknownDomain,
    DllIpHardcoded,

    // Asset scanners
    MagicMismatch,
    MagicMismatchImage,
    TextureHighEntropy,
    AudioUnusualEntropy,
    AudioTrailingData,
    AudioSuspiciousChunk,
    AudioMalformedHeader,
    PolyglotFile,

    // Metadata
    MetaExternalRef,
    MetaFutureTimestamp,

    // Prefab / ScriptableObject
    PrefabInlineB64,
    PrefabExcessiveGuids,
    PrefabManyScripts,

    // Package-level
    DllOutsidePlugins,
    DllManyDependents,
    ExcessiveDlls,

    // Threat intelligence
    ThreatIntelKnownMalwareHash,
    ThreatIntelMaliciousUrl,
    ThreatIntelMaliciousIp,
}

