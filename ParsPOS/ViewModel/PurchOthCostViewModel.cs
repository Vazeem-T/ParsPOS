using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
	public partial class PurchOthCostViewModel : BaseViewModel
	{
		[ObservableProperty]
		PurchaseViewModel _purchaseViewModel;
		public PurchOthCostViewModel(PurchaseViewModel purchaseViewModel)
		{
			_purchaseViewModel = purchaseViewModel;		
		}


	}
}
