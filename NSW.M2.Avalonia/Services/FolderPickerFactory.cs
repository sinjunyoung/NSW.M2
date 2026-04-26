using System;

namespace NSW.M2.Avalonia.Services;

public static class FolderPickerFactory
{
    public static Func<IFolderPicker>? Create { get; set; }
}