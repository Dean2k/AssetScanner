using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetScanner.Models;

/// <summary>
/// A single security finding discovered during analysis.
/// </summary>
public sealed class Finding
{
    public FindingId Id { get; }
    public Severity Severity { get; }
    public uint Points { get; set; }  // mutable so context reductions can adjust it
    public string Location { get; }
    public string Message { get; }
    public string? Context { get; private set; }
    public IReadOnlyList<uint> LineNumbers { get; }

    public Finding(
        FindingId id,
        Severity severity,
        uint points,
        string location,
        string message,
        IEnumerable<uint>? lineNumbers = null)
    {
        Id = id;
        Severity = severity;
        Points = points;
        Location = location ?? string.Empty;
        Message = message ?? string.Empty;
        LineNumbers = lineNumbers?.ToList().AsReadOnly() ?? new List<uint>().AsReadOnly();
    }

    /// <summary>
    /// Returns a copy of this finding with an additional context string attached.
    /// </summary>
    public Finding WithContext(string context)
    {
        var clone = new Finding(Id, Severity, Points, Location, Message, LineNumbers)
        {
            Context = Context is not null ? $"{Context}; {context}" : context
        };
        return clone;
    }

    /// <summary>
    /// Returns a copy of this finding with line numbers attached.
    /// </summary>
    public Finding WithLineNumbers(IEnumerable<uint> lineNumbers)
    {
        return new Finding(Id, Severity, Points, Location, Message, lineNumbers)
        {
            Context = Context
        };
    }
}

