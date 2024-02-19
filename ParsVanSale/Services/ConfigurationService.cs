#if ANDROID
using ParsVanSale.Platforms.Android.Services;
#endif
using Microsoft.Extensions.Hosting;
using ParsVanSale.ViewModel;
using ParsVanSale.ViewModel.BottomSheetViewModel;
using ParsVanSale.ViewModel.DownloadViewModel;
using ParsVanSale.Views;
using ParsVanSale.Views.DeviceSettingPage;
using ParsVanSale.Views.NetworkSetUpPage;
using ParsVanSale.Views.Sale;
using ParsVanSale.Views.SqliteSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Services
{
    public class ConfigurationService
    {
        public static void ConfigureService(IServiceCollection services)
        {
            //ViewModel
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SaleViewModel>();
            services.AddTransient<NetworkViewModel>();
            services.AddTransient<DownloadViewmodel>();
            services.AddTransient<ImportDataViewModel>();
            services.AddTransient<PrefixDownloadModel>();
            services.AddTransient<BaseItmDetDownloadModel>();
            services.AddTransient<ProductDownloadModel>();
            services.AddTransient<SupplierDownloadModel>();
            services.AddTransient<SuppProdDownloadModel>();
            services.AddTransient<UnitDownloadModel>();
            services.AddTransient<UserDownloadModel>();
            services.AddTransient<PartyViewModel>();
            services.AddTransient<AddProdViewModel>();
            services.AddTransient<SystemSettingsViewModel>();
			services.AddTransient<ApplicationSettingsViewModel>();
			services.AddTransient<ProductSearchViewModel>();
            services.AddTransient<SqlServerViewModel>();
            services.AddTransient<LoginViewModel>();

			//View
			services.AddSingleton<MainPage>();
            services.AddSingleton<Purchase>();
            services.AddSingleton<AddPurchase>();
            services.AddTransient<SqliteMainSettings>();
            services.AddTransient<ImportData>();
            services.AddTransient<NetworkSetUp>();
            services.AddTransient<DownloadPage>();
            services.AddTransient<MapFOC>();
            services.AddTransient<SystemSettings>();
			services.AddTransient<ApplicationSettings>();
            services.AddTransient<SearchProduct>();
            services.AddTransient<AddSqlServer>();
            services.AddTransient<Login>();
			//Other Services
#if ANDROID
			services.AddSingleton<IPrintServices, PrinterServiceRenderer>();
#endif
			services.AddSingleton<IHost>(sp =>
			{
				var host = new HostBuilder()
					.ConfigureServices((hostContext, services) =>
					{
						services.AddHostedService<MyBackgroundService>();
					})
					.Build();
				return host;
			});
			
		}

    }
}
