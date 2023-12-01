using ParsPOS.PermissionAttributes;
using ParsPOS.Views.Settings;
using ParsPOS.Views.SubForms;
using ParsPOS.Views.User;

namespace ParsPOS.Views;

public partial class MainPageFlyoutItem : ContentView
{
	public MainPageFlyoutItem()
	{
		InitializeComponent();
        BindingContext = this;
    }
    private string selectedRoute;
    public string SelectedRoute
    {
        get { return selectedRoute; }
        set
        {
            selectedRoute = value;
            OnPropertyChanged();
        }
    }

    async void OnMenuItemChanged(System.Object sender, CheckedChangedEventArgs e)
    {
        if (!String.IsNullOrEmpty(selectedRoute))
        {
            await Shell.Current.GoToAsync($"//{selectedRoute}");
        }   
    }
}