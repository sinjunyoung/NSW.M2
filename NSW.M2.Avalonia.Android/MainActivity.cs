using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Avalonia;
using Avalonia.Android;
using Android;
using ReactiveUI.Avalonia;
using System;

namespace NSW.M2.Avalonia.Android;

[Activity(
    Label = "NSW.M2.Avalonia.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    public static MainActivity? Instance { get; private set; }

    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI();
    }

    const int MANAGE_ALL_FILES_REQUEST_CODE = 1002;

    protected override void OnCreate(Bundle? savedInstanceState)    
    {
        Instance = this;        
        base.OnCreate(savedInstanceState);
        RequestStoragePermissions();
    }

    private void RequestStoragePermissions()
    {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
        {
            if (!global::Android.OS.Environment.IsExternalStorageManager)
            {
                try
                {
                    var intent = new Intent(global::Android.Provider.Settings.ActionManageAppAllFilesAccessPermission);
                    intent.SetData(global::Android.Net.Uri.Parse($"package:{PackageName}"));
                    StartActivityForResult(intent, MANAGE_ALL_FILES_REQUEST_CODE);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Specific Intent failed: {ex.Message}");
                    var intent = new Intent(global::Android.Provider.Settings.ActionManageAllFilesAccessPermission);
                    StartActivityForResult(intent, MANAGE_ALL_FILES_REQUEST_CODE);
                }
            }
        }
        else
        {
            string[] permissions = [ Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage ];
            if (CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Permission.Granted)
            {
                RequestPermissions(permissions, 1000);
            }
        }
    }
}
