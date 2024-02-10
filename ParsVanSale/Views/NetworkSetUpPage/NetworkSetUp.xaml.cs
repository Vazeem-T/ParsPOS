using ParsVanSale.ViewModel;

namespace ParsVanSale.Views;

public partial class NetworkSetUp : ContentPage
{
	public NetworkSetUp(NetworkViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}