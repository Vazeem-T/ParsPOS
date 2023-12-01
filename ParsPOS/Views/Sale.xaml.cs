using CommunityToolkit.Maui.Core.Platform;
using ParsPOS.DBHandler;
using ParsPOS.InterfaceServices;
using ParsPOS.ViewModel;

namespace ParsPOS.Views;

public partial class Sale : ContentPage
{
    public Sale(SaleHoldViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = new SaleViewModel(viewModel);
    }
}