namespace NSW.M2.Services;

public sealed record BuildRequest(string BaseFilePath, string UpdateFilePath, IReadOnlyList<string> DlcFilePaths, string OutputDir)
{
       public bool CompressToNcz { get; set; } = true;
       public int  NczCompressionLevel { get; set; } = 18;     // 1~22
       public byte NczBlockSizeExponent { get; set; } = 17;   // 2^17 = 128KB
}