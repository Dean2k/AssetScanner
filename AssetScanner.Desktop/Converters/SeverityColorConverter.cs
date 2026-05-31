using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace AssetScanner.Desktop.Converters;

public sealed class SeverityColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var str = value?.ToString()?.ToUpperInvariant() ?? "";
        return str switch
        {
            "CRITICAL" => new SolidColorBrush(Color.Parse("#ef4444")),
            "HIGH" => new SolidColorBrush(Color.Parse("#f97316")),
            "MEDIUM" => new SolidColorBrush(Color.Parse("#eab308")),
            "LOW" => new SolidColorBrush(Color.Parse("#94a3b8")),
            _ => new SolidColorBrush(Color.Parse("#64748b")),
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

