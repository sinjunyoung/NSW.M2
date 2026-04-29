using Android.Content;
using Android.OS;
using Android.Provider;
using NSW.M2.Avalonia.Services;
using System;
using System.Linq;
using Environment = Android.OS.Environment;

namespace NSW.M2.Avalonia.Android.Services;

public class PathConverter : IPathConverter
{
    private readonly Context _context;
    private readonly string _primaryStoragePath;
    private string? _externalSdCardUuid;

    public PathConverter(Context context)
    {
        _context = context;
        _primaryStoragePath = Environment.ExternalStorageDirectory?.AbsolutePath ?? "/storage/emulated/0";
        _externalSdCardUuid = TryGetSdCardUuid();
    }

    public string UriToFriendlyPath(string path)
    {
        if (string.IsNullOrEmpty(path)) return path;

        if (!path.StartsWith("content://")) return path;

        try
        {
            var uri = global::Android.Net.Uri.Parse(path);
            var uriStr = uri.ToString();

            string resultPath;

            if (uriStr.Contains("com.android.providers.media.documents"))
                resultPath = HandleMediaDocumentUri(uri);
            else if (uriStr.Contains("com.android.externalstorage.documents"))
                resultPath = HandleExternalStorageDocumentUri(uri, uriStr);
            else if (uriStr.Contains("com.android.providers.downloads.documents"))
                resultPath = HandleDownloadsDocumentUri(uri);
            else
                resultPath = path;

            return RealPathToFriendlyPath(resultPath);
        }
        catch
        {
            return path;
        }
    }

    private string HandleMediaDocumentUri(global::Android.Net.Uri uri)
    {
        try
        {
            var docId = DocumentsContract.GetDocumentId(uri);

            var split = docId.Split(':');

            if (split.Length < 2)
                return uri.ToString();

            var type = split[0];
            var id = split[1];

            global::Android.Net.Uri? contentUri = null;

            switch (type.ToLower())
            {
                case "image":
                    contentUri = MediaStore.Images.Media.ExternalContentUri;
                    break;
                case "video":
                    contentUri = MediaStore.Video.Media.ExternalContentUri;
                    break;
                case "audio":
                    contentUri = MediaStore.Audio.Media.ExternalContentUri;
                    break;
            }

            if (contentUri != null)
            {
                var selection = "_id=?";
                var selectionArgs = new[] { id };
                var path = GetDataColumn(contentUri, selection, selectionArgs);

                if (!string.IsNullOrEmpty(path))
                    return path;
            }
            return uri.ToString();
        }
        catch
        {
            return uri.ToString();
        }
    }

    private string HandleExternalStorageDocumentUri(global::Android.Net.Uri uri, string uriStr)
    {
        try
        {
            if (!uriStr.Contains("/document/") && !uriStr.Contains("/tree/"))
                return uri.ToString();

            string docId;
            if (uriStr.Contains("/document/"))
            {
                var docStart = uriStr.LastIndexOf("/document/") + 10;
                docId = uriStr[docStart..];
            }
            else
            {
                var treeStart = uriStr.LastIndexOf("/tree/") + 6;
                docId = uriStr[treeStart..];
            }

            docId = global::Android.Net.Uri.Decode(docId);

            if (docId.Contains(':'))
            {
                var colonIndex = docId.IndexOf(':');
                var storageId = docId[..colonIndex];
                var relativePath = docId[(colonIndex + 1)..];

                if (storageId == "primary")
                    return _primaryStoragePath + "/" + relativePath;
                else
                    return $"/storage/{storageId}/{relativePath}";
            }

            return uri.ToString();
        }
        catch
        {
            return uri.ToString();
        }
    }

    private string HandleDownloadsDocumentUri(global::Android.Net.Uri uri)
    {
        try
        {
            var id = DocumentsContract.GetDocumentId(uri);

            if (id.StartsWith("raw:"))
                return id[4..];

            if (long.TryParse(id, out var numId))
            {
                var contentUri = ContentUris.WithAppendedId(
                    global::Android.Net.Uri.Parse("content://downloads/public_downloads"), numId);

                var path = GetDataColumn(contentUri, null, null);
                if (!string.IsNullOrEmpty(path))
                    return path;
            }

            return $"{_primaryStoragePath}/Download/{id}";
        }
        catch
        {
            return uri.ToString();
        }
    }

    private string? GetDataColumn(global::Android.Net.Uri uri, string? selection, string[]? selectionArgs)
    {
        try
        {
            var column = "_data";
            var projection = new[] { column };

            var cursor = _context.ContentResolver?.Query(uri, projection, selection, selectionArgs, null);

            if (cursor == null)
                return null;

            using (cursor)
            {
                if (cursor.MoveToFirst())
                {
                    var columnIndex = cursor.GetColumnIndex(column);

                    if (columnIndex == -1)
                        return null;

                    var result = cursor.GetString(columnIndex);
                    return result;
                }
            }
        }
        catch { }

        return null;
    }

    public string FriendlyPathToUri(string path)
    {
        if (string.IsNullOrEmpty(path)) return path;

        if (path.StartsWith("content://")) return path;

        if (Build.VERSION.SdkInt < BuildVersionCodes.Q) return path;

        try
        {
            path = FriendlyPathToRealPath(path);

            path = NormalizePath(path);
            var cleanPath = path.TrimStart('/');

            var (storageId, pathParts) = ParseStoragePath(cleanPath);

            if (storageId == null || pathParts == null || pathParts.Length == 0)
                return path;

            var fullPath = string.Join("/", pathParts);
            var treeId = $"{storageId}:{fullPath}";
            var encodedTreeId = global::Android.Net.Uri.Encode(treeId);
            var treeUri = $"content://com.android.externalstorage.documents/tree/{encodedTreeId}";

            if (pathParts.Length == 1)
                return treeUri;

            var documentId = $"{storageId}:{fullPath}";
            var encodedDocId = global::Android.Net.Uri.Encode(documentId);

            return $"{treeUri}/document/{encodedDocId}";
        }
        catch
        {
            return path;
        }
    }

    public string RealPathToUri(string path)
    {
        if (string.IsNullOrEmpty(path)) return path;
        if (path.StartsWith("content://")) return path;
        if (Build.VERSION.SdkInt < BuildVersionCodes.Q) return path;

        try
        {
            path = FriendlyPathToRealPath(path);

            path = NormalizePath(path);
            var cleanPath = path.TrimStart('/');

            var (storageId, pathParts) = ParseStoragePath(cleanPath);

            if (storageId == null || pathParts == null || pathParts.Length < 2)
                return path;

            var treeParts = pathParts.Take(pathParts.Length - 1);
            var treePath = string.Join("/", treeParts);
            var treeId = $"{storageId}:{treePath}";
            var encodedTreeId = global::Android.Net.Uri.Encode(treeId);
            var treeUri = $"content://com.android.externalstorage.documents/tree/{encodedTreeId}";

            var fileName = pathParts.Last();
            var documentPath = $"{treePath}/{fileName}";
            var documentId = $"{storageId}:{documentPath}";
            var encodedDocId = global::Android.Net.Uri.Encode(documentId);

            return $"{treeUri}/document/{encodedDocId}";
        }
        catch
        {
            return path;
        }
    }

    public string FriendlyPathToRealPath(string displayPath)
    {
        if (string.IsNullOrEmpty(displayPath))
            return displayPath;

        if (string.IsNullOrEmpty(_externalSdCardUuid))
            _externalSdCardUuid = TryGetSdCardUuid();

        if (string.IsNullOrEmpty(_externalSdCardUuid))
            return displayPath;

        var externalAliases = new[]
        {
                "/mnt/extSdCard/",
                "/mnt/external_sd/",
                "/storage/sdcard1/"
            };

        foreach (var alias in externalAliases)
            if (displayPath.StartsWith(alias, StringComparison.OrdinalIgnoreCase))
                return displayPath.Replace(alias, $"/storage/{_externalSdCardUuid}/");

        return displayPath;
    }

    public string RealPathToFriendlyPath(string realPath)
    {
        if (string.IsNullOrEmpty(realPath) || string.IsNullOrEmpty(_externalSdCardUuid))
            return realPath;

        var uuidPath = $"/storage/{_externalSdCardUuid}/";
        if (realPath.StartsWith(uuidPath, StringComparison.OrdinalIgnoreCase))
            return realPath.Replace(uuidPath, "/mnt/extSdCard/");

        return realPath;
    }

    private static (string? storageId, string[]? pathParts) ParseStoragePath(string cleanPath)
    {
        if (cleanPath.StartsWith("storage/emulated/"))
        {
            var parts = cleanPath.Split('/');
            if (parts.Length < 4)
                return (null, null);

            return ("primary", parts.Skip(3).ToArray());
        }
        else if (cleanPath.StartsWith("storage/") && !cleanPath.StartsWith("storage/emulated/"))
        {
            var parts = cleanPath.Split('/');
            if (parts.Length < 3)
                return (null, null);

            return (parts[1], parts.Skip(2).ToArray());
        }

        return (null, null);
    }

    private string NormalizePath(string path)
    {
        if (string.IsNullOrEmpty(path)) return path;

        var internalStorageAliases = new[]
        {
                "/sdcard/",
                "/mnt/sdcard/",
                "/storage/sdcard0/",
                "/storage/emulated/legacy/",
                "/data/media/0/"
            };

        foreach (var alias in internalStorageAliases)
            if (path.StartsWith(alias, StringComparison.OrdinalIgnoreCase))
                return path.Replace(alias, _primaryStoragePath + "/");

        return path;
    }

    private string? TryGetSdCardUuid()
    {
        try
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                var externalDirs = _context.GetExternalFilesDirs(null);
                if (externalDirs != null && externalDirs.Length > 1)
                {
                    var sdCardPath = externalDirs[1]?.AbsolutePath;
                    if (!string.IsNullOrEmpty(sdCardPath))
                    {
                        var parts = sdCardPath.Split('/');
                        if (parts.Length > 2 && parts[1] == "storage")
                            return parts[2];
                    }
                }
            }
        }
        catch { }

        return null;
    }
}