namespace ParsPOS.Views.Settings;

public partial class MainSettings : ContentPage
{
	public MainSettings()
	{
		InitializeComponent();
	}

    private async void Database_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new DbSetting());
    }

    private async void Network_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new AddNetwork());
    }

    private async void GeneralSettings_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new GeneralSettings());
    }

    private async void Company_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCompanydt));
    }

}