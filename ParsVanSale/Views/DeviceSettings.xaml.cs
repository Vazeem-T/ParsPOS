using ParsVanSale.Views.DeviceSettingPage;

namespace ParsVanSale.Views;

public partial class DeviceSettings : ContentPage
{
	public DeviceSettings()
	{
		InitializeComponent();
	}

	private async void SystemSettings_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(SystemSettings));
    }
	private async void ApplicationSettings_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(ApplicationSettings));
	}
}