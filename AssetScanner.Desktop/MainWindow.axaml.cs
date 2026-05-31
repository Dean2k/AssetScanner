using System;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using AssetScanner.Desktop.ViewModels;

namespace AssetScanner.Desktop;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel = new();
    private IBrush? _originalDropBorderBrush;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;

        // Enable drag-and-drop on the window (attached property in Avalonia 12)
        DragDrop.SetAllowDrop(this, true);

        // Tunnel + Bubble so we catch events regardless of which child the mouse is over
        AddHandler(DragDrop.DragOverEvent, OnDragOver, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        AddHandler(DragDrop.DragLeaveEvent, OnDragLeave, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        AddHandler(DragDrop.DropEvent, OnDrop, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);

        // Warn the user if running elevated — drag-and-drop from Explorer won't work
        if (IsElevated())
        {
            _viewModel.StatusText = "WARNING: Running as Administrator — drag-and-drop from Explorer is blocked by Windows. Use Browse File instead.";
        }
    }

    private void OnBrowseClick(object? sender, RoutedEventArgs e)
    {
        _ = _viewModel.PickAndScanFileAsync(this);
    }

    private void OnUpdateDbClick(object? sender, RoutedEventArgs e)
    {
        _ = _viewModel.UpdateThreatDbAsync();
    }

    private void OnComputeHashesClick(object? sender, RoutedEventArgs e)
    {
        _ = _viewModel.GenerateWhitelistHashesAsync(this);
    }

    private void OnScoreCardClick(object? sender, RoutedEventArgs e)
    {
        _viewModel.ShowDetailView();
    }

    private void OnBackToSummaryClick(object? sender, RoutedEventArgs e)
    {
        _viewModel.HideDetailView();
    }

    private void OnDragOver(object? sender, DragEventArgs e)
    {
        if (e.DataTransfer.Formats.Contains(DataFormat.File))
        {
            e.DragEffects = DragDropEffects.Copy;
            HighlightDropBorder();
        }
        else
        {
            e.DragEffects = DragDropEffects.None;
        }
        e.Handled = true;
    }

    private void OnDragLeave(object? sender, RoutedEventArgs e)
    {
        RestoreDropBorder();
        e.Handled = true;
    }

    private async void OnDrop(object? sender, DragEventArgs e)
    {
        RestoreDropBorder();

        if (!e.DataTransfer.Formats.Contains(DataFormat.File))
        {
            e.Handled = true;
            return;
        }

        var files = e.DataTransfer.TryGetFiles()?.ToList();
        if (files is null || files.Count == 0)
        {
            e.Handled = true;
            return;
        }

        var file = files[0];
        var path = file.TryGetLocalPath();
        if (string.IsNullOrEmpty(path))
        {
            e.Handled = true;
            return;
        }

        await _viewModel.ScanAsync(path);
        e.Handled = true;
    }

    private void HighlightDropBorder()
    {
        if (DropZoneBorder is null) return;
        _originalDropBorderBrush ??= DropZoneBorder.BorderBrush;
        DropZoneBorder.BorderBrush = new SolidColorBrush(Color.Parse("#3b82f6"));
    }

    private void RestoreDropBorder()
    {
        if (DropZoneBorder is null || _originalDropBorderBrush is null) return;
        DropZoneBorder.BorderBrush = _originalDropBorderBrush;
    }

    private static bool IsElevated()
    {
        if (!OperatingSystem.IsWindows()) return false;

        try
        {
            using var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        catch
        {
            return false;
        }
    }
}
