using CommunityToolkit.Maui.Views;
using ParsPOS.ViewModel;

namespace ParsPOS.Views.SubForms;

public partial class LoadHold : Popup
{
	public LoadHold(SaleHoldViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}