namespace ParsVanSale.Views.SqliteSettings;

public partial class SqliteMainSettings : ContentPage
{
	public SqliteMainSettings()
	{
		InitializeComponent();
	}

	private async void ImportDatabase_Tapped(object sender, TappedEventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(ImportData));
	}
}