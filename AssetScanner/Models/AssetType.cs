namespace AssetScanner.Models;

/// <summary>
/// Categorises assets extracted from a Unity package.
/// </summary>
public enum AssetType
{
    Unknown,
    Script,
    Shader,
    Prefab,
    Material,
    Texture,
    Audio,
    Model,
    Animation,
    Scene,
    Meta,
    Dll,
    Other,
}

