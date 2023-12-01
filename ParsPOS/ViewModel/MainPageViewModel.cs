using CommunityToolkit.Mvvm.Input;
using ParsPOS.Views;
using ParsPOS.Views.InventoryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task PurchaseAsync()
        {
            await Shell.Current.GoToAsync(nameof(Purchase));
        }
        [RelayCommand]
        async Task LogoutAsync()
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
