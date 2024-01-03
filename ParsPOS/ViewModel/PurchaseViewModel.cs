using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.Services;
using ParsPOS.Services.ViewSevices;
using ParsPOS.Views.BottomSheet;
using ParsPOS.Views.InventoryView;
using System.Collections.ObjectModel;
using System.Data;

namespace ParsPOS.ViewModel
{
    public partial class PurchaseViewModel : BaseViewModel
    {
        public ObservableCollection<PurchaseDetTb> PurchaseItem { get; set; } = new();
        [ObservableProperty]
        PurchaseDetTb _purchaseDets;
        private readonly IDbConnection _connection;
        [ObservableProperty]
        string selectedItemcode;

        [ObservableProperty]
        bool indicator;

        [ObservableProperty]
        short slno;

        [ObservableProperty]
        float qIH;

        [ObservableProperty]
        float averageCost;

        [ObservableProperty]
        float lpCost;

        [ObservableProperty]
        bool isDelVisible = false;

        [ObservableProperty]
        int seletedType = 0;

        [ObservableProperty]
        int selectOn = 0;

        private readonly SharedPurchaseService _sharedPurchaseService;    
        private readonly PopupButtonsSelectionWrapper _popSelectWrapper = new();
        [ObservableProperty]
        PurchasePopupViewModel _model ;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;
        public PurchaseViewModel(SharedPurchaseService purchaseService,IDbConnection connection) 
        {
           
				_connection = connection;
				commonHttpServices = new CommonHttpServices();
				client = commonHttpServices.GetHttpClient();
				//_sharedPurchaseService = purchaseService;
				//_sharedPurchaseService.ItemSelected += SharedDataService_ItemSelected;
           

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
            Model = new PurchasePopupViewModel(_popSelectWrapper,this,_connection);
            PurchAdd Page = new PurchAdd(Model);
            await Page.ShowAsync();
        }
        
        [RelayCommand]
        async Task QtyChanged()
        {
            try
            {
                if(PurchaseDets != null)
                {
					if (PurchaseDets.Qty != 0 && PurchaseDets.Cost != 0)
					{
						PurchaseDets.Linetotal = PurchaseDets.Qty * PurchaseDets.Cost;
						OnPropertyChanged(nameof(PurchaseDets));
						int index = PurchaseItem.IndexOf(PurchaseItem.FirstOrDefault(item => item.SlNo == PurchaseDets.SlNo));
						if (index != -1)
						{
							PurchaseItem[index] = PurchaseDets;
							OnPropertyChanged(nameof(PurchaseItem));
						}
					}
				}
			}
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
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

        [RelayCommand]
        async Task DeleteSelected()
        {
            if(PurchaseDets != null)
            {
                PurchaseItem.Remove(PurchaseDets);
                OnPropertyChanged(nameof(PurchaseItem));
                PurchaseDets = null;
            }
        }
        [RelayCommand]
        async Task LoadSelectedItm()
        {
            if(SelectedItemcode != null)
            {
                Indicator = true;
                IEnumerable<dynamic> itemlist = null;
                try
                {
                    var Code = SelectedItemcode;
                    if (Code != null)
                    {
                        if (PurchaseItem.Count == 0) Slno = 1;
                        else if (PurchaseDets != null) Slno = PurchaseDets.SlNo;
                        else Slno = (short)(PurchaseItem.Count + 1);
                        var baseurl = commonHttpServices.GetBaseUrl();
                        string dataApiUrl = $"{baseurl}/api/DirectDb/FetchItem?Code=";
                        string pageDataUrl = $"{dataApiUrl}{Code}";
                        if (App._Connected)
                        {
                            HttpResponseMessage response = await client.GetAsync(pageDataUrl);
                            string content = await response.Content.ReadAsStringAsync();
                            itemlist = JsonConvert.DeserializeObject<List<dynamic>>(content);
                        }
                        else
                        {
                            var sqlquery = $"SELECT InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE ItemCode = '{Code}'";
                            itemlist = await _connection.QueryAsync<dynamic>(sqlquery);
                            itemlist.ToList();
                        }
                        if (PurchaseDets != null)
                        {
                            if (PurchaseDets.IsCompleted == false)
                            {
                                int index = PurchaseItem.IndexOf(PurchaseItem.FirstOrDefault(item => item.SlNo == PurchaseDets.SlNo));
                                if (index != -1)
                                {
                                    PurchaseItem[index] = PurchaseDets;
                                    PurchaseItem.Remove(PurchaseDets);
                                    OnPropertyChanged(nameof(PurchaseItem));
                                }
                            }
                        }
                        foreach (var a in itemlist)
                        {
                            if (SelectOn == 0)
                            {
                                if (App._Connected == false) Code = a.ItemCode;
                            }
                            else if (SelectOn == 1) Code = a.BarCode;
                            else
                            {
                                if (a.SupplierNo != 0)
                                {
                                    var query = $"Select IC from SuppPrdTb where SupplierNo = '{a.SupplierNo}' AND ItemId  = {a.ItemId}";
                                    string supp = await _connection.ExecuteScalar<dynamic>(query);
                                    if (supp != null)
                                    {
                                        Code = supp;
                                    }
                                }
                            }
                            PurchaseDets = new()
                            {
                                SlNo = Slno,
                                Code = Code,
                                ProdDesr = a.Description,
                                Unit = a.Unit,
                                Cost = (double)(a.ActiveCost),
                                NetCost = (double)(a.ActiveCost),
                                ActS_Price = (float?)(a.UnitPrice),
                                Mthd = 0,
                                UVal = 0,
                                DMthd = 0,
                                PMult = (float?)(a.PMult),
                                Taxpercent = (float?)(a.Taxper),
                                BaseId = Convert.ToInt32(a.BaseId),
                                ItemId = Convert.ToInt32(a.ItemId),
                                IsCompleted = false
                            };
                            AverageCost = (float)a.CostAverage;
                            QIH = (float)a.QtyInHand;
                            LpCost = (float)a.LastPurchCost;

                        }
                        PurchaseItem.Add(PurchaseDets);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Indicator = false;
                    IsDelVisible = true;
                }
            }
        }

        [RelayCommand]
        async Task SubmitAsync()
        {
            if(PurchaseDets != null)
            {
				if (PurchaseDets.Qty == null || PurchaseDets.Qty == 0)
				{
					await Shell.Current.DisplayAlert("Alert", "Qty cannot be null", "Ok");
				}
				else
				{
                    if(PurchaseDets.Linetotal == 0 || PurchaseDets.Linetotal == null)
                    {
						QtyChangedCommand.Execute(null);
					}
					PurchaseDets.IsCompleted = true;
					PurchaseDets = null;
                    IsDelVisible = false;
				}
			}
        }
        [RelayCommand]
        async Task ClearAsync()
        {
            if(PurchaseDets !=null)
            {
                if (PurchaseDets.IsCompleted) 
                {
					PurchaseDets = null; 
                    IsDelVisible = false;
				} 
                else
                {
                    var result = await Shell.Current.DisplayAlert($"Alert","Purchase Detail is not saved if you want to save and clear ,then submit the Purchase","Yes","No");
                    if(result)
                    {
                        PurchaseItem.Remove(PurchaseDets);
                        PurchaseDets = null;
                    }
                }
            }
        }





























        //private async void SharedDataService_ItemSelected(object sender, Invitm selectedItem)
        //{
        //    try
        //    {   
        //        var Code = selectedItem.ItemCode;
        //        if (Code != null)
        //        {
        //            if (PurchaseItem.Count == 0) Slno = 1;
        //            var sqlquery = $"SELECT InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE ItemCode = '{Code}'";
        //            var itemlist = await _connection.QueryAsync<dynamic>(sqlquery);
        //            itemlist.ToList();
        //            if(PurchaseDets != null)
        //            {
        //                if(PurchaseDets.IsCompleted == false)
        //                {
        //                    int index = PurchaseItem.IndexOf(PurchaseItem.FirstOrDefault(item => item.SlNo == PurchaseDets.SlNo));
        //                    if (index != -1)
        //                    {
        //                        PurchaseItem[index] = PurchaseDets;
        //                        PurchaseItem.Remove(PurchaseDets);
        //                        OnPropertyChanged(nameof(PurchaseItem));
        //                    }
        //                }
        //            }
        //            foreach(var a in itemlist)
        //            {
        //                Code = a.ItemCode;
        //                if (SelectOn == 0) Code = a.ItemCode;
        //                else if (SelectOn == 1) Code = a.BarCode;
        //                else
        //                {
        //                    if(a.SupplierNo != 0)
        //                    {
        //                        var query = $"Select IC from SuppPrdTb where SupplierNo = '{a.SupplierNo}' AND ItemId  = {a.ItemId}";
        //                        string supp = await _connection.ExecuteScalar<dynamic>(sqlquery);
        //                        if(supp != null)
        //                        {
        //                            Code = supp;
        //                        }
        //                    }
        //                }
        //                PurchaseDets = new()
        //                {
        //                    SlNo = Slno,
        //                    Code = Code,
        //                    ProdDesr = a.Description,
        //                    Unit = a.Unit,
        //                    Cost = a.ActiveCost,
        //                    NetCost = a.ActiveCost,
        //                    ActS_Price = (float?)(a.UnitPrice),
        //                    Mthd = 0,
        //                    UVal = 0,
        //                    DMthd = 0,
        //                    Taxpercent = (float?)(a.Taxper),
        //                    BaseId = Convert.ToInt32(a.BaseId),
        //                    ItemId = Convert.ToInt32(a.ItemId),
        //                    IsCompleted = false
        //                };
        //                AverageCost = (float)a.CostAverage; 
        //                QIH = (float)a.QtyInHand;           
        //                LpCost = (float)a.LastPurchCost;

        //            }
        //            PurchaseItem.Add(PurchaseDets);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
           
        //}
    }
}
