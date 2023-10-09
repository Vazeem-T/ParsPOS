using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ParsPOS.DBHandler;
using ParsPOS.ViewModel;
using ParsPOS.Views;
using ParsPOS.Views.Settings;

namespace ParsPOS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("JosefinSans-Italic-VariableFont_wght.ttf", "JosefinSansItalic");
                fonts.AddFont("JosefinSans-VariableFont_wght.ttf", "JosefinSansRegular");
                fonts.AddFont("fa-brands-400.otf", "FAB");
                fonts.AddFont("Fa-Regular-400.otf", "FAR");
                fonts.AddFont("Fa-solid-900.otf", "FAS");
            });
        builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
        builder.Services.AddSingleton<DatabaseHelper>();
        //builder.Services.AddHttpClient("api", httpClient => httpClient.BaseAddress = new Uri(""));
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<SaleDatabaseHelper>();
		return builder.Build();
	}
}
