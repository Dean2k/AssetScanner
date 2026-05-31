namespace AssetScanner.Config;

/// <summary>
/// A single entry in the known-file whitelist.
/// </summary>
public sealed class WhitelistEntry
{
    public string Name { get; }
    public string[] PathPatterns { get; }
    public string[] Sha256Hashes { get; }
    public (int Min, int Max)? ExpectedLineRange { get; }

    public WhitelistEntry(string name, string[] pathPatterns, string[] sha256Hashes, (int, int)? expectedLineRange = null)
    {
        Name = name;
        PathPatterns = pathPatterns;
        Sha256Hashes = sha256Hashes;
        ExpectedLineRange = expectedLineRange;
    }
}

