using ParsPOS.ViewModel;
using CommunityToolkit.Maui.Views;


namespace ParsPOS.Views.SubForms;

public partial class LoadHold : Popup
{
	public LoadHold(SaleHoldViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}