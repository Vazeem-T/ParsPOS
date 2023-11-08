using ParsPOS.Views;
using ParsPOS.Views.Settings;
using ParsPOS.Views.SubForms;
using ParsPOS.Views.User;

namespace ParsPOS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddCategory), typeof(AddCategory));
        Routing.RegisterRoute(nameof(Sale), typeof(Sale));
        Routing.RegisterRoute(nameof(ImportDb), typeof(ImportDb));
        Routing.RegisterRoute(nameof(UserInfo), typeof(UserInfo));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(Inventory), typeof(Inventory));
        Routing.RegisterRoute(nameof(PayPopup), typeof(PayPopup));

    }
}
