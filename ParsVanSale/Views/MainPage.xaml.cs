using Microsoft.Extensions.Hosting;
using Microsoft.Maui.Controls.PlatformConfiguration;
using ParsVanSale.Services;
using ParsVanSale.ViewModel;

namespace ParsVanSale.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage(HomeViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			statusbar.StatusBarColor = Color.FromArgb("#0E4252");
			statusbar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent;

			var host = MauiProgram.CreateMauiApp().Services.GetRequiredService<IHost>();
			host.StartAsync();
		}
		//protected override void OnDisappearing()
		//{
		//	base.OnDisappearing();
		//	statusbar.StatusBarColor = Color.FromArgb("#FFFFFF");
		//	statusbar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.DarkContent;
		//}
	}

}
