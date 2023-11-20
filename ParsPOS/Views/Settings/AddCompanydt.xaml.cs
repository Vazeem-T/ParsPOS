using ParsPOS.Model;
using ParsPOS.ViewModel;

namespace ParsPOS.Views.Settings;

public partial class AddCompanydt : ContentPage
{
	public AddCompanydt(CompanyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}