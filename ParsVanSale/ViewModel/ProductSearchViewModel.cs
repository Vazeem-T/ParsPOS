using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Model;
using ParsVanSale.ViewModel.BottomSheetViewModel;
using ParsVanSale.Views.BottomSheet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel
{
	public partial class ProductSearchViewModel : BaseViewModel
	{
		public ObservableCollection<Invitm> Items { get; set; } = new();
		[ObservableProperty]
		Invitm selectedInvItm;
		public ProductSearchViewModel()
		{
			LoadCommand.Execute(null);
			SelectedInvItm = new();
		}
		[RelayCommand]
		async Task OnLoadAsync()
		{
			var pageData = await App.Database.GetItemsAsync<Invitm>();
			if(pageData != null) 
			{
				foreach(var item in pageData) 
				{
					Items.Add(item);
				}
			}
		}
		[RelayCommand]
		async Task SelectionChanged()
		{
			if(SelectedInvItm != null)
			{
				ViewProductViewModel model = new ViewProductViewModel(this);
				ProductView page = new ProductView(model);
				page.ShowAsync();
			}
		}
	}
}
