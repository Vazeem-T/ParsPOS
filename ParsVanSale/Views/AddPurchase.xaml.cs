using ParsVanSale.ViewModel;

namespace ParsVanSale.Views;

public partial class AddPurchase : ContentPage
{
	public AddPurchase(SaleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}