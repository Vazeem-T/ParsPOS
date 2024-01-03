using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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
using PostSharp;
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
            fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
            fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
            fonts.AddFont("Roboto-Italic.ttf", "RobotoItalic");

            fonts.AddFont("fa-brands-400.otf", "FAB");
            fonts.AddFont("Fa-Regular-400.otf", "FAR");
            fonts.AddFont("Fa-solid-900.otf", "FAS");
        }).ConfigureMauiHandlers(handlers => {
#if ANDROID
            handlers.AddHandler(typeof(Shell), typeof(ParsPOS.Platforms.CustomShellRenderer));
#endif
        });
        
        ConfigurationServices.ConfigureService(builder.Services);

        builder.Services.AddScoped<IDbConnection>((sp) =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSPOS.db3");
            var connectionstring = $"Data Source={filePath};";
            return new SqliteConnection(connectionstring);
        });
        //builder.Services.AddHttpClient("api", httpClient => httpClient.BaseAddress = new Uri(""));
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
