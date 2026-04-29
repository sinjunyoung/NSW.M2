using Avalonia.Media;
using NSW.Core.Enums;

namespace NSW.Avalonia.Services;

public class LogColor
{
    public static Color GetColor(LogLevel level)
    {
        return level switch
        {
            LogLevel.Ok => Color.FromRgb(100, 200, 100),
            LogLevel.Highlight => Color.FromRgb(255, 200, 0),
            LogLevel.Error => Color.FromRgb(255, 80, 80),
            _ => Color.FromRgb(180, 180, 180),
        }; 
    }
}