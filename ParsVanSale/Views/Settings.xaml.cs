using ParsVanSale.Views.NetworkSetUpPage;
using ParsVanSale.Views.SqliteSettings;

namespace ParsVanSale.Views;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}

	private async void Database_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(SqliteMainSettings));
    }
	private async void Network_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(NetworkMainSettings));
	}
	private async void Access_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(DeviceSettings));
	}

}