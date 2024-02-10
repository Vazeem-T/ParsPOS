using ParsVanSale.ViewModel;

namespace ParsVanSale.Views;

public partial class SearchProduct : ContentPage
{
	public SearchProduct(ProductSearchViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}