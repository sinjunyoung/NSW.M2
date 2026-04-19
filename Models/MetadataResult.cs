namespace NSW.Core.Models;

public record MetadataResult
(
    string TitleId,
    uint TitleVersion,
    string DisplayVersion,
    string KrTitle,
    string EnTitle,
    int DlcCount
);