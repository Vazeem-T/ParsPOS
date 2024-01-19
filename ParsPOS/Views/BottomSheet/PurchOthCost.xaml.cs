using ParsPOS.ViewModel;

namespace ParsPOS.Views.BottomSheet;

public partial class PurchOthCost
{
	PurchOthCostViewModel _ViewModel;
	public PurchOthCost(PurchOthCostViewModel viewModel)
	{
		InitializeComponent();
		_ViewModel  = viewModel;
		BindingContext = _ViewModel;
	}
}