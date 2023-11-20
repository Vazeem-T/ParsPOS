using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;
using ParsPOS.DBHandler;
using ParsPOS.InterfaceServices;
using ParsPOS.PermissionAttributes;
using ParsPOS.ViewModel;
using ParsPOS.Views;
using ParsPOS.Views.ContentViewPage;
using ParsPOS.Views.Settings;
using ParsPOS.Views.SubForms;
using ParsPOS.Views.User;
using Sharpnado.Tabs;

namespace ParsPOS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
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
            });
        builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
        builder.Services.AddSingleton<DatabaseHelper>();
        builder.Services.AddSingleton<DownloadViewModel>();
        builder.Services.AddTransient<InventoryViewModel>();
        builder.Services.AddTransient<MainSettings>();
        builder.Services.AddTransient<Inventory>();
        builder.Services.AddSingleton<CategoryViewModel>();
        builder.Services.AddSingleton<SaleViewModel>();
        builder.Services.AddTransient<Sale>();
        builder.Services.AddTransient<AddCategory>();
        builder.Services.AddSingleton<DatabaseHelper>();
        builder.Services.AddSingleton<SaleDatabaseHelper>();
        builder.Services.AddSingleton<ImportDb>();
        builder.Services.AddSingleton<ImportDbViewModel>();
        builder.Services.AddTransient<UserInfo>();
        builder.Services.AddTransient<UserSettings>();
        builder.Services.AddSingleton<UserViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AccessControlAttribute>();
        builder.Services.AddSingleton<PayPopup>();
        builder.Services.AddSingleton<SaleDatabaseHelper>();
        builder.Services.AddTransient<NumberPadViewModel>();
        builder.Services.AddTransient<NumberPadView>();
        builder.Services.AddSingleton<INumberPad, NumberPad>();
        builder.Services.AddSingleton<PayPopupViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<Login>();
        builder.Services.AddTransient<AddCompanydt>();
        builder.Services.AddSingleton<CompanyViewModel>();
        //builder.Services.AddHttpClient("api", httpClient => httpClient.BaseAddress = new Uri(""));
#if DEBUG
        builder.Logging.AddDebug();
#endif
        
		return builder.Build();
	}
}
