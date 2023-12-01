using ParsPOS.ViewModel;

namespace ParsPOS.Views.InventoryView;

public partial class Purchase : ContentPage
{
	public Purchase(PurchaseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}