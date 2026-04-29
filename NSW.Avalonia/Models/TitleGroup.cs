using NSW.Core.Models;
using System.Collections.Generic;

namespace NSW.Avalonia.Models;

public sealed class TitleGroup(string baseTitleId)
{
    public string BaseTitleId { get; } = baseTitleId;
    public List<MetadataResult> BaseMetas { get; } = [];
    public List<MetadataResult> PatchMetas { get; } = [];
    public List<MetadataResult> DlcMetas { get; } = [];
}