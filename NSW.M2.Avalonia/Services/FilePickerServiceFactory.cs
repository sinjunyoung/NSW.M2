using Avalonia.Platform.Storage;
using System;

namespace NSW.M2.Avalonia.Services;

public static class FilePickerServiceFactory
{
    public static Func<IStorageProvider, IFilePickerService>? Create { get; set; }
}