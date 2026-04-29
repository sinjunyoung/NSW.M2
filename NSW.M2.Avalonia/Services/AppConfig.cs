using System;
using System.IO;
using System.Diagnostics;

namespace NSW.M2.Avalonia.Services;

public class AppConfig
{
    private static string DefaultFilePath
    {
        get
        {
            using var process = Process.GetCurrentProcess();
            string? exePath = process.MainModule?.FileName;
            
            return Path.ChangeExtension(exePath, "config.json");
        }
    }

    private static readonly Lazy<AppConfig> _instance = new(() => Load());
    public static AppConfig Instance => _instance.Value;

    private int _compressLevel = 3;
    public int CompressLevel
    {
        get => _compressLevel;
        set => _compressLevel = (value < 0 || value > 22) ? 3 : value;
    }

    public bool VerifyCompress { get; set; } = true;

    private AppConfig() { }

    private static AppConfig Load()
    {
        string path = DefaultFilePath;
        var config = new AppConfig();

        if (!File.Exists(path))
        {
            config.Save();
            return config;
        }

        try
        {
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var trimmed = line.Trim().Replace("\"", "").Replace(",", "");
                if (trimmed.Contains("CompressLevel:"))
                    config.CompressLevel = int.Parse(trimmed.Split(':')[1].Trim());
                else if (trimmed.Contains("VerifyCompress:"))
                    config.VerifyCompress = bool.Parse(trimmed.Split(':')[1].Trim());
            }
        }
        catch
        {
            config.Save();
        }
        return config;
    }

    public void Save()
    {
        string path = DefaultFilePath;
        var content = $"{{\n" +
                      $"  \"CompressLevel\": {CompressLevel},\n" +
                      $"  \"VerifyCompress\": {VerifyCompress.ToString().ToLower()}\n" +
                      $"}}";
        File.WriteAllText(path, content);
    }
}