using ParsVanSale.ViewModel;

namespace ParsVanSale.Views;

public partial class DownloadPage : ContentPage
{
	DownloadViewmodel DownloadViewmodel { get; set; }
	public DownloadPage(DownloadViewmodel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
		DownloadViewmodel = viewmodel;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		Task.Run(async () =>
		{
			await DownloadViewmodel.LoadDataCommand.ExecuteAsync(null);
		});

	}
}