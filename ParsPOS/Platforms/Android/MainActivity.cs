using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using CommunityToolkit.Maui.Core;
using ParsPOS.DBHandler;
using ParsPOS.Platforms.Android.Services;

namespace ParsPOS;

[Activity(Label = "PARSPOS", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Platform.Init(this, savedInstanceState);

        CommunityToolkit.Maui.Core.Platform.StatusBar.SetColor(Colors.White);
        CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(StatusBarStyle.DarkContent);
   

        //Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
        //Window.DecorView.SystemUiVisibility |= (StatusBarVisibility)(SystemUiFlags.LayoutFullscreen | SystemUiFlags.LayoutStable);
        //Window.SetNavigationBarColor(Android.Graphics.Color.Transparent);
    }

    //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
    //{
    //    Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

    //}
}
