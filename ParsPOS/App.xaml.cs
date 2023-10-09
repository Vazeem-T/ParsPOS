using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls.PlatformConfiguration;
using ParsPOS.DBHandler;
using ParsPOS.Services;
using ParsPOS.Views;

namespace ParsPOS;

public partial class App : Application
{
    private static DatabaseHelper db;
    public static DatabaseHelper Database
    {
        get
        {
            if (db == null)
            {
                db = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSPOS.db3"));
            }
            return db;
        }
    }
 

    public App()
    {
        Applocator.DisplayHeight = (DeviceDisplay.Current.MainDisplayInfo.Density) - 125;
        //App.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        Applocator.Initialize();
        MainPage = new AppShell();
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (Handler, View) =>
            {
#if __ANDROID__
            Handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                Handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                Handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
    }


}
