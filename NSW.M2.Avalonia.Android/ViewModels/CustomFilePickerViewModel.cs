using Android.OS;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using NSW.M2.Avalonia.Android.Enums;
using NSW.M2.Avalonia.Android.Models;
using NSW.M2.Avalonia.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Android.ViewModels;

public class CustomFilePickerViewModel(IStorageProvider storageProvider, string[] extensions, string title, string? initialDirectory = null) : ViewModelBase
{
    private readonly IStorageProvider _storageProvider = storageProvider;
    private string? _currentPath;
    private readonly string[] _extensions = extensions;
    private bool _isLoading;
    private readonly string _initialDirectory = !string.IsNullOrEmpty(initialDirectory)
        ? initialDirectory
        : global::Android.OS.Environment.ExternalStorageDirectory?.AbsolutePath
          ?? "/storage/emulated/0";
    private CancellationTokenSource? _loadCancellation;
    private string? _sdCardUuid;
    public string SelectedFilesText => SelectedFiles.Count == 0 ? "Select files" : $"{SelectedFiles.Count} items selected";


    public RangeObservableCollection<FileItem> Files { get; } = [];

    public ObservableCollection<BreadcrumbItem> BreadcrumbPaths { get; } = [];

    public string? CurrentPath
    {
        get => _currentPath;
        set => this.RaiseAndSetIfChanged(ref _currentPath, value);
    }

    public ObservableCollection<FileItem> SelectedFiles { get; } = [];

    public bool IsLoading
    {
        get => _isLoading;
        set => this.RaiseAndSetIfChanged(ref _isLoading, value);
    }

    public string Title { get; set; } = title;

    public async Task InitializeAsync()
    {
        _sdCardUuid = await Task.Run(() => TryGetSdCardUuid());
        await LoadFolderAsync(_initialDirectory);
    }

    private static string? TryGetSdCardUuid()
    {
        try
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                var context = global::Android.App.Application.Context;
                var externalDirs = context.GetExternalFilesDirs(null);

                if (externalDirs != null && externalDirs.Length > 1)
                {
                    var sdCardPath = externalDirs[1]?.AbsolutePath;
                    if (!string.IsNullOrEmpty(sdCardPath))
                    {
                        var parts = sdCardPath.Split('/');
                        if (parts.Length > 2 && parts[1] == "storage")
                        {
                            var uuid = parts[2];
                            return uuid;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to get SD card UUID: {ex.Message}");
        }

        return null;
    }

    public async Task LoadFolderAsync(string path)
    {
        _loadCancellation?.Cancel();
        _loadCancellation = new CancellationTokenSource();
        var token = _loadCancellation.Token;

        IsLoading = true;

        try
        {
            CurrentPath = path;
            UpdateBreadcrumb(path);

            var itemsToAdd = await Task.Run(() =>
            {
                var items = new System.Collections.Generic.List<FileItem>();

                if (token.IsCancellationRequested) return items;

                try
                {
                    if (!Directory.Exists(path))
                        return items;

                    var parentPath = Path.GetDirectoryName(path);
                    if (!string.IsNullOrEmpty(parentPath))
                    {
                        items.Add(new FileItem
                        {
                            Name = "..",
                            FullPath = parentPath,
                            IsDirectory = true,
                            IsParentDirectory = true,
                            IconType = FileIconType.Parent
                        });
                    }

                    var directories = Directory.GetDirectories(path);

                    foreach (var dir in directories.OrderBy(d => Path.GetFileName(d)))
                    {
                        if (token.IsCancellationRequested) return items;

                        var dirName = Path.GetFileName(dir);

                        if (dirName.Equals("self", StringComparison.OrdinalIgnoreCase))
                            continue;

                        var displayName = GetStorageDisplayName(dir, dirName);

                        items.Add(new FileItem
                        {
                            Name = displayName,
                            FullPath = dir,
                            IsDirectory = true,
                            IconType = GetStorageIconType(dir, dirName)
                        });
                    }

                    if (token.IsCancellationRequested) return items;

                    var files = Directory.GetFiles(path)
                        .Where(f => _extensions.Length == 0 ||
                                   _extensions.Any(ext => f.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                        .Select(f =>
                        {
                            var fileInfo = new FileInfo(f);
                            return new FileItem
                            {
                                Name = Path.GetFileName(f),
                                FullPath = f,
                                IsDirectory = false,
                                Size = fileInfo.Length,
                                ModifiedDate = fileInfo.LastWriteTime,
                                IconType = FileItem.GetIconTypeFromExtension(f)
                            };
                        })
                        .OrderBy(f => f.Name);

                    items.AddRange(files);

                    return items;
                }
                catch (UnauthorizedAccessException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Access denied to {path}: {ex.Message}");
                    return items;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error loading folder {path}: {ex.Message}");
                    return items;
                }
            }, token);

            if (!token.IsCancellationRequested)
                Files.ReplaceAll(itemsToAdd);
        }
        catch (System.OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"LoadFolderAsync error: {ex}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private string GetStorageDisplayName(string fullPath, string dirName)
    {
        if (!fullPath.StartsWith("/storage/") || fullPath.Count(c => c == '/') > 2)
            return dirName;

        if (dirName.Equals("emulated", StringComparison.OrdinalIgnoreCase))
            return "Internal Storage";

        if (!string.IsNullOrEmpty(_sdCardUuid) && dirName.Equals(_sdCardUuid, StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                var context = global::Android.App.Application.Context;

                if (context.GetSystemService(global::Android.Content.Context.StorageService) is global::Android.OS.Storage.StorageManager storageManager)
                {
                    var storageVolume = storageManager.GetStorageVolume(new Java.IO.File(fullPath));
                    var volumeName = storageVolume?.GetDescription(context);

                    if (!string.IsNullOrEmpty(volumeName))
                        return volumeName;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to get volume name: {ex.Message}");
            }

            return "SD Card";
        }

        return dirName;
    }

    private FileIconType GetStorageIconType(string fullPath, string dirName)
    {
        if (!fullPath.StartsWith("/storage/") || fullPath.Count(c => c == '/') > 2)
            return FileIconType.Folder;

        if (dirName.Equals("emulated", StringComparison.OrdinalIgnoreCase))
            return FileIconType.InternalStorage;

        if (!string.IsNullOrEmpty(_sdCardUuid) && dirName.Equals(_sdCardUuid, StringComparison.OrdinalIgnoreCase))
            return FileIconType.SdCard;

        return FileIconType.Folder;
    }

    private readonly ConcurrentDictionary<string, bool> _loadingItems = new();

    public async Task LoadThumbnailForItem(FileItem item)
    {
        if (item.Thumbnail != null || item.IsDirectory) return;
        if (!item.IsImage && !item.IsVideo) return;

        if (!_loadingItems.TryAdd(item.FullPath, true))
            return;

        try
        {
            await Task.Run(() =>
            {
                Bitmap? thumbnail = null;

                if (item.IsImage)
                    thumbnail = LoadImageThumbnail(item.FullPath);
                else if (item.IsVideo)
                    thumbnail = LoadVideoThumbnail(item.FullPath);

                if (thumbnail != null)
                    global::Avalonia.Threading.Dispatcher.UIThread.Post(() => item.Thumbnail = thumbnail);
            });
        }
        finally
        {
            _loadingItems.TryRemove(item.FullPath, out _);
        }
    }

    private void UpdateBreadcrumb(string path)
    {
        BreadcrumbPaths.Clear();

        var parts = path.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

        var currentPath = string.Empty;

        foreach (var part in parts)
        {
            if (string.IsNullOrEmpty(currentPath))
                currentPath = "/" + part;
            else
                currentPath = currentPath + "/" + part;

            var displayName = part;

            if (currentPath == "/storage/emulated")
                displayName = "Internal Storage";
            else if (!string.IsNullOrEmpty(_sdCardUuid) &&
                     currentPath.StartsWith("/storage/") &&
                     currentPath.Count(c => c == '/') == 2 &&
                     part.Equals(_sdCardUuid, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var context = global::Android.App.Application.Context;

                    if (context.GetSystemService(global::Android.Content.Context.StorageService) is global::Android.OS.Storage.StorageManager storageManager)
                    {
                        var storageVolume = storageManager.GetStorageVolume(new Java.IO.File(currentPath));
                        var volumeName = storageVolume?.GetDescription(context);

                        if (!string.IsNullOrEmpty(volumeName))
                            displayName = volumeName;
                        else
                            displayName = "SD Card";
                    }
                    else
                        displayName = "SD Card";
                }
                catch
                {
                    displayName = "SD Card";
                }
            }

            BreadcrumbPaths.Add(new BreadcrumbItem
            {
                Name = displayName,
                FullPath = currentPath
            });
        }
    }

    public async Task OnItemTapped(FileItem item)
    {
        if (item.IsDirectory)
        {
            var targetPath = item.FullPath;
            if (targetPath == "/storage/emulated")
                targetPath = "/storage/emulated/0";
            await LoadFolderAsync(targetPath);
        }
        else
        {
            if (SelectedFiles.Contains(item))
                SelectedFiles.Remove(item);
            else
                SelectedFiles.Add(item);
            this.RaisePropertyChanged(nameof(SelectedFilesText));
        }
    }

    public List<string> GetSelectedFilePaths()
        => [.. SelectedFiles.Where(f => !f.IsDirectory).Select(f => f.FullPath)];

    public async Task OnBreadcrumbTapped(BreadcrumbItem item)
    {
        var targetPath = item.FullPath;

        if (targetPath == "/storage/emulated")
            targetPath = "/storage/emulated/0";

        await LoadFolderAsync(targetPath);
    }


    private static Bitmap? LoadImageThumbnail(string imagePath)
    {
        try
        {
            var options = new global::Android.Graphics.BitmapFactory.Options
            {
                InJustDecodeBounds = true
            };

            global::Android.Graphics.BitmapFactory.DecodeFile(imagePath, options);

            var sampleSize = CalculateInSampleSize(options, 80, 80);
            options.InSampleSize = sampleSize;
            options.InJustDecodeBounds = false;

            using var bitmap = global::Android.Graphics.BitmapFactory.DecodeFile(imagePath, options);

            if (bitmap == null) return null;

            using var resized = global::Android.Graphics.Bitmap.CreateScaledBitmap(bitmap, 80, 80, true);
            using var stream = new MemoryStream();
            resized.Compress(global::Android.Graphics.Bitmap.CompressFormat.Png, 85, stream);

            var bytes = stream.ToArray();

            return new Bitmap(new MemoryStream(bytes));
        }
        catch
        {
            return null;
        }
    }

    private static Bitmap? LoadVideoThumbnail(string videoPath)
    {
        global::Android.Media.MediaMetadataRetriever? retriever = null;

        try
        {
            retriever = new global::Android.Media.MediaMetadataRetriever();
            retriever.SetDataSource(videoPath);

            var mimeType = retriever.ExtractMetadata(global::Android.Media.MetadataKey.Mimetype);

            if (mimeType != null && mimeType.Contains("hevc", StringComparison.OrdinalIgnoreCase))
                return null;

            var durationStr = retriever.ExtractMetadata(global::Android.Media.MetadataKey.Duration);
            long durationMs = 0;
            if (!string.IsNullOrEmpty(durationStr))
                _ = long.TryParse(durationStr, out durationMs);

            long[] timePoints = [10000000, 5000000, 1000000, 0];
            global::Android.Graphics.Bitmap? bitmap = null;

            foreach (var time in timePoints)
            {
                if (durationMs > 0 && time > durationMs * 1000)
                    continue;

                bitmap = retriever.GetFrameAtTime(time, global::Android.Media.Option.ClosestSync);
                if (bitmap != null)
                    break;
            }

            if (bitmap == null)
                return null;

            using (bitmap)
            {
                using var resized = global::Android.Graphics.Bitmap.CreateScaledBitmap(bitmap, 80, 80, true);

                using var mutableBitmap = resized.Copy(global::Android.Graphics.Bitmap.Config.Argb8888, true);

                if (mutableBitmap == null)
                    return null;

                using var canvas = new global::Android.Graphics.Canvas(mutableBitmap);
                using var paint = new global::Android.Graphics.Paint { AntiAlias = true };

                paint.Color = global::Android.Graphics.Color.Argb(180, 0, 0, 0);
                canvas.DrawCircle(40f, 40f, 15f, paint);

                paint.Color = global::Android.Graphics.Color.White;
                var path = new global::Android.Graphics.Path();
                path.MoveTo(37f, 32f);
                path.LineTo(37f, 48f);
                path.LineTo(48f, 40f);
                path.Close();
                canvas.DrawPath(path, paint);

                using var stream = new MemoryStream();
                mutableBitmap.Compress(global::Android.Graphics.Bitmap.CompressFormat.Png, 85, stream);
                var bytes = stream.ToArray();

                return new Bitmap(new MemoryStream(bytes));
            }
        }
        catch
        {
            return null;
        }
        finally
        {
            retriever?.Release();
            retriever?.Dispose();
        }
    }

    private static int CalculateInSampleSize(global::Android.Graphics.BitmapFactory.Options options, int reqWidth, int reqHeight)
    {
        var height = options.OutHeight;
        var width = options.OutWidth;
        var inSampleSize = 1;

        if (height > reqHeight || width > reqWidth)
        {
            var halfHeight = height / 2;
            var halfWidth = width / 2;

            while (halfHeight / inSampleSize >= reqHeight && halfWidth / inSampleSize >= reqWidth)
                inSampleSize *= 2;
        }

        return inSampleSize;
    }
}