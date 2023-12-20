using CommunityToolkit.Mvvm.Input;
using ParsPOS.Views.InventoryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public partial class FOCViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task CancelButtonAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddPurchase));
        }
        [RelayCommand]
        async Task OKButtonAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddPurchase));
        }
    }
}
