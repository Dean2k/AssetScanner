using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssetScanner.Analysis.Dll;

/// <summary>
/// Lightweight PE (Portable Executable) parser for native and managed DLLs.
/// </summary>
public sealed class PeParser
{
    public bool IsValid { get; }
    public bool IsManaged { get; private set; }
    public List<PeSection> Sections { get; } = new();
    public List<ImportDescriptor> Imports { get; } = new();
    public ulong ImageBase { get; private set; }

    private readonly byte[] _data;

    public PeParser(byte[] data)
    {
        _data = data;
        IsValid = Parse();
    }

    private static ReadOnlySpan<byte> Slice(byte[] data, int offset, int length)
        => new ReadOnlySpan<byte>(data, offset, length);

    private bool Parse()
    {
        if (_data.Length < 64) return false;
        if (_data[0] != 'M' || _data[1] != 'Z') return false;

        var peOffset = (int)BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, 0x3C, 4));
        if (peOffset > _data.Length - 4) return false;
        if (_data[peOffset] != 'P' || _data[peOffset + 1] != 'E') return false;

        var coffOffset = peOffset + 4;
        var numberOfSections = BinaryPrimitives.ReadUInt16LittleEndian(Slice(_data, coffOffset + 2, 2));
        var sizeOfOptionalHeader = BinaryPrimitives.ReadUInt16LittleEndian(Slice(_data, coffOffset + 16, 2));
        var optionalHeaderOffset = coffOffset + 20;

        if (optionalHeaderOffset + sizeOfOptionalHeader > _data.Length) return false;

        var magic = BinaryPrimitives.ReadUInt16LittleEndian(Slice(_data, optionalHeaderOffset, 2));
        bool isPE32Plus = magic == 0x20B;
        IsManaged = CheckManaged(optionalHeaderOffset, sizeOfOptionalHeader, isPE32Plus);

        ImageBase = isPE32Plus
            ? BinaryPrimitives.ReadUInt64LittleEndian(Slice(_data, optionalHeaderOffset + 24, 8))
            : BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, optionalHeaderOffset + 28, 4));

        var sectionTableOffset = optionalHeaderOffset + sizeOfOptionalHeader;
        ParseSections(sectionTableOffset, numberOfSections);
        ParseImports(optionalHeaderOffset, isPE32Plus);

        return true;
    }

    private bool CheckManaged(int optionalHeaderOffset, int sizeOfOptionalHeader, bool isPE32Plus)
    {
        // Data directory[14] = CLI header (ImageDirectoryEntry_COMDescriptor)
        var dataDirOffset = optionalHeaderOffset + (isPE32Plus ? 112 : 96);
        if (dataDirOffset + 8 > _data.Length) return false;
        var rva = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, dataDirOffset, 4));
        return rva != 0;
    }

    private void ParseSections(int offset, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var secOff = offset + i * 40;
            if (secOff + 40 > _data.Length) break;

            var nameBytes = Slice(_data, secOff, 8);
            var name = System.Text.Encoding.ASCII.GetString(nameBytes).TrimEnd('\0');
            var virtualSize = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, secOff + 8, 4));
            var virtualAddress = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, secOff + 12, 4));
            var rawSize = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, secOff + 16, 4));
            var rawAddress = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, secOff + 20, 4));
            var characteristics = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, secOff + 36, 4));

            Sections.Add(new PeSection
            {
                Name = name,
                VirtualSize = virtualSize,
                VirtualAddress = virtualAddress,
                RawSize = rawSize,
                RawAddress = rawAddress,
                Characteristics = characteristics,
            });
        }
    }

    private void ParseImports(int optionalHeaderOffset, bool isPE32Plus)
    {
        var dataDirOffset = optionalHeaderOffset + (isPE32Plus ? 112 : 96);
        // Import directory is data directory[1]
        var importDirOffset = dataDirOffset + 8; // skip export, point to import
        if (importDirOffset + 8 > _data.Length) return;

        var importRva = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, importDirOffset, 4));
        var importSize = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, importDirOffset + 4, 4));
        if (importRva == 0 || importSize == 0) return;

        var importDirRva = importRva;
        // Find section containing import directory
        var importSection = Sections.FirstOrDefault(s => importDirRva >= s.VirtualAddress && importDirRva < s.VirtualAddress + s.VirtualSize);
        if (importSection is null) return;

        var importDirFileOffset = importSection.RawAddress + (importDirRva - importSection.VirtualAddress);
        var numDescriptors = (int)(importSize / 20);

        for (int i = 0; i < numDescriptors; i++)
        {
            var descOffset = (int)importDirFileOffset + i * 20;
            if (descOffset + 20 > _data.Length) break;

            var nameRva = BinaryPrimitives.ReadUInt32LittleEndian(Slice(_data, descOffset + 12, 4));
            if (nameRva == 0) break;

            var nameSection = Sections.FirstOrDefault(s => nameRva >= s.VirtualAddress && nameRva < s.VirtualAddress + s.VirtualSize);
            if (nameSection is null) continue;

            var nameFileOffset = nameSection.RawAddress + (nameRva - nameSection.VirtualAddress);
            var dllName = ReadNullTerminatedAscii((int)nameFileOffset);
            if (string.IsNullOrEmpty(dllName)) continue;

            Imports.Add(new ImportDescriptor
            {
                DllName = dllName,
            });
        }
    }

    private string ReadNullTerminatedAscii(int offset)
    {
        var sb = new System.Text.StringBuilder();
        for (int i = offset; i < _data.Length && i < offset + 256; i++)
        {
            var b = _data[i];
            if (b == 0) break;
            if (b >= 32 && b < 127)
                sb.Append((char)b);
        }
        return sb.ToString();
    }

    public static double ComputeEntropy(byte[] data)
    {
        if (data.Length == 0) return 0;
        var freq = new int[256];
        foreach (var b in data) freq[b]++;
        double entropy = 0;
        for (int i = 0; i < 256; i++)
        {
            if (freq[i] == 0) continue;
            var p = (double)freq[i] / data.Length;
            entropy -= p * Math.Log2(p);
        }
        return entropy;
    }
}

public sealed class PeSection
{
    public string Name { get; set; } = "";
    public uint VirtualSize { get; set; }
    public uint VirtualAddress { get; set; }
    public uint RawSize { get; set; }
    public uint RawAddress { get; set; }
    public uint Characteristics { get; set; }

    public bool IsWritable => (Characteristics & 0x80000000) != 0;
    public bool IsExecutable => (Characteristics & 0x20000000) != 0;
}

public sealed class ImportDescriptor
{
    public string DllName { get; set; } = "";
}

