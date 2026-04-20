using LibHac.Ncm;

namespace NSW.Core.Models;

public record MetadataResult(string TitleId = "", uint TitleVersion = 0, string DisplayVersion = "1.0.0", string KrTitle = "", string EnTitle = "", int DlcCount = 0, ContentMetaType Type = ContentMetaType.Application, string FileName = "")
{
    public string GetEffectiveDisplayVersion() => string.IsNullOrWhiteSpace(DisplayVersion) || DisplayVersion == "0" ? TitleVersion.ToString() : DisplayVersion;

    public string GetTypeTag() => Type switch
    {
        ContentMetaType.Application => "BASE",
        ContentMetaType.Patch => "UPDATE",
        ContentMetaType.AddOnContent => "DLC",
        ContentMetaType.Delta => "DLC",
        _ => Type.ToString().ToUpper()
    };
}