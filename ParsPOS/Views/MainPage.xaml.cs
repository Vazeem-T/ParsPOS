using ParsPOS.Views;
using ParsPOS.Views.Settings;
using System.Windows.Input;

namespace ParsPOS.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
    private async void SaleButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Sale());
    }
    private async void InventoryButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Inventory());
    }
    private async void UploadDbButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UploadDb());
    }
}

