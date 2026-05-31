using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetScanner.Models;

/// <summary>
/// Metadata about a single file that has been discovered and optionally read.
/// </summary>
public sealed class FileRecord
{
    public string Path { get; }
    public FileType FileType { get; }
    public long SizeBytes { get; }
    public string Sha256 { get; }
    public string Md5 { get; }
    public string Sha1 { get; }
    public DateTimeOffset LastModified { get; }

    /// <summary>
    /// Raw file contents (kept in memory for analysis).
    /// </summary>
    public byte[] Data { get; }

    public FileRecord(
        string path,
        FileType fileType,
        long sizeBytes,
        string sha256,
        string md5,
        string sha1,
        DateTimeOffset lastModified,
        byte[] data)
    {
        Path = path ?? string.Empty;
        FileType = fileType;
        SizeBytes = sizeBytes;
        Sha256 = sha256 ?? string.Empty;
        Md5 = md5 ?? string.Empty;
        Sha1 = sha1 ?? string.Empty;
        LastModified = lastModified;
        Data = data ?? Array.Empty<byte>();
    }

    public static FileRecord FromPath(string path)
    {
        var fi = new FileInfo(path);
        var data = File.ReadAllBytes(path);
        var sha256 = ComputeHash(SHA256.Create(), data);
        var md5 = ComputeHash(MD5.Create(), data);
        var sha1 = ComputeHash(SHA1.Create(), data);
        var type = TypeDetection.DetectType(data, path);

        return new FileRecord(
            System.IO.Path.GetFullPath(path),
            type,
            fi.Length,
            sha256,
            md5,
            sha1,
            fi.LastWriteTimeUtc,
            data);
    }

    public static async Task<FileRecord> FromPathAsync(string path, CancellationToken ct = default)
    {
        var fi = new FileInfo(path);
        await using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, FileOptions.Asynchronous);
        var data = new byte[fi.Length];
        await fs.ReadExactlyAsync(data, ct);

        var sha256 = ComputeHash(SHA256.Create(), data);
        var md5 = ComputeHash(MD5.Create(), data);
        var sha1 = ComputeHash(SHA1.Create(), data);
        var type = TypeDetection.DetectType(data, path);

        return new FileRecord(
            System.IO.Path.GetFullPath(path),
            type,
            fi.Length,
            sha256,
            md5,
            sha1,
            fi.LastWriteTimeUtc,
            data);
    }

    public static FileRecord FromBytes(byte[] data, string path)
    {
        var sha256 = ComputeHash(SHA256.Create(), data);
        var md5 = ComputeHash(MD5.Create(), data);
        var sha1 = ComputeHash(SHA1.Create(), data);
        var type = TypeDetection.DetectType(data, path);

        return new FileRecord(
            path,
            type,
            data.Length,
            sha256,
            md5,
            sha1,
            DateTimeOffset.UtcNow,
            data);
    }

    private static string ComputeHash(HashAlgorithm algo, byte[] data)
    {
        using (algo)
        {
            var hash = algo.ComputeHash(data);
            return Convert.ToHexString(hash).ToLowerInvariant();
        }
    }
}

