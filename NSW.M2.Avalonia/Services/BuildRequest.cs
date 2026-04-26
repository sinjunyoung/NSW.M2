using System.Collections.Generic;
using NSW.Core.Models;

namespace NSW.M2.Avalonia.Services;

public sealed record BuildRequest(string BaseFilePath, string UpdateFilePath, IReadOnlyList<string> DlcFilePaths, string OutputDir)
{
    public bool CompressToNcz { get; set; } = true;

    public int NczCompressionLevel { get; set; } = 18;

    public byte NczBlockSizeExponent { get; set; } = 17;

    public IReadOnlyList<string>? AllSourcePaths { get; set; }

    public HashSet<string>? AllowedNcaIds { get; set; }

    public string? TargetBaseTitleId { get; set; }

    public MetadataResult? ResolvedMeta { get; set; }
}