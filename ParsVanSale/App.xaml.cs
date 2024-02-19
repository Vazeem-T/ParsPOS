
using ParsVanSale.Helper;
using ParsVanSale.Model;
using ParsVanSale.Services;

#if ANDROID
using Android.Content.Res;
#endif
using ParsVanSale.Services.ViewService;
using ParsVanSale.ViewModel;
using ParsVanSale.Views;
using System.Linq.Expressions;

namespace ParsVanSale
{
	public partial class App : Application
	{

		public static bool IsInvTaxEna = true;
		public static string UserId;

		private static DatabaseHelper db;
		private HttpClient client;
		public static DatabaseHelper Database
		{
			get
			{
				if (db == null)
				{
					db = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSSALE.db3"));
				}
				return db;
			}
		}
		public App()
		{
			InitializeComponent();
			//LoginViewModel model = new LoginViewModel();
			MainPage = new Login();
			//if (App.UserId != null)
			//{
			//	((AppShell)MainPage).GoToAsync("//Home");
			//}
			//else
			//{
			//	((AppShell)MainPage).GoToAsync("//Login");
			//}

			//MainPage = new AppShell();

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
		private bool IsUserLoggedIn()
		{
			return false; 
		}
		private void NavigateToHomePage()
		{
			MainPage = new AppShell();
		}
		protected override async void OnStart()
		{
			base.OnStart();
			try
			{
				var current = Connectivity.NetworkAccess;

				if (current == NetworkAccess.Internet)
				{
//#if DEBUG
					HttpClientHandlerService handler = new HttpClientHandlerService();
					client = new HttpClient(handler.GetPlatformMessageHandler());
//#else
//        client = new HttpClient();
//#endif
					Expression<Func<NetworkIP,bool>> predicate = item=> item.IsConnected == true;
					var network = await App.Database.GetFirstAsync<NetworkIP,bool>(predicate, null);
					if(network != null)
					{
						var api = $"{network.Protocol}://{network.IPAddress}/API/DirectDb/Healthchk";
						client.BaseAddress = new Uri(api);
						HttpResponseMessage response = await client.GetAsync("");
						if (!response.IsSuccessStatusCode)
						{
							await Shell.Current.DisplayAlert("Alert!", "You are on Offline", "OK");
						}
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
		}
	}
}
