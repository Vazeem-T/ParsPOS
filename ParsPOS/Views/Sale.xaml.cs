using CommunityToolkit.Maui.Core.Platform;
using ParsPOS.DBHandler;
using ParsPOS.InterfaceServices;
using ParsPOS.ViewModel;

namespace ParsPOS.Views;

public partial class Sale : ContentPage
{
    public Sale(SaleViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}