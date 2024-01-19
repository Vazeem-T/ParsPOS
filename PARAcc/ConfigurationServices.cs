using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PARSAcc.Model.Interface;
using PARSAcc.Model.ViewModel;
using PARSAcc.ViewComponents;
using System.Collections.ObjectModel;
using System.Data;

namespace PARSAcc
{
    public class ConfigurationServices
    {
        public static void ConfigureService(IServiceCollection services)
        {
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			services.AddHttpClient();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44361/API/") // Add your client application's origin
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddSingleton<PurchaseViewModel>();
            services.AddSingleton<List<PurchaseDetTb>>();
			//services.AddSingleton<IViewRenderService, ViewRenderService>();
		}
    }
}
