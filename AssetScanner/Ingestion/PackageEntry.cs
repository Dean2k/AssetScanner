using System;
using System.Collections.Generic;

namespace AssetScanner.Models;

/// <summary>
/// Represents a single entry extracted from a Unity package or archive.
/// </summary>
public sealed class PackageEntry
{
    /// <summary>
    /// Internal path within the package (e.g. "Assets/Scripts/MyScript.cs").
    /// </summary>
    public string Path { get; }

    public AssetType Type { get; }

    /// <summary>
    /// Raw file bytes.
    /// </summary>
    public byte[] Data { get; }

    /// <summary>
    /// UTF-8 decoded text, if the file is textual (C#, shader, YAML, etc.).
    /// </summary>
    public string? Text { get; }

    /// <summary>
    /// The associated .meta file entry, if one exists.
    /// </summary>
    public PackageEntry? Meta { get; set; }

    public PackageEntry(string path, AssetType type, byte[] data, string? text = null)
    {
        Path = path ?? string.Empty;
        Type = type;
        Data = data ?? Array.Empty<byte>();
        Text = text;
    }
}

/// <summary>
/// Container for all entries extracted from a package.
/// </summary>
public sealed class PackageTree
{
    private readonly Dictionary<string, PackageEntry> _entries = new(StringComparer.OrdinalIgnoreCase);

    public IReadOnlyDictionary<string, PackageEntry> Entries => _entries;

    public void Add(PackageEntry entry)
    {
        _entries[entry.Path] = entry;
    }

    public bool TryGet(string path, out PackageEntry? entry) => _entries.TryGetValue(path, out entry);

    public IEnumerable<PackageEntry> AllEntries => _entries.Values;
}

