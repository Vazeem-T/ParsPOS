using ParsPOS.ViewModel;

namespace ParsPOS.Views.InventoryView;

public partial class AddPurchase : ContentPage
{
	public AddPurchase(PurchaseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}