using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using AssetScanner.Config;
using AssetScanner.Ingestion;
using AssetScanner.Models;
using AssetScanner.Pipeline;
using AssetScanner.Reporting;
using AssetScanner.ThreatIntel;

namespace AssetScanner.Desktop.ViewModels;

public sealed class MainViewModel : INotifyPropertyChanged
{
    private string _statusText = "Drag a .unitypackage, .zip, folder, .cs, or .dll here, or click to browse";
    private bool _isScanning;
    private bool _isUpdatingDb;
    private bool _isDetailViewVisible;
    private ScanReport? _report;
    private string? _errorMessage;
    private string _dbStatus = "Threat DB: not loaded";

    private readonly ThreatDatabase _threatDb;

    public MainViewModel()
    {
        _threatDb = new ThreatDatabase();
        ScanPipeline.ThreatDatabase = _threatDb;

        // Try to load existing cached database in background
        _ = Task.Run(() =>
        {
            try
            {
                _threatDb.Load();
                var stats = _threatDb.GetStats();
                DbStatus = $"Threat DB: {stats.MalwareHashes:N0} hashes, {stats.MaliciousDomains:N0} domains, {stats.MaliciousIps:N0} IPs";
            }
            catch
            {
                DbStatus = "Threat DB: not loaded — click Update DB to download";
            }
        });
    }

    public string StatusText
    {
        get => _statusText;
        set => SetField(ref _statusText, value);
    }

    public string DbStatus
    {
        get => _dbStatus;
        set => SetField(ref _dbStatus, value);
    }

    public bool IsScanning
    {
        get => _isScanning;
        set => SetField(ref _isScanning, value);
    }

    public bool IsUpdatingDb
    {
        get => _isUpdatingDb;
        set => SetField(ref _isUpdatingDb, value);
    }

    public bool IsDetailViewVisible
    {
        get => _isDetailViewVisible;
        set => SetField(ref _isDetailViewVisible, value);
    }

    public bool HasReport => _report is not null;
    public bool HasError => !string.IsNullOrEmpty(_errorMessage);

    public ScanReport? Report
    {
        get => _report;
        private set
        {
            _report = value;
            OnPropertyChanged(nameof(Report));
            OnPropertyChanged(nameof(HasReport));
        }
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
            OnPropertyChanged(nameof(HasError));
        }
    }

    public ObservableCollection<FindingGroup> GroupedFindings { get; } = new();
    public ObservableCollection<FileTypeGroup> FileGroups { get; } = new();

    public void ToggleDetailView()
    {
        IsDetailViewVisible = !IsDetailViewVisible;
    }

    public void ShowDetailView()
    {
        IsDetailViewVisible = true;
    }

    public void HideDetailView()
    {
        IsDetailViewVisible = false;
    }

    public async Task UpdateThreatDbAsync()
    {
        IsUpdatingDb = true;
        DbStatus = "Downloading threat intel...";

        try
        {
            await _threatDb.UpdateAsync();
            var stats = _threatDb.GetStats();
            DbStatus = $"Threat DB: {stats.MalwareHashes:N0} hashes, {stats.MaliciousDomains:N0} domains, {stats.MaliciousIps:N0} IPs";
        }
        catch (Exception ex)
        {
            DbStatus = $"Threat DB update failed: {ex.Message}";
        }
        finally
        {
            IsUpdatingDb = false;
        }
    }

    public async Task PickAndScanFileAsync(TopLevel topLevel)
    {
        var options = new FilePickerOpenOptions
        {
            Title = "Select a package or file to scan",
            AllowMultiple = false,
            FileTypeFilter = new List<FilePickerFileType>
            {
                new("Unity Packages & Archives") { Patterns = new[] { "*.unitypackage", "*.zip", "*.cs", "*.dll" } },
                new("All Files") { Patterns = new[] { "*" } },
            }
        };

        var result = await topLevel.StorageProvider.OpenFilePickerAsync(options);
        var file = result.FirstOrDefault();
        if (file is null) return;

        var path = file.TryGetLocalPath();
        if (string.IsNullOrEmpty(path)) return;

        await ScanAsync(path);
    }

    public async Task<string?> GenerateWhitelistHashesAsync(TopLevel topLevel)
    {
        StatusText = "Select a folder or .unitypackage to generate whitelist hashes from...";
        try
        {
            var options = new FilePickerOpenOptions
            {
                Title = "Select a known-good package folder or .unitypackage",
                AllowMultiple = false,
                FileTypeFilter = new List<FilePickerFileType>
                {
                    new("Unity Package") { Patterns = new[] { "*.unitypackage" } },
                    new("All Files") { Patterns = new[] { "*" } },
                }
            };

            var result = await topLevel.StorageProvider.OpenFilePickerAsync(options);
            var file = result.FirstOrDefault();
            if (file is null)
            {
                StatusText = "Hash generation cancelled.";
                return null;
            }

            var path = file.TryGetLocalPath();
            if (string.IsNullOrEmpty(path))
            {
                StatusText = "Hash generation cancelled.";
                return null;
            }

            var packageName = Path.GetFileNameWithoutExtension(path);
            StatusText = $"Generating whitelist hashes for {packageName}...";

            string generatedCode;
            if (Directory.Exists(path))
            {
                generatedCode = await Task.Run(() =>
                {
                    var drafts = WhitelistHashGenerator.GenerateFromFolder(path, packageName);
                    return WhitelistHashGenerator.FormatAsCode(drafts, packageName);
                });
            }
            else
            {
                // Treat as .unitypackage or archive
                generatedCode = await Task.Run(() =>
                {
                    var tree = UnityPackageExtractor.Extract(path);
                    var drafts = WhitelistHashGenerator.GenerateFromTree(tree, packageName);
                    return WhitelistHashGenerator.FormatAsCode(drafts, packageName);
                });
            }

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var outFile = Path.Combine(desktop, $"Whitelist_{packageName}_{DateTime.Now:yyyyMMdd_HHmmss}.cs");
            await File.WriteAllTextAsync(outFile, generatedCode);

            StatusText = $"Whitelist saved to: {outFile}";
            return outFile;
        }
        catch (Exception ex)
        {
            StatusText = "Hash generation failed.";
            ErrorMessage = ex.Message;
            return null;
        }
    }

    public async Task ScanAsync(string path)
    {
        IsScanning = true;
        IsDetailViewVisible = false;
        StatusText = $"Scanning: {Path.GetFileName(path)}...";
        ErrorMessage = null;
        Report = null;
        GroupedFindings.Clear();
        FileGroups.Clear();

        try
        {
            var report = await Task.Run(() => ScanPipeline.RunScan(path));
            Report = report;

            if (!string.IsNullOrEmpty(report.Error))
            {
                ErrorMessage = report.Error;
            }
            else
            {
                var groups = report.Findings
                    .GroupBy(f => f.Severity)
                    .OrderByDescending(g => SeverityOrder(g.Key));

                foreach (var g in groups)
                {
                    GroupedFindings.Add(new FindingGroup(g.Key, g.ToList()));
                }

                // Build per-file detail list grouped by asset type
                var findingsByLocation = report.Findings
                    .GroupBy(f => f.Location)
                    .ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);

                var typeGroups = report.Assets
                    .Select(a =>
                    {
                        var findings = findingsByLocation.TryGetValue(a.Path, out var f) ? f : new List<ReportFinding>();
                        return new ScannedFileDetail(a, findings);
                    })
                    .GroupBy(d => d.Type)
                    .OrderBy(g => g.Key);

                foreach (var tg in typeGroups)
                {
                    FileGroups.Add(new FileTypeGroup(tg.Key, tg.ToList()));
                }

                StatusText = $"Scan complete: {report.RiskLevelLabel} — {report.Score} pts — {report.TotalFindings} finding(s)";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            StatusText = "Scan failed.";
        }
        finally
        {
            IsScanning = false;
        }
    }

    private static int SeverityOrder(string severity) => severity switch
    {
        "CRITICAL" => 4,
        "HIGH" => 3,
        "MEDIUM" => 2,
        "LOW" => 1,
        _ => 0,
    };

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}

public sealed class FindingGroup
{
    public string Severity { get; }
    public List<ReportFinding> Items { get; }

    public FindingGroup(string severity, List<ReportFinding> items)
    {
        Severity = severity;
        Items = items;
    }
}

public sealed class FileTypeGroup
{
    public string Type { get; }
    public int FileCount { get; }
    public int TotalFindings { get; }
    public List<ScannedFileDetail> Files { get; }

    public FileTypeGroup(string type, List<ScannedFileDetail> files)
    {
        Type = type;
        Files = files;
        FileCount = files.Count;
        TotalFindings = files.Sum(f => f.FindingCount);
    }
}

public sealed class ScannedFileDetail
{
    public string Path { get; }
    public string Type { get; }
    public string Size { get; }
    public string StatusText { get; }
    public string StatusColor { get; }
    public int FindingCount { get; }
    public List<ReportFinding> Findings { get; }

    public ScannedFileDetail(ReportAsset asset, List<ReportFinding> findings)
    {
        Path = asset.Path;
        Type = asset.Type;
        Size = FormatBytes(asset.SizeBytes);
        FindingCount = findings.Count;
        Findings = findings;

        if (FindingCount == 0)
        {
            StatusText = "Clean";
            StatusColor = "#22c55e"; // green
        }
        else
        {
            var worst = findings.OrderByDescending(f => SeverityValue(f.Severity)).First();
            StatusText = $"{FindingCount} finding(s)";
            StatusColor = worst.Severity switch
            {
                "CRITICAL" => "#ef4444",
                "HIGH" => "#f97316",
                "MEDIUM" => "#eab308",
                "LOW" => "#3b82f6",
                _ => "#94a3b8",
            };
        }
    }

    private static int SeverityValue(string severity) => severity switch
    {
        "CRITICAL" => 4,
        "HIGH" => 3,
        "MEDIUM" => 2,
        "LOW" => 1,
        _ => 0,
    };

    private static string FormatBytes(int bytes)
    {
        if (bytes < 1024) return $"{bytes} B";
        if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
        if (bytes < 1024 * 1024 * 1024) return $"{bytes / (1024.0 * 1024.0):F1} MB";
        return $"{bytes / (1024.0 * 1024.0 * 1024.0):F2} GB";
    }
}
