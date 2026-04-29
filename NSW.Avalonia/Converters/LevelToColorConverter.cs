using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace NSW.Avalonia.Converters;

public class LevelToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double level)
        {
            if (level <= 18)
            {
                double t = level / 18.0;
                byte r = (byte)(255 * t);
                return new SolidColorBrush(new Color(255, r, 255, 0));
            }
            else
            {
                double t = (level - 18) / 4.0;
                byte g = (byte)(255 * (1.0 - t));
                return new SolidColorBrush(new Color(255, 255, g, 0));
            }
        }
        return Brushes.White;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}