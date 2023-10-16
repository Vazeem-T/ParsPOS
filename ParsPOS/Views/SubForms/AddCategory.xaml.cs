using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.ViewModel;
using System.Collections.ObjectModel;

namespace ParsPOS.Views.SubForms;

public partial class AddCategory : ContentPage
{
    //private int currentPage = 1;
    //private List<Invitm> loadedData = new List<Invitm>();
    CategoryViewModel viewModel = new CategoryViewModel();
    public AddCategory()
	{
		InitializeComponent();
        //BindingContext = viewModel;
        Item.ItemAppearing += ListView_ItemAppearing;
    }

    private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
    {
        try
        {
            var items = (ObservableCollection<RGrpItmTb>)Item.ItemsSource;
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
}