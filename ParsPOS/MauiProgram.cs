using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ParsPOS.DBHandler;
using ParsPOS.InterfaceServices;
using ParsPOS.PermissionAttributes;
using ParsPOS.Services;
using ParsPOS.ViewModel;
using ParsPOS.Views;
using ParsPOS.Views.BottomSheet;
using ParsPOS.Views.ContentViewPage;
using ParsPOS.Views.InventoryView;
using ParsPOS.Views.Settings;
using ParsPOS.Views.SubForms;
using ParsPOS.Views.User;
using Sharpnado.Tabs;
using SQLite;
using SQLitePCL;
using System.Data;
using The49.Maui.BottomSheet;

namespace ParsPOS;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        builder
        .UseMauiApp<App>()
        .UseBottomSheet()
        .UseMauiCommunityToolkit()

        .UseSharpnadoTabs(loggerEnable: false)
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("JosefinSans-Italic-VariableFont_wght.ttf", "JosefinSansItalic");
            fonts.AddFont("JosefinSans-VariableFont_wght.ttf", "JosefinSansRegular");
            fonts.AddFont("fa-brands-400.otf", "FAB");
            fonts.AddFont("Fa-Regular-400.otf", "FAR");
            fonts.AddFont("Fa-solid-900.otf", "FAS");
        }).ConfigureMauiHandlers(handlers => {
#if ANDROID
            handlers.AddHandler(typeof(Shell), typeof(ParsPOS.Platforms.CustomShellRenderer));
#endif
        });
        
        ConfigurationServices.ConfigureService(builder.Services);

        builder.Services.AddScoped<IDbConnection>(sp =>
        {
            var sqliteConnection = sp.GetRequiredService<SQLiteAsyncConnection>();
            return (IDbConnection)sqliteConnection;
        });


        //builder.Services.AddHttpClient("api", httpClient => httpClient.BaseAddress = new Uri(""));
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
