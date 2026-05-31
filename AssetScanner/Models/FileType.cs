namespace AssetScanner.Models;

/// <summary>
/// Categorises the type of file being scanned.
/// </summary>
public enum FileType
{
    Unknown,
    UnityPackage,
    Zip,
    DllPe,
    CsScript,
    UnityAsset,
    Prefab,
    Meta,
    Shader,
    Texture,
    Audio,
    // Internal Unity package entries
    UnityAssetEntry,
    UnityMetaEntry,
}

