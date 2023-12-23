using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using Microsoft.Data.SqlClient;
using ParsPOS.Model;
using ParsPOS.Services;
using ParsPOS.Services.ViewSevices;
using ParsPOS.Views.BottomSheet;
using ParsPOS.Views.InventoryView;
using ParsPOS.Views.PopupView;
using PostSharp;
using System.Collections.ObjectModel;
using System.Data;
using System.Xml.Linq;

namespace ParsPOS.ViewModel
{
    public partial class PurchaseViewModel : BaseViewModel
    {
        public ObservableCollection<PurchaseDetTb> PurchaseItem { get; set; } = new();
        [ObservableProperty]
        PurchaseDetTb _purchaseDets;
        private readonly IDbConnection _connection;

        [ObservableProperty]
        short slno;
        [ObservableProperty]
        float qIH;
        [ObservableProperty]
        float averageCost;
        [ObservableProperty]
        float lpCost;

        [ObservableProperty]
        int seletedType = 0;
        [ObservableProperty]
        int selectOn = 0;

        private readonly SharedPurchaseService _sharedPurchaseService;    
        private readonly PopupButtonsSelectionWrapper _popSelectWrapper = new();
        [ObservableProperty]
        PurchasePopupViewModel _model ;
        
        public PurchaseViewModel(SharedPurchaseService purchaseService,IDbConnection connection) 
        {
            _connection = connection;
            _sharedPurchaseService = purchaseService;
            _sharedPurchaseService.ItemSelected += SharedDataService_ItemSelected;
        }

        [RelayCommand]
        async Task AddAsync()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(AddPurchase));
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
                PurchaseItem.Remove(PurchaseDets);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        //AddPurchase
        [RelayCommand]
        async Task AddPrdCodeAsync(string purchaseopt)
        {
            if (Enum.TryParse(purchaseopt, true, out PopupButtonsSelection selection))
            {
                switch (selection)
                {
                    case PopupButtonsSelection.ProductCode:
                        _popSelectWrapper.Selection = PopupButtonsSelection.ProductCode;
                        break;
                    case PopupButtonsSelection.ProductDescr:
                        _popSelectWrapper.Selection = PopupButtonsSelection.ProductDescr;
                        break;
                }
            }
            Model = new PurchasePopupViewModel(_popSelectWrapper,_sharedPurchaseService);
            PurchAdd Page = new PurchAdd(Model);
            await Page.ShowAsync();
        }
        
        [RelayCommand]
        async Task QtyChanged()
        {
            if(PurchaseDets.Qty != 0)
            {
                PurchaseDets.Linetotal = PurchaseDets.Qty * PurchaseDets.Cost;
                OnPropertyChanged(nameof(PurchaseDets));
            }
        }
        [RelayCommand]
        async Task FOCButtonAsync()
        {
            if(PurchaseDets != null)
            {
                await Shell.Current.GoToAsync(nameof(FOC));
            }
        }
        private async void SharedDataService_ItemSelected(object sender, Invitm selectedItem)
        {
            try
            {   
                var ItemCode = selectedItem.ItemCode;
                if (ItemCode != null)
                {
                    var sqlquery = $"SELECT InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE ItemCode = '{ItemCode}'";
                    var itemlist = await _connection.QueryAsync<dynamic>(sqlquery);
                    itemlist.ToList();
                    foreach(var a in itemlist)
                    {
                        PurchaseDets = new()
                        {
                            SlNo = Slno,
                            Code = ItemCode,
                            ProdDesr = a.Description,
                            Unit = a.Unit,
                            Cost = a.ActiveCost,
                            NetCost = a.ActiveCost,
                            //ActS_Price = a.UnitPrice,
                            //Mthd = 0,
                            //UVal = 0,
                            //DMthd =0,
                            //Taxpercent = a.Taxper,
                            //BaseId = a.BaseId,
                            ItemId = a.ItemId,
                        };
                        //AverageCost = a.CostAverage;
                        //QIH = a.QtyInHand;
                        //LpCost = a.LastPurchCost;

                    }

                    //Slno = Convert.ToInt16(PurchaseItem.Count() + 1);
                    //var a = await App.Database.EntryChk(ItemCode);
                }
            }
            catch (Exception ex)
            {

            }
           
        }
    }
}
