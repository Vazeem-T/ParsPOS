using ParsPOS.ViewModel;

namespace ParsPOS.Views.User;

public partial class UserInfo : ContentPage
{
	public UserInfo(UserViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}