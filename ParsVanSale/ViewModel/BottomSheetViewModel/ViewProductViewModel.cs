using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel.BottomSheetViewModel
{
	public partial class ViewProductViewModel : BaseViewModel
	{
		public ProductSearchViewModel _productSearchViewModel { get; set; }
		public ViewProductViewModel(ProductSearchViewModel viewModel) 
		{
			_productSearchViewModel = viewModel;
		}
		public ViewProductViewModel(string  productName)
		{
			LoadPopupCommand.Execute(productName);
		}

		[RelayCommand]
		async Task LoadPopup(string product)
		{
			if (product != null) 
			{
				_productSearchViewModel = new();
				Expression<Func<Invitm, bool>> predicate = item => item.BarCode == product;
				var search = await App.Database.GetFirstAsync<Invitm,bool>(predicate,null);
				if(search != null) 
				{
					Invitm Item = new Invitm
					{
						BarCode = search.BarCode,
						ItemCode = search.ItemCode,
						Description = search.Description,
						ActiveCost = search.ActiveCost,
						Unit = search.Unit,
						UnitPrice = search.UnitPrice,
					};
					_productSearchViewModel.SelectedInvItm = Item;
					OnPropertyChanged(nameof(_productSearchViewModel.SelectedInvItm));
				}
				
			}
		}
	}
}
