using System;
using System.Linq;
using System.Text.RegularExpressions;
using AssetScanner.Config;

namespace AssetScanner.Utils;

/// <summary>
/// Pre-compiled regex patterns used by the various analyzers.
/// </summary>
public static class Patterns
{
    // URLs in source code
    public static readonly Regex UrlPattern = new(
        @"(?i)(https?|ftp|ws|wss)://[^\s""';)]+",
        RegexOptions.Compiled);

    // IP addresses (rough match)
    public static readonly Regex IpPattern = new(
        @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b",
        RegexOptions.Compiled);

    // Long Base64 strings (>= 50 chars)
    public static readonly Regex Base64Long = new(
        @"[A-Za-z0-9+/]{50,}={0,2}",
        RegexOptions.Compiled);

    // Hex-encoded PE header
    public static readonly Regex HexPeHeader = new(
        @"(?i)4[Dd]5[Aa][0-9A-Fa-f]{10,}",
        RegexOptions.Compiled);

    // Registry key patterns
    public static readonly Regex RegistryKey = new(
        @"(?i)(HKEY_|SOFTWARE\\|SYSTEM\\CurrentControlSet)",
        RegexOptions.Compiled);

    // System paths
    public static readonly Regex SystemPath = new(
        @"(?i)(%APPDATA%|%TEMP%|C:\\Windows\\|C:\\Users\\|/etc/|/tmp/)",
        RegexOptions.Compiled);

    // Shell commands embedded in strings
    public static readonly Regex ShellCmd = new(
        @"(?i)\b(cmd\.exe|powershell|powershell\.exe|bash|/bin/sh|wget|curl\b|ncat|nc\.exe)\b",
        RegexOptions.Compiled);

    // Path traversal
    public static readonly Regex PathTraversal = new(
        @"(\.\.\/|\.\.\\)",
        RegexOptions.Compiled);

    // C# dangerous API patterns
    public static readonly Regex CsProcessStart = new(
        @"Process\.Start\s*\(",
        RegexOptions.Compiled);

    public static readonly Regex CsAssemblyLoad = new(
        @"Assembly\.Load(File|From)?\s*\(",
        RegexOptions.Compiled);

    public static readonly Regex CsReflectionEmit = new(
        @"System\.Reflection\.Emit|ILGenerator|TypeBuilder|MethodBuilder",
        RegexOptions.Compiled);

    public static readonly Regex CsWebclient = new(
        @"(System\.Net\.WebClient|System\.Net\.Http\.HttpClient|UnityWebRequest|TcpClient|UdpClient)",
        RegexOptions.Compiled);

    public static readonly Regex CsFileWrite = new(
        @"(File\.WriteAll(Bytes|Text|Lines)|File\.Delete|Directory\.CreateDirectory|File\.Move|File\.Copy)\s*\(",
        RegexOptions.Compiled);

    public static readonly Regex CsBinaryFormatter = new(
        @"BinaryFormatter|System\.Runtime\.Serialization\.Formatters\.Binary",
        RegexOptions.Compiled);

    public static readonly Regex CsDllimport = new(
        @"\[DllImport\s*\(\s*""([^""]+)""",
        RegexOptions.Compiled);

    public static readonly Regex CsUnsafe = new(
        @"\bunsafe\b",
        RegexOptions.Compiled);

    public static readonly Regex CsRegistry = new(
        @"Microsoft\.Win32\.Registry|\bRegistry\.(LocalMachine|CurrentUser|ClassesRoot|Users|CurrentConfig|PerformanceData)\b|\bRegistryKey\b|HKEY_(LOCAL_MACHINE|CURRENT_USER|CLASSES_ROOT|USERS|CURRENT_CONFIG)",
        RegexOptions.Compiled);

    public static readonly Regex CsEnvironment = new(
        @"Environment\.(GetEnvironmentVariable|UserName|MachineName)",
        RegexOptions.Compiled);

    public static readonly Regex CsCrypto = new(
        @"(AesCryptoServiceProvider|RSACryptoServiceProvider|BCryptEncrypt|CryptEncrypt)",
        RegexOptions.Compiled);

    public static readonly Regex CsMarshal = new(
        @"(Marshal\.(Copy|AllocHGlobal|GetFunctionPointerForDelegate))",
        RegexOptions.Compiled);

    // VRChat context
    public static readonly Regex VrchatSdk = new(
        @"using\s+(VRC\.SDK3|UdonSharp|VRC\.Udon)",
        RegexOptions.Compiled);

    // Obfuscated identifiers (very short names, high density)
    public static readonly Regex ShortIdentifier = new(
        @"\b[a-zA-Z_][a-zA-Z0-9_]{0,1}\b",
        RegexOptions.Compiled);

    // Unicode escape sequences
    public static readonly Regex CsUnicodeEscape = new(
        @"\\u[0-9a-fA-F]{4}",
        RegexOptions.Compiled);

    /// <summary>
    /// Check if a URL's host is in the whitelist.
    /// </summary>
    public static bool IsSafeDomain(string url)
    {
        return ScannerConfig.SafeDomains.Any(d => url.Contains(d, StringComparison.OrdinalIgnoreCase));
    }
}

