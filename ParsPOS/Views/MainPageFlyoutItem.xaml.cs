using ParsPOS.Views.Settings;

namespace ParsPOS.Views;

public partial class MainPageFlyoutItem : ContentView
{
	public MainPageFlyoutItem()
	{
		InitializeComponent();
	}

    private async void Inventory_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Inventory());
    }
    private async void Sale_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Sale());
    }
    private async void Settings_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MainSettings());
    }
}