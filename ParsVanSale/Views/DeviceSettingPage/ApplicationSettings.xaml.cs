using ParsVanSale.ViewModel;

namespace ParsVanSale.Views.DeviceSettingPage;

public partial class ApplicationSettings : ContentPage
{
	public ApplicationSettings(ApplicationSettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}