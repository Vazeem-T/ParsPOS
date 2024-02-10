using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using ParsVanSale.Model;
using System.Collections.ObjectModel;
using System.Data;

namespace ParsVanSale.ViewModel.BottomSheetViewModel
{
    public partial class AddProdViewModel : BaseViewModel
    {
		public ObservableCollection<Invitm> ItemList { get; set; } = new();

		[ObservableProperty]
		double height;

		[ObservableProperty]
		string selectedItem = "ItemCode";


		[ObservableProperty]
		double listHeight;

		[ObservableProperty]
		Invitm selectedInv;

		[ObservableProperty]
		string searchtxt;
		public SaleViewModel _saleViewModel { get; set; }

		[ObservableProperty]
		double width;
		public AddProdViewModel(SaleViewModel viewModel)
		{
			_saleViewModel = viewModel;
			LoadDataCommand.Execute(null);

		}
		[RelayCommand]
		private async Task LoadDataAsync()
		{
			try
			{

				if (Searchtxt == null || Searchtxt == "")
				{
					var PageData = await App.Database.GetItemsAsync<Invitm>();
					if (PageData != null)
					{
						foreach (var item in PageData)
						{
							ItemList.Add(item);
						}
					}
				}
				else
				{
					var pageData = await App.Database.GetSearchProd(Searchtxt, SelectedItem);
					if (pageData.Any())
					{
						foreach (var item in pageData)
						{
							ItemList.Add(item);
						}
					}
				}
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
			}
		}

		[RelayCommand]
		async Task SearchTextChange()
		{
			try
			{
			
				await Task.Run(() =>
				{
					MainThread.BeginInvokeOnMainThread(() =>
					{
						ItemList.Clear();
					});
				});
				LoadDataCommand.Execute(null);
			}
			catch (Exception ex)
			{
			}
		}

		[RelayCommand]
		async Task SelectedListItem()
		{
			if (SelectedInv != null)
			{
				_saleViewModel.SelectedItemcode = SelectedInv.ItemCode;
				RequestCloseAction();
				await _saleViewModel.LoadSelectedItmCommand.ExecuteAsync(null);
				//_sharedDataService.Onselected(SelectedInv);
				//await Shell.Current.GoToAsync(nameof(AddPurchase));
			}
		}
		public event EventHandler RequestClose;
		private void RequestCloseAction()
		{
			RequestClose?.Invoke(this, EventArgs.Empty);
		}
	}
}
