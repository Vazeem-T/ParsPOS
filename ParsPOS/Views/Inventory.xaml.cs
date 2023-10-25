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
    InventoryViewModel viewModel = new InventoryViewModel();
    public Inventory()
    {
        InitializeComponent();
        Item.ItemAppearing += ListView_ItemAppearing;
        
    }
    private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
    {
        try
        {
            if(viewModel.IsLoadingMore ==  false) 
            {
                var items = (ObservableCollection<Invitm>)Item.ItemsSource;
                if (e.Item == items[items.Count - 1])
                {
                    // Load more data when the last item is appearing
                    viewModel.LoadDataCommand.Execute(null);
                    Item.ItemsSource = viewModel.Items;
                }
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Alert", ex.Message, "OK");
        }
    }
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProduct());
    }
    private async void Download_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Download());
    }

}