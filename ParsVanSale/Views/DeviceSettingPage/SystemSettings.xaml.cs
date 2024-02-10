using ParsVanSale.ViewModel;

namespace ParsVanSale.Views.DeviceSettingPage;

public partial class SystemSettings : ContentPage
{
	public SystemSettings(SystemSettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}