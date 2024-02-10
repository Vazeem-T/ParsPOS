using ParsVanSale.ViewModel;

namespace ParsVanSale.Views;

public partial class Purchase : ContentPage
{
	public Purchase(SaleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		//InitializeAsync();
	}
	//private async void InitializeAsync()
	//{
	//	await (BindingContext as SaleViewModel)?.LoadOnOpenCommand.ExecuteAsync(null);
	//}
}