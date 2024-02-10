using ParsVanSale.ViewModel.BottomSheetViewModel;

namespace ParsVanSale.Views.BottomSheet;

public partial class ProductView 
{
	public ProductView(ViewProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}