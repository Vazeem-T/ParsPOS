using ParsPOS.PermissionAttributes;
using ParsPOS.Views.Settings;
using ParsPOS.Views.SubForms;
using ParsPOS.Views.User;

namespace ParsPOS.Views;

public partial class MainPageFlyoutItem : ContentView
{
	public MainPageFlyoutItem()
	{
		InitializeComponent();
	}

    private async void Inventory_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Inventory));
    }
    private async void Sale_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Sale));
    }
    private async void Settings_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MainSettings());
    }
    private async void UserRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new UserSettings());
    }
}