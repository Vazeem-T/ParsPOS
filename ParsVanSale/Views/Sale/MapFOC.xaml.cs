using ParsVanSale.ViewModel;

namespace ParsVanSale.Views.Sale;

public partial class MapFOC : ContentPage
{
	public MapFOC(SaleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}