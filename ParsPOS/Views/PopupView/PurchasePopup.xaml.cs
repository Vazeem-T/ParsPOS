namespace ParsPOS.Views.PopupView;
using CommunityToolkit.Maui.Views;

public partial class PurchasePopup : Popup
{
	public PurchasePopup(PurchasePopup viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}