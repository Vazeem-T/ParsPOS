using ParsPOS.ViewModel;
using ParsPOS.Views;
using ParsPOS.Views.Settings;
using System.Windows.Input;

namespace ParsPOS.Views;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}

