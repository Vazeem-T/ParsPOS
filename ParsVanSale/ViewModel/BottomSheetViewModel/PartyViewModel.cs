using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel.BottomSheetViewModel
{
    public partial class PartyViewModel : BaseViewModel
    {
        public ObservableCollection<AccMast> Items { get; set; } = new();
		private readonly SaleViewModel _saleViewModel;

		[ObservableProperty]
		AccMast master;

        [ObservableProperty]
        string selectedItem = "Suppl/Cust";

        [ObservableProperty]
        string searchtxt;

		private readonly IDbConnection _connection;
        public PartyViewModel(IDbConnection connection,SaleViewModel saleViewModel)
        {
            _connection = connection;
            LoadOnOpenCommand.Execute(null);
			_saleViewModel = saleViewModel;
        }

        [RelayCommand]
        async Task LoadOnOpenAsync()
		{
            if(Searchtxt == null || Searchtxt == "" )
            {
				var PageData = await App.Database.GetItemsAsync<AccMast>();
				if (PageData != null)
				{
					foreach (var item in PageData)
					{
						Items.Add(item);
					}
				}
			}
			else
            {
				string searchselecttext;
				if (SelectedItem == "Suppl/Cust") searchselecttext = "AccDescr";
				else searchselecttext = SelectedItem;
				var PageData = await App.Database.GetSearchMast(Searchtxt, searchselecttext);
				if (PageData != null)
				{
					foreach (var item in PageData)
					{
						Items.Add(item);
					}
				}
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
						Items.Clear();
					});
				});
				LoadOnOpenCommand.Execute(null);
			}
			catch (Exception ex)
			{
			}
		}

		[RelayCommand]
		async Task SelectionChange()
		{
			if(Master is not null)
			{
				//_saleViewModel.PartyAcAlias = Master.AccDescr;
				//_saleViewModel.PartyAcDesc = Master.Alias;
				//_saleViewModel.PartyAcNo = Master.AccountNo;
				_saleViewModel.SaleDetCmn.SuppDesc = Master.AccDescr;
				_saleViewModel.SaleDetCmn.SuppAlias = Master.Alias;
				_saleViewModel.SaleDetCmn.SuppAcNo = Master.AccountNo;
				_saleViewModel.LoadCmnCommand.Execute(null);
				RequestCloseAction();
			}
		}
		public event EventHandler RequestClose;
		private void RequestCloseAction()
		{
			RequestClose?.Invoke(this, EventArgs.Empty);
		}
	}
}
