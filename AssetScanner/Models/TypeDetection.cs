using System;
using System.IO;
using System.Linq;

namespace AssetScanner.Models;

/// <summary>
/// Detects the file type from raw bytes and/or extension.
/// </summary>
public static class TypeDetection
{
    public static FileType DetectType(byte[] data, string path)
    {
        var ext = Path.GetExtension(path).TrimStart('.').ToLowerInvariant();

        // Magic number checks
        if (data.Length >= 2 && data[0] == 'M' && data[1] == 'Z')
            return FileType.DllPe;

        if (data.Length >= 4 && data[0] == 0x50 && data[1] == 0x4B && data[2] == 0x03 && data[3] == 0x04)
        {
            // Could be a modern UnityPackage (zip-based) or a plain zip
            return ext == "unitypackage" ? FileType.UnityPackage : FileType.Zip;
        }

        // Legacy UnityPackage: gzip-wrapped tar
        if (data.Length >= 2 && data[0] == 0x1F && data[1] == 0x8B)
            return FileType.UnityPackage;

        // Extension fallback
        return ext switch
        {
            "cs" => FileType.CsScript,
            "dll" => FileType.DllPe,
            "unitypackage" => FileType.UnityPackage,
            "zip" => FileType.Zip,
            "prefab" => FileType.Prefab,
            "asset" => FileType.UnityAsset,
            "meta" => FileType.Meta,
            "shader" => FileType.Shader,
            "png" or "jpg" or "jpeg" or "tga" or "bmp" or "psd" or "exr" or "hdr" or "dds" or "webp" or "gif" => FileType.Texture,
            "wav" or "mp3" or "ogg" or "flac" or "aiff" or "aif" => FileType.Audio,
            _ => FileType.Unknown,
        };
    }
}

