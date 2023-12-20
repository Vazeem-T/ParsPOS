using ParsPOS.ViewModel;

namespace ParsPOS.Views.InventoryView;

public partial class FOC : ContentPage
{
	public FOC(FOCViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}