using CommunityToolkit.Maui;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ParsPOS.Services;
using Sharpnado.Tabs;
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
