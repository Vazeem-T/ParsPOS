using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.SaleModel;
using ParsPOS.Views;
using System.Collections.ObjectModel;

namespace ParsPOS.ViewModel
{
    public partial class SaleHoldViewModel : BaseViewModel
    {
        public ObservableCollection<NizPoscmn> NizPoscmns { get; set; } = new();
        public ObservableCollection<NizPosdet> NizPosdet { get; set;} = new();
        public SaleHoldViewModel()
        {
            LoadDtOnInit();
        }

        [ObservableProperty]
        bool recieptVisibility = false;

        [ObservableProperty]
        string _companyName;

        [ObservableProperty]
        NizPoscmn _selectedOnHold;




        [RelayCommand]
        async Task SelectedItem(NizPoscmn nizPoscmn)
        {
            SelectedOnHold = nizPoscmn;
            NizPosdet.Clear();
            if(SelectedOnHold != null) 
            {
                RecieptVisibility = true;
                var compname = await App.Database.GetLastSettings();
                CompanyName = compname.CompanyName;
                var HoldData = await App.SaleDb.GetNizdetOnHoldNo(SelectedOnHold.HoldNo);
                if(HoldData != null) 
                {
                    foreach (var item in HoldData)
                    {
                        NizPosdet.Add(item);
                    }
                }
            }
        }


        [RelayCommand]
        async Task RemoveOnHoldSelectedItem()
        {
            if(SelectedOnHold != null)
            {
                var result = await Shell.Current.DisplayAlert("Alert", $"Do you want to Delete item with CustomerId : {SelectedOnHold.CustNo}", "Yes", "No");
                if(result)
                {
                    await App.SaleDb.DeletenizPosdtOnHold(SelectedOnHold.HoldNo);
                    NizPoscmns.Remove(SelectedOnHold);
                    await App.SaleDb.DeleteSelectedPoscmn(SelectedOnHold.HoldNo);
                    SelectedOnHold= null;
                    NizPosdet.Clear();
                    RecieptVisibility = false;
                }
            }
        }

        async Task LoadDtOnInit()
        {
            var PageData = await App.SaleDb.GetAllNizPoscmn();
            if(PageData != null)
            {
                foreach(var item in PageData)
                {
                    var nizdet = await App.SaleDb.GetNizdetOnHoldNo(item.HoldNo);
                    if(nizdet != null)
                    {
                        item.TotalPrice = double.Parse(string.Format("{0:0.00}", nizdet.Sum(item => item.PriceWithTax)));
                        item.TotalQty = nizdet.Sum(x => x.Qty) ?? 0;
                    }
                    NizPoscmns.Add(item);
                }
            }
        }



        [RelayCommand]
        async Task UseOnHoldAsync()
        {
            try
            {               
                if (SelectedOnHold != null)
                {
                    string queryParameter = $"HoldNo={SelectedOnHold.HoldNo}";
                    await Shell.Current.GoToAsync($"{nameof(Sale)}?{queryParameter}");
                    //LoadHold p = new(this);
                    //p?.Close();
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert",ex.Message,"OK");
            }
        }
    }
}
