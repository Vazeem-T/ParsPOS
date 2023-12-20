using ParsPOS.Model;
using ParsPOS.ViewModel;
using System.Collections.ObjectModel;

namespace ParsPOS.Views.BottomSheet;

public partial class PurchAdd 
{
    PurchasePopupViewModel modal;
	public PurchAdd(PurchasePopupViewModel viewModel)
	{
		InitializeComponent();
        modal = viewModel;
		BindingContext = viewModel;
        viewModel.RequestClose += OnRequestClose;
        //Item.ItemAppearing += ListView_ItemAppearing;
    }
    private async void OnRequestClose(object sender, EventArgs e)
    {
        await DismissAsync();
    }
    private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
    {
        try
        {
            if (modal.IsBusy == false)
            {
                var items = (ObservableCollection<Invitm>)Item.ItemsSource;
                if (e.Item == items[items.Count - 1])
                {
                    // Load more data when the last item is appearing
                    modal.LoadDataCommand.Execute(null);
                    Item.ItemsSource = modal.PurchaseList;
                }
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
        }
    }
}