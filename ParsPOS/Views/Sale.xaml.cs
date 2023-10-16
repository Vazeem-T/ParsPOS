using ParsPOS.DBHandler;
using ParsPOS.ViewModel;

namespace ParsPOS.Views;

public partial class Sale : ContentPage
{
    private SaleViewModel viewModel;

    public Sale()
	{
		InitializeComponent();
        var saleDatabaseHelper = new SaleDatabaseHelper();
        viewModel = new SaleViewModel(saleDatabaseHelper);
        BindingContext = viewModel;
    }

    private async void BarcodeEntry_Completed(object sender, EventArgs e)
    {
        await viewModel.SearchInvItm();
    }
}