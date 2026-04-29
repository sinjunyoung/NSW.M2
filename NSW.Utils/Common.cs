using System.Diagnostics;

namespace NSW.Utils;

public static class Common
{
    public static string FormatFileSize(long bytes)
    {
        if (bytes >= 1_073_741_824) return $"{bytes / 1_073_741_824.0:F1} GB";
        if (bytes >= 1_048_576) return $"{bytes / 1_048_576.0:F1} MB";
        return $"{bytes / 1024.0:F1} KB";
    }

    public static (int pct, string label, double currentMiB, double totalMiB) CalculateProgress(long readBytes, long totalBytes, string label)
    {
        double currentMiB = (double)readBytes / 1024 / 1024;
        double totalMiB = (double)totalBytes / 1024 / 1024;

        int pct = totalBytes > 0 ? Math.Min(100, (int)((double)readBytes / totalBytes * 100)): 0;
        string formattedLabel = $"{label} {currentMiB:N0}MiB / {totalMiB:N2}MiB";

        return (pct, formattedLabel, currentMiB, totalMiB);
    }

    public static string ToAppVersionString()
    {
        string processPath = Environment.ProcessPath ?? string.Empty;
        var info = FileVersionInfo.GetVersionInfo(processPath);
        DateTime buildDate = File.GetLastWriteTime(processPath);

        return $"{info.ProductMajorPart}.{info.ProductMinorPart}.{info.ProductPrivatePart} (Build: {buildDate:yyyy'/'MM'/'dd})";
    }

    public static string GetUniqueFilePath(string filePath)
    {
        string directory = Path.GetDirectoryName(filePath);
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath);

        while (File.Exists(filePath))
        {
            fileName += "_";
            filePath = Path.Combine(directory, fileName + extension);
        }

        return filePath;
    }
}
