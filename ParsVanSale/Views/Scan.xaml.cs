using ParsVanSale.ViewModel.BottomSheetViewModel;
using ParsVanSale.Views.BottomSheet;
using ZXing.Net.Maui;

namespace ParsVanSale.Views;

public partial class Scan : ContentPage
{
	public Scan()
	{
		InitializeComponent();
		barcodeView.Options = new BarcodeReaderOptions() 
		{
			Formats = BarcodeFormat.Ean13 | BarcodeFormat.Ean8 | BarcodeFormat.QrCode,
			AutoRotate = true,
			Multiple = true,
		};
	}
	protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
	{
		MainThread.BeginInvokeOnMainThread(() => {
			//lbl.Text =$"{e.Results[0].Value} {e.Results[0].Format}";
			ViewProductViewModel model = new ViewProductViewModel(e.Results[0].Value);
			ProductView page = new ProductView(model);
			page.ShowAsync();
		});
	}
}