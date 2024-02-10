using ParsVanSale.ViewModel;

namespace ParsVanSale.Views.NetworkSetUpPage;

public partial class AddSqlServer : ContentPage
{
	public AddSqlServer(SqlServerViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}