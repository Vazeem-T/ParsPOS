
using ParsPOS.DBHandler;
using ParsPOS.InterfaceServices;
using ParsPOS.PermissionAttributes;
using ParsPOS.Services.ViewSevices;
using ParsPOS.ViewModel;
using ParsPOS.Views;
using ParsPOS.Views.BottomSheet;
using ParsPOS.Views.ContentViewPage;
using ParsPOS.Views.InventoryView;
using ParsPOS.Views.Settings;
using ParsPOS.Views.SubForms;
using ParsPOS.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class ConfigurationServices
    {
        public static void ConfigureService(IServiceCollection services)
        {

            services.AddSingleton<DatabaseHelper>();
            services.AddSingleton<SaleDatabaseHelper>();

            //Other Services
            services.AddSingleton<INumberPad, NumberPad>();
            services.AddTransient<AccessControlAttribute>();
            services.AddSingleton<SharedPurchaseService>();
            services.AddHostedService<APIConnectionMonitorServices>();
            services.AddHttpClient<APIConnectionMonitorServices>();


            //ViewModels
            services.AddTransient<DownloadViewModel>();
            services.AddTransient<InventoryViewModel>();
            services.AddTransient<CategoryViewModel>();
            services.AddSingleton<SaleViewModel>();
            services.AddSingleton<ImportDbViewModel>();
            services.AddSingleton<UserViewModel>();
            services.AddSingleton<MainPageViewModel>();
            services.AddTransient<NumberPadViewModel>();
            services.AddSingleton<PayPopupViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<CompanyViewModel>();
            services.AddSingleton<SaleHoldViewModel>();
            services.AddSingleton<PurchaseViewModel>();
            services.AddSingleton<PurchasePopupViewModel>();
            services.AddSingleton<PopupButtonsSelectionWrapper>();
            services.AddTransient<FOCViewModel>();
            services.AddSingleton<BaseItmDetViewModel>();
            services.AddSingleton<UnitsViewModel>();
            services.AddSingleton<SupplierPrdViewModel>();
			services.AddSingleton<MastersViewModel>();
			services.AddTransient<DynamicPopViewModel>();


			//Views
			services.AddTransient<Sale>();
            services.AddTransient<AddCategory>();
            services.AddSingleton<ImportDb>();
            services.AddTransient<UserInfo>();
            services.AddTransient<UserSettings>();
            services.AddTransient<MainPage>();
            services.AddSingleton<PayPopup>();
            services.AddTransient<NumberPadView>();
            services.AddTransient<Login>();
            services.AddTransient<AddCompanydt>();
            services.AddTransient<MainSettings>();
            services.AddTransient<Inventory>();
            services.AddTransient<PurchAdd>();
            services.AddTransient<Purchase>();
            services.AddTransient<LoadHold>();
            services.AddTransient<AddPurchase>();
            services.AddTransient<FOC>();
        }
    }
}
