using ParsVanSale.ViewModel;

namespace ParsVanSale.Views.SqliteSettings;

public partial class ImportData : ContentPage
{
	public ImportData(ImportDataViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}