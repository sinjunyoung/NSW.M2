using System.Text.RegularExpressions;

namespace NSW.Utils;

public static class NspNameBuilder
{
    public static string FileNameBuild(string suffix, string krName, string enName, string titleId, string displayVersion, uint titleVersion, int dlcCount, bool compressed = false)
    {
        string namePart;
        krName = SafeFileName(krName);
        enName = SafeFileName(enName);
        if (string.IsNullOrWhiteSpace(enName) || string.Equals(krName, enName, StringComparison.OrdinalIgnoreCase))
            namePart = krName.Trim();
        else
            namePart = $"{krName} {enName}".Trim();

        string cleanVersion = NormalizeVersion(displayVersion);
        bool hasUpdate = cleanVersion != "1.0.0";

        var tags = new List<string> { "B" };
        if (hasUpdate) tags.Add("U");
        if (dlcCount > 0) tags.Add($"{dlcCount}D");
        string tagPart = $"({string.Join("+", tags)})";

        string infoPart = $"[{titleId.ToUpper()}] {tagPart} [v{cleanVersion}] [v{titleVersion}]";
        string baseName = Regex.Replace($"{namePart} {infoPart}", @"\s+", " ").Trim();

        string ext = compressed ? "nsz" : "nsp";
        string finalSuffix = suffix.EndsWith(".nsp", StringComparison.OrdinalIgnoreCase) || suffix.EndsWith(".nsz", StringComparison.OrdinalIgnoreCase)
            ? suffix
            : $"{suffix}.{ext}";

        return $"{baseName}_{finalSuffix}";
    }

    public static string DisplayNameBuild(string enName, string titleId, string displayVersion, int dlcCount, bool compressed)
    {
        enName = SafeFileName(enName);
        string cleanVersion = NormalizeVersion(displayVersion);

        bool hasUpdate = cleanVersion != "1.0.0";
        var tags = new List<string> { "B" };
        if (hasUpdate) tags.Add("U");
        if (dlcCount > 0) tags.Add($"{dlcCount}D");
        string tagPart = $"({string.Join("+", tags)})";
        string infoPart = $"[{titleId.ToUpper()}] {tagPart} [v{cleanVersion}]";
        string baseName = Regex.Replace($"{enName} {infoPart}", @"\s+", " ").Trim();
        string ext = compressed ? "nsz" : "nsp";

        return $"{baseName}.{ext}";
    }

    public static string DisplayNameBuild(string enName, string titleId, string displayVersion)
    {
        enName = SafeFileName(enName);
        string cleanVersion = NormalizeVersion(displayVersion);

        string infoPart = $"[{titleId.ToUpper()}] [v{cleanVersion}]";
        string baseName = Regex.Replace($"{enName} {infoPart}", @"\s+", " ").Trim();

        return $"{baseName}.nsp";
    }

    public static string CompressDisplayNameBuild(string krName, string titleId, string displayVersion)
    {
        krName = SafeFileName(krName);
        string cleanVersion = NormalizeVersion(displayVersion);

        string infoPart = $"[{titleId.ToUpper()}] [v{cleanVersion}]";

        return Regex.Replace($"{krName} {infoPart}", @"\s+", " ").Trim();
    }

    private static string NormalizeVersion(string version)
    {
        if (string.IsNullOrWhiteSpace(version)) return "1.0.0";
        version = version.Trim();
        if (version.StartsWith("v", StringComparison.OrdinalIgnoreCase))
        {
            return version.Substring(1).Trim();
        }
        return version;
    }

    private static string SafeFileName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return "";

        var invalidChars = Path.GetInvalidFileNameChars()
            .Concat([':', '*', '?', '"', '<', '>', '|', '\\', '/'])
            .Distinct()
            .ToArray();

        foreach (char c in invalidChars)
            name = name.Replace(c, ' ');

        return name.Trim();
    }
}