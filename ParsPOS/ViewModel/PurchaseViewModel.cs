using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.ResultModel;
using System.Collections.ObjectModel;

namespace ParsPOS.ViewModel
{
    public partial class PurchaseViewModel : BaseViewModel
    {
        public ObservableCollection<PurchaseDetTb> PurchaseItem { get; set; } = new();
        [ObservableProperty]
        PurchaseDetTb _purchaseDet = new();

        public PurchaseViewModel() 
        {

        }

        [RelayCommand]
        async Task AddAsync()
        {
            try
            {
                if (PurchaseItem.Count == 0)
                {
                    PurchaseDet = new();
                    PurchaseDet.SlNo = 1;
                    PurchaseItem.Add(PurchaseDet);

                }
                else
                {
                    var lastItem = PurchaseItem.LastOrDefault();
                    if (lastItem != null && lastItem.Code.HasValue)
                    {
                        var slno = (short)(lastItem.SlNo + 1);
                        PurchaseDet = null;
                        PurchaseDet = new();
                        PurchaseDet.SlNo = slno;
                        PurchaseItem.Add(PurchaseDet);
                    }
                }
                
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
            
        }
        [RelayCommand]
        async Task RemoveAsync()
        {
            try
            {
                PurchaseItem.Remove(PurchaseDet);
                //for (short i = 0; i < PurchaseItem.Count; i++)
                //{
                //    PurchaseItem[i].SlNo = (short)(i + 1);
                //}
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}
