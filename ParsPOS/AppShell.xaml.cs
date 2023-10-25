using ParsPOS.Views.SubForms;

namespace ParsPOS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddCategory), typeof(AddCategory));
	}
}
