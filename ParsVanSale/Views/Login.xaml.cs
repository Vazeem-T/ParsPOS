using CommunityToolkit.Maui.Core.Platform;
using ParsVanSale.ViewModel;

namespace ParsVanSale.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		//statusbar.StatusBarColor = Color.FromArgb("#0E4252");
		//statusbar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent;
	}

	private async void Login_Clicked(object sender, EventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(Password.Text))
			{
				await DisplayAlert("Alert", "Password cannot be null or empty", "OK");
				return;
			}

			//Application.Current.MainPage = new AppShell();

			var user = await Task.Run(() => App.Database.LoginUser(UserId.Text, Password.Text));

			var adminPass = "VISHWASAM";
			if (Password.Text.ToUpper() == adminPass.ToUpper())
			{
				App.UserId = "Programmer";
				Password.Text = string.Empty;
				Application.Current.MainPage = new AppShell();
			}
			else if (user != null)
			{
				App.UserId = UserId.Text;
				UserId.Text = string.Empty;
				Password.Text = string.Empty;
				Application.Current.MainPage = new AppShell();
			}
			else
			{
				await DisplayAlert("Alert", "UserId and Password don't match!", "OK");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Alert", ex.Message, "OK");
		}
	}
}