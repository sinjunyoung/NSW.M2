using System.IO;
using System.Text.RegularExpressions;

namespace NSW.Core.Services;

public static class NspFileNameBuilder
{
    public static string Build(string suffix, string krName, string enName, string titleId, string displayVersion, uint titleVersion, int dlcCount)
    {
        string namePart;
        krName = SafeFileName(krName);
        enName = SafeFileName(enName);
        if (string.IsNullOrWhiteSpace(enName) || string.Equals(krName, enName, StringComparison.OrdinalIgnoreCase))
        {
            namePart = krName.Trim();
        }
        else
        {
            namePart = $"{krName} {enName}".Trim();
        }
        bool hasUpdate = displayVersion != "1.0.0";
        var tags = new List<string> { "B" };
        if (hasUpdate) tags.Add("U");
        if (dlcCount > 0) tags.Add($"{dlcCount}D");
        string tagPart = $"({string.Join("+", tags)})";
        string infoPart = $"[{titleId.ToUpper()}] {tagPart} [v{displayVersion}] [v{titleVersion}]";

        string baseName = Regex.Replace($"{namePart} {infoPart}", @"\s+", " ").Trim();

        string finalSuffix = suffix.EndsWith(".nsp", StringComparison.OrdinalIgnoreCase) ? suffix : $"{suffix}.nsp";

        return $"{baseName}_{finalSuffix}";
    }
    private static string SafeFileName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return "";
        foreach (char c in Path.GetInvalidFileNameChars())
            name = name.Replace(c, ' ');
        return name.Trim();
    }
}