using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls.PlatformConfiguration;
using ParsPOS.DBHandler;
#if ANDROID
using Android.Content.Res;
#endif
using ParsPOS.Services;
using ParsPOS.ViewModel;
using ParsPOS.Views;

namespace ParsPOS;

public partial class App : Application
{
    //public static DownloadViewModel SharedDownloadViewModel { get; } = new DownloadViewModel();
    public static string UserId { get; set; }
    public static bool _Connected = false;

    private static DatabaseHelper db;
    private static SaleDatabaseHelper _db;
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
    public static SaleDatabaseHelper SaleDb
    {
        get
        {
            if (_db == null)
            {
                _db = new SaleDatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSCOUNTER.db3"));
            }
            return _db;
        }
    }


    public App()
    {
        Applocator.DisplayHeight = (DeviceDisplay.Current.MainDisplayInfo.Density) - 125;
        InitializeComponent();
        Applocator.Initialize();
        MainPage = new AppShell();
   
        if(App.UserId != null)
        {
            ((AppShell)MainPage).GoToAsync("//MainPage");
        }
        else 
        {
            ((AppShell)MainPage).GoToAsync("//Login");
        }
        
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (Handler, View) =>
        {
#if __ANDROID__
                        Handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#elif __IOS__
                            Handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                            Handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
    }
    
}
