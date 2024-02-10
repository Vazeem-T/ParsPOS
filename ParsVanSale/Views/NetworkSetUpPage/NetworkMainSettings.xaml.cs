namespace ParsVanSale.Views.NetworkSetUpPage;

public partial class NetworkMainSettings : ContentPage
{
	public NetworkMainSettings()
	{
		InitializeComponent();
	}

	private async void API_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(NetworkSetUp));
    }
	private async void SQLSERVER_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(AddSqlServer));
	}
}