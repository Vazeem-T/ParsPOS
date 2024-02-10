using ParsVanSale.ViewModel.BottomSheetViewModel;

namespace ParsVanSale.Views.BottomSheet;

public partial class PartyBtmSht
{
	public PartyBtmSht(PartyViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		viewModel.RequestClose += OnRequestClose;
	}

	private async void OnRequestClose(object sender, EventArgs e)
	{
		await DismissAsync();
	}
}