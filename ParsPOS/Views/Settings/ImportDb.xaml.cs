using ParsPOS.ViewModel;

namespace ParsPOS.Views.Settings;

public partial class ImportDb : ContentPage
{
	public ImportDb(ImportDbViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}