namespace NSW.M2.Avalonia.Services;

public interface IPathConverter
{
    string UriToFriendlyPath(string path);

    string FriendlyPathToUri(string path);

    string FriendlyPathToRealPath(string displayPath);

    string RealPathToFriendlyPath(string realPath);
}