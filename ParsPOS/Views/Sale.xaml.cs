using ParsPOS.ViewModel;

namespace ParsPOS.Views;

public partial class Sale : ContentPage
{
    private SaleViewModel viewModel;

    public Sale()
	{
		InitializeComponent();
        viewModel = new SaleViewModel();
        BindingContext = viewModel;
    }

    private void BarcodeEntry_Completed(object sender, EventArgs e)
    {
        viewModel.BarcodeEntryCompleted();
    }
}