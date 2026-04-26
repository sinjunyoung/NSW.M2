using LibHac.Common.Keys;

namespace NSW.Core;

public sealed class KeySetProvider
{
    const string KeyFileName = "prod.keys";
    private static readonly Lazy<KeySetProvider> _instance = new(() => new KeySetProvider());

    public static KeySetProvider Instance => _instance.Value;

    public KeySet KeySet { get; }

    private KeySetProvider()
    {
        string path;

        if (OperatingSystem.IsAndroid())
            path = $"/sdcard/Download/{KeyFileName}";
        else
        {
            string defaultKeysPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".switch", KeyFileName);
            string KeysPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, KeyFileName);
            path = File.Exists(defaultKeysPath) ? defaultKeysPath : KeysPath;
        }

        if (File.Exists(path))
            KeySet = ExternalKeyReader.ReadKeyFile(path);
    }
}