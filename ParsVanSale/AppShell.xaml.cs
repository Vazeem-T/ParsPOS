using ParsVanSale.Services;
using ParsVanSale.Views;
using ParsVanSale.Views.DeviceSettingPage;
using ParsVanSale.Views.NetworkSetUpPage;
using ParsVanSale.Views.Sale;
using ParsVanSale.Views.SqliteSettings;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace ParsVanSale
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			InitRoutes();
		}

		private void InitRoutes()
		{
			Routing.RegisterRoute(nameof(Settings),typeof(Settings));
			Routing.RegisterRoute(nameof(SqliteMainSettings), typeof(SqliteMainSettings));
			Routing.RegisterRoute(nameof(AddPurchase),typeof(AddPurchase));
			Routing.RegisterRoute(nameof(ImportData), typeof(ImportData));
			Routing.RegisterRoute(nameof(DownloadPage), typeof(DownloadPage));
			Routing.RegisterRoute(nameof(NetworkSetUp), typeof(NetworkSetUp));
			Routing.RegisterRoute(nameof(AddSqlServer), typeof(AddSqlServer));
			Routing.RegisterRoute(nameof(Export), typeof(Export));
			Routing.RegisterRoute(nameof(Login), typeof(Login));
			Routing.RegisterRoute(nameof(NetworkMainSettings), typeof(NetworkMainSettings));
			//Routing.RegisterRoute("//Home/ImportData", typeof(ImportData));
			Routing.RegisterRoute("Settings/NetworkSetUp", typeof(NetworkSetUp));
			Routing.RegisterRoute(nameof(MapFOC), typeof(MapFOC));
			Routing.RegisterRoute("Settings/DeviceSettings", typeof(DeviceSettings));
			Routing.RegisterRoute("Settings/DeviceSettings/SystemSettings", typeof(SystemSettings));
			Routing.RegisterRoute("Settings/DeviceSettings/ApplicationSettings", typeof(ApplicationSettings));
			//AddTab(typeof(MainPage), PageType.Home);
			//AddTab(typeof(SearchProduct), PageType.Product);
			//AddTab(typeof(Scan), PageType.Scan);
			//AddTab(typeof(Purchase), PageType.Sale);
			//         AddTab(typeof(DownloadPage), PageType.Download);
			//         Loaded += AppShellLoaded;
		}

		private static void AppShellLoaded(object sender, EventArgs e)
		{
			var shell = sender as AppShell;

			shell.Window.SubscribeToSafeAreaChanges(safeArea =>
			{
				//shell.pageContainer.Margin = safeArea;
				
				//shell.tabBarView.Margin = safeArea;

				//shell.bottomBackgroundRectangle.IsVisible = safeArea.Bottom > 0;

				//shell.bottomBackgroundRectangle.HeightRequest = safeArea.Bottom;

			});
		}

		//private void AddTab(Type page, PageType pageEnum)
		//{
		//	Tab tab = new Tab { Route = pageEnum.ToString(), Title = pageEnum.ToString() };
		//	tab.Items.Add(new ShellContent { ContentTemplate = new DataTemplate(page) });

		//	tabBar.Items.Add(tab);
		//}

		//private void TabBarViewCurrentPageChanged(object sender, TabBarEventArgs e)
		//{
		//	Shell.Current.GoToAsync("///" + e.CurrentPage.ToString());
		//}

	}
}
