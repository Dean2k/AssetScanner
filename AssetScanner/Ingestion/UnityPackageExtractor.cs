using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AssetScanner.Models;

namespace AssetScanner.Ingestion;

/// <summary>
/// Extracts contents from .unitypackage files (modern ZIP or legacy gzip+tar)
/// as well as plain .zip archives and directories.
/// </summary>
public static class UnityPackageExtractor
{
    /// <summary>
    /// Extract a file path and return a populated PackageTree.
    /// </summary>
    public static PackageTree Extract(string filePath)
    {
        if (Directory.Exists(filePath))
            return ExtractDirectory(filePath);

        var data = File.ReadAllBytes(filePath);
        return ExtractBytes(data, filePath);
    }

    public static PackageTree ExtractBytes(byte[] data, string sourcePath)
    {
        var fileType = TypeDetection.DetectType(data, sourcePath);

        return fileType switch
        {
            FileType.UnityPackage => ExtractUnityPackage(data),
            FileType.Zip => ExtractZip(data),
            _ => SingleFileTree(data, sourcePath),
        };
    }

    /// <summary>
    /// Walk a directory and return a PackageTree with all files found.
    /// </summary>
    public static PackageTree ExtractDirectory(string dirPath)
    {
        var tree = new PackageTree();

        foreach (var file in Directory.EnumerateFiles(dirPath, "*.*", SearchOption.AllDirectories))
        {
            try
            {
                var relativePath = System.IO.Path.GetRelativePath(dirPath, file).Replace('\\', '/');
                var data = File.ReadAllBytes(file);
                var type = ClassifyAssetType(file);
                var text = TryGetText(data, file);
                tree.Add(new PackageEntry(relativePath, type, data, text));
            }
            catch
            {
                // Skip unreadable files
            }
        }

        return tree;
    }

    private static PackageTree ExtractUnityPackage(byte[] data)
    {
        var tree = new PackageTree();

        // Modern UnityPackage: ZIP
        if (data.Length >= 4 && data[0] == 0x50 && data[1] == 0x4B)
        {
            using var ms = new MemoryStream(data);
            using var archive = new ZipArchive(ms, ZipArchiveMode.Read);
            ParseZipArchive(archive, tree);
            return tree;
        }

        // Legacy UnityPackage: gzip + tar
        if (data.Length >= 2 && data[0] == 0x1F && data[1] == 0x8B)
        {
            using var gzStream = new MemoryStream(data);
            using var gzip = new GZipStream(gzStream, CompressionMode.Decompress);
            using var tarMs = new MemoryStream();
            gzip.CopyTo(tarMs);
            tarMs.Position = 0;
            ParseTarArchive(tarMs, tree);
            return tree;
        }

        return tree;
    }

    private static PackageTree ExtractZip(byte[] data)
    {
        var tree = new PackageTree();
        using var ms = new MemoryStream(data);
        using var archive = new ZipArchive(ms, ZipArchiveMode.Read);

        if (IsUnityPackageZip(archive))
        {
            ParseZipArchive(archive, tree);
        }
        else
        {
            ParsePlainZipArchive(archive, tree);
        }

        return tree;
    }

    /// <summary>
    /// Heuristic: if a ZIP contains entries named "pathname" or "asset" inside sub-folders,
    /// it's likely a UnityPackage. Otherwise treat as a plain folder ZIP.
    /// </summary>
    private static bool IsUnityPackageZip(ZipArchive archive)
    {
        int markers = 0;
        foreach (var entry in archive.Entries)
        {
            var parts = entry.FullName.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                var name = parts[^1];
                if (name.Equals("pathname", StringComparison.OrdinalIgnoreCase) ||
                    name.Equals("asset", StringComparison.OrdinalIgnoreCase))
                {
                    markers++;
                    if (markers >= 3)
                        return true;
                }
            }
        }
        return false;
    }

    private static void ParseZipArchive(ZipArchive archive, PackageTree tree)
    {
        // Unity packages store each asset under a GUID folder:
        //   <guid>/asset       — the actual file
        //   <guid>/asset.meta  — the .meta file
        //   <guid>/pathname   — the original asset path inside the project

        var entries = archive.Entries.ToList();
        var guidMap = new Dictionary<string, (ZipArchiveEntry? asset, ZipArchiveEntry? meta, ZipArchiveEntry? pathname)>(StringComparer.OrdinalIgnoreCase);

        foreach (var entry in entries)
        {
            var parts = entry.FullName.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;
            var guid = parts[0];
            var name = parts[^1];

            if (!guidMap.TryGetValue(guid, out var tuple))
                tuple = (null, null, null);

            if (name.Equals("asset", StringComparison.OrdinalIgnoreCase))
                tuple.asset = entry;
            else if (name.Equals("asset.meta", StringComparison.OrdinalIgnoreCase))
                tuple.meta = entry;
            else if (name.Equals("pathname", StringComparison.OrdinalIgnoreCase))
                tuple.pathname = entry;

            guidMap[guid] = tuple;
        }

        foreach (var (guid, (assetEntry, metaEntry, pathnameEntry)) in guidMap)
        {
            var path = ReadZipEntryText(pathnameEntry) ?? $"Assets/__unknown/{guid}";
            var assetData = ReadZipEntryBytes(assetEntry);
            var metaData = ReadZipEntryBytes(metaEntry);

            if (assetData is not null)
            {
                var type = ClassifyAssetType(path);
                var text = TryGetText(assetData, path);
                var entry = new PackageEntry(path, type, assetData, text);

                if (metaData is not null)
                {
                    entry.Meta = new PackageEntry(path + ".meta", AssetType.Meta, metaData, TryGetText(metaData, path + ".meta"));
                }

                tree.Add(entry);
            }
        }
    }

    private static void ParsePlainZipArchive(ZipArchive archive, PackageTree tree)
    {
        foreach (var entry in archive.Entries)
        {
            // Skip directories
            if (entry.FullName.EndsWith('/')) continue;

            var path = entry.FullName.Replace('\\', '/');
            var data = ReadZipEntryBytes(entry);
            if (data is null) continue;

            var type = ClassifyAssetType(path);
            var text = TryGetText(data, path);
            tree.Add(new PackageEntry(path, type, data, text));
        }
    }

    private static void ParseTarArchive(Stream tarStream, PackageTree tree)
    {
        using var reader = new System.Formats.Tar.TarReader(tarStream);

        var entries = new Dictionary<string, (byte[]? asset, byte[]? meta, string? pathname)>(StringComparer.OrdinalIgnoreCase);

        while (reader.GetNextEntry() is { } entry)
        {
            var name = entry.Name;
            var parts = name.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;

            var guid = parts[0];
            var fileName = parts[^1];

            if (!entries.TryGetValue(guid, out var tuple))
                tuple = (null, null, null);

            using var ms = new MemoryStream();
            entry.DataStream?.CopyTo(ms);
            var data = ms.ToArray();

            if (fileName.Equals("asset", StringComparison.OrdinalIgnoreCase))
                tuple.asset = data;
            else if (fileName.Equals("asset.meta", StringComparison.OrdinalIgnoreCase))
                tuple.meta = data;
            else if (fileName.Equals("pathname", StringComparison.OrdinalIgnoreCase))
                tuple.pathname = Encoding.UTF8.GetString(data);

            entries[guid] = tuple;
        }

        foreach (var (guid, (assetData, metaData, path)) in entries)
        {
            var assetPath = path ?? $"Assets/__unknown/{guid}";
            if (assetData is not null)
            {
                var type = ClassifyAssetType(assetPath);
                var text = TryGetText(assetData, assetPath);
                var entry = new PackageEntry(assetPath, type, assetData, text);

                if (metaData is not null)
                {
                    entry.Meta = new PackageEntry(assetPath + ".meta", AssetType.Meta, metaData, TryGetText(metaData, assetPath + ".meta"));
                }

                tree.Add(entry);
            }
        }
    }

    private static byte[]? ReadZipEntryBytes(ZipArchiveEntry? entry)
    {
        if (entry is null) return null;
        using var s = entry.Open();
        using var ms = new MemoryStream();
        s.CopyTo(ms);
        return ms.ToArray();
    }

    private static string? ReadZipEntryText(ZipArchiveEntry? entry)
    {
        var bytes = ReadZipEntryBytes(entry);
        if (bytes is null) return null;
        return Encoding.UTF8.GetString(bytes);
    }

    public static AssetType ClassifyAssetType(string path)
    {
        var ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
        return ext switch
        {
            ".cs" => AssetType.Script,
            ".shader" => AssetType.Shader,
            ".prefab" => AssetType.Prefab,
            ".mat" => AssetType.Material,
            ".png" or ".jpg" or ".jpeg" or ".tga" or ".bmp" or ".psd" or ".exr" or ".hdr" or ".dds" or ".webp" => AssetType.Texture,
            ".wav" or ".mp3" or ".ogg" or ".flac" or ".aiff" or ".aif" => AssetType.Audio,
            ".fbx" or ".obj" or ".blend" => AssetType.Model,
            ".anim" => AssetType.Animation,
            ".unity" => AssetType.Scene,
            ".meta" => AssetType.Meta,
            ".dll" => AssetType.Dll,
            _ => AssetType.Other,
        };
    }

    public static string? TryGetText(byte[] data, string path)
    {
        var ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
        var isText = ext is ".cs" or ".shader" or ".txt" or ".json" or ".xml" or ".yaml" or ".yml" or ".meta" or ".prefab" or ".asset" or ".mat" or ".anim" or ".unity";
        if (!isText) return null;

        try
        {
            return Encoding.UTF8.GetString(data);
        }
        catch
        {
            return null;
        }
    }

    private static PackageTree SingleFileTree(byte[] data, string path)
    {
        var tree = new PackageTree();
        var type = ClassifyAssetType(path);
        var text = TryGetText(data, path);
        tree.Add(new PackageEntry(path, type, data, text));
        return tree;
    }
}
