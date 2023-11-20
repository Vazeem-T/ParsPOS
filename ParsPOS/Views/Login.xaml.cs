using ParsPOS.ViewModel;

namespace ParsPOS.Views;

public partial class Login : ContentPage
{
	public Login(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}