using CommunityToolkit.Maui.Views;
using ParsPOS.ViewModel;

namespace ParsPOS.Views.SubForms;

public partial class PayPopup : Popup
{
	public PayPopup(SaleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}