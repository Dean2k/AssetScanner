using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace AssetScanner.Desktop.Converters;

public sealed class RiskLevelColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var str = value?.ToString()?.ToUpperInvariant() ?? "";
        return str switch
        {
            "CLEAN" => new SolidColorBrush(Color.Parse("#22c55e")),
            "LOW" => new SolidColorBrush(Color.Parse("#84cc16")),
            "MEDIUM" => new SolidColorBrush(Color.Parse("#eab308")),
            "HIGH" => new SolidColorBrush(Color.Parse("#f97316")),
            "CRITICAL" => new SolidColorBrush(Color.Parse("#ef4444")),
            _ => new SolidColorBrush(Color.Parse("#94a3b8")),
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

