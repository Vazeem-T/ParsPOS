using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.Services;
using ParsPOS.ViewModel;
using ParsPOS.Views.SubForms;
using System.Collections.ObjectModel;

namespace ParsPOS.Views;

public partial class Inventory : ContentPage
{
    private int currentPage = 1;
    private List<Invitm> loadedData = new List<Invitm>();
    InventoryViewModel viewModel = new InventoryViewModel();
    public Inventory()
    {
        InitializeComponent();
        //viewModel = new InventoryViewModel();
        Item.ItemAppearing += ListView_ItemAppearing;

    }
    private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
    {
        try
        {
            var items = (ObservableCollection<Invitm>)Item.ItemsSource;
            if (e.Item == items[items.Count - 1])
            {
                // Load more data when the last item is appearing
                viewModel.LoadDataCommand.Execute(null);
                Item.ItemsSource = viewModel.Items;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", ex.Message, "OK");
        }
    }

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProduct());
    }

    private async void AddCategoryButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new AddCategory());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", ex.Message, "OK");
        }

    }
    private async void Download_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Download());
    }
}