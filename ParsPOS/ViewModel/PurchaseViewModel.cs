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
		public ObservableCollection<string> PurchaseType { get; set; } = new ();

		[ObservableProperty]
        PurchaseDetTb _purchaseDets;
        private readonly IDbConnection _connection;
        [ObservableProperty]
        float fCRt = 1;
        //FCRT FOR foreign currency rate
        [ObservableProperty]
        double othCost;

		[ObservableProperty]
        string selectedItemcode;

        [ObservableProperty]
        string supplAccAlias;

		[ObservableProperty]
		string supplAccDesc;

		[ObservableProperty]
		string purchAcAlias;

		[ObservableProperty]
		string purchAcDesc;

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

        [ObservableProperty]
        double discount;

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
			LoadOnOpenCommand.Execute(null);
			//_sharedPurchaseService = purchaseService;
			//_sharedPurchaseService.ItemSelected += SharedDataService_ItemSelected;
		}
		[RelayCommand]
        async Task LoadOnOpen()
        {
            try
            {
				var PrefixItem = await App.Database.GetPrefixItems(3);
                if(PrefixItem != null) 
                {
					foreach (var item in PrefixItem)
					{
						PurchaseType.Add(item.VoucherName);
					}
					PurchaseTypeChangedCommand.Execute(null);
                    OnPropertyChanged(nameof(SeletedType));
				}
			}
            catch (Exception ex)
            {
            }
		}

        [RelayCommand]
		async Task PurchaseTypeChanged()
        {
            try
            {
				if (SeletedType == 0)
				{
					PreFixTb GetAcNo = await App.Database.GetVoucherName(PurchaseType[0]);
					AccMast Ac1Detail = await App.Database.GetMasterAccountDetail(GetAcNo.ANo ?? 0);
					PurchAcAlias = Ac1Detail.Alias;
					PurchAcDesc = Ac1Detail.AccDescr;
					SupplAccAlias = null;
                    SupplAccDesc = null;
				}
				else
				{
					PreFixTb GetAcNo = await App.Database.GetVoucherName(PurchaseType[1]);
					AccMast Ac1Detail = await App.Database.GetMasterAccountDetail(GetAcNo.ANo ?? 0);
					PurchAcAlias = Ac1Detail.Alias;
					PurchAcDesc = Ac1Detail.AccDescr;
					AccMast Ac2Detail = await App.Database.GetMasterAccountDetail(GetAcNo.ANo2 ?? 0);
					SupplAccAlias = Ac2Detail.Alias;
					SupplAccDesc = Ac2Detail.AccDescr;
				}
			}
			catch (Exception ex)
            {
            }
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
                        //PurchaseDets.NetCost = PurchaseDets.Cost;
                        await CalOthCost();
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
                                Cost = (double)(((a.LastPurchCost != 0) ? a.LastPurchCost : ( a.CostAverage > 0) ? a.CostAverage : (a.ActiveCost/a.PMult)) * a.PMult),
                                ActualCost = (double)(((a.LastPurchCost != 0) ? a.LastPurchCost : (a.CostAverage > 0) ? a.CostAverage : (a.ActiveCost / a.PMult)) * a.PMult),
								//NetCost = (double)((a.CostAverage > 0) ? a.CostAverage * a.PMult : a.ActiveCost),
                                ActS_Price = (float)(a.UnitPrice),
                                ActOthCost = 0,
								Mthd = 0,
                                UVal = 0,
                                DMthd = 0,
                                PMult = (float)(a.PMult),
                                Taxpercent = (float)(a.Taxper),
                                BaseId = Convert.ToInt32(a.BaseId),
                                ItemId = Convert.ToInt32(a.ItemId),
                                IsCompleted = false
                                
                            };
                            AverageCost = (float)a.CostAverage;
                            QIH = (float)a.QtyInHand;
                            LpCost = (float)a.LastPurchCost;
                        }
                        PurchaseItem.Add(PurchaseDets);
                        CalOthCost();
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
        
        public async Task<double> CalOthCost()
		{
            try
            {
				double tOthVal = 0;
				double tBAmt = 0;
				double tBDAmt = 0;
				double tDAmt = 0;
				double AUnitCost = 0;
				double CostWoDisc = 0;
				double CalOthCost = 0;

				foreach (var item in PurchaseItem)
				{
					if (item.IsRtn == true) goto Next1;
					//if(item.Qty == 0)item.Qty = 0;
					if (item.Mthd != 0) tOthVal += (double)(item.ActOthCost * item.Qty + item.AFOC);
					else tBAmt += (double)((item.ActualCost - item.ADisc) * item.Qty);
					if (item.DMthd != 0) tDAmt += (double)(item.ActualDisc * item.Qty + item.AFOC);
					else tBDAmt += (double)((item.ActualCost - item.ADisc) * item.Qty);
					item.TtlLnFOCAmt = 0;
				}
			Next1:;
				await DoDistributeFOCCost();
				tOthVal = (double)(OthCost / FCRt - tOthVal);
				tDAmt = Discount - tDAmt;
				foreach (var item in PurchaseItem)
				{
					AUnitCost = 0;
					AUnitCost = (double)(item.ActualCost - item.ADisc);

					if (item.IsRtn == true)
					{
						item.NetCost = AUnitCost;
						item.ActualDisc = 0;
						goto Next2;
					}
					CostWoDisc = 0;
					if ((item.Qty + item.AFOC) > 0)
						CostWoDisc = (double)((AUnitCost * (item.Qty + item.AFOC) - item.TtlLnFOCAmt) / (item.Qty + item.AFOC));

					if (item.Mthd == 0)
					{
						if (tBAmt == 0) item.ActOthCost = 0;
						else
						{
							if ((item.Qty + item.AFOC) > 0) item.ActOthCost = (double)(tOthVal * CostWoDisc / tBAmt);
							else item.ActOthCost = 0;
						}
					}

					if (item.DMthd == 0)
					{
						if (tBDAmt == 0) item.ActualDisc = 0;
						else
						{
							if ((item.Qty + item.AFOC) > 0) item.ActualDisc = (float)(tDAmt * CostWoDisc / tBDAmt);
							else item.ActOthCost = 0;
						}
					}

					CalOthCost += (double)((item.Qty + item.AFOC) * (item.ActOthCost) - item.ActualDisc);

					item.NetCost = ((CostWoDisc + item.ActOthCost) - item.ActualDisc);
				}
			Next2:;
				foreach (var item in PurchaseItem)
				{
					if (item.SlNo == 0)
					{
						item.NetCost = 0;
					}
				}

				return CalOthCost;
			}
            catch (Exception ex)
            {
                return 0;
            }
			
		}

        async Task DoDistributeFOCCost()
        {
			int i, j;
			string[] slNo;
			int intX;
			double ttl;
			double focVal;

            for (i = 0; i < PurchaseItem.Count;i++)
			{
				if (PurchaseItem[i].IsRtn == true)
				{
                    PurchaseItem[i].TtlLnFOCAmt = 0;
					goto Nexti;
				}

				if (PurchaseItem[i].SlNo != 0 && PurchaseItem[i].AFOC != 0)
				{
					focVal = (double)((PurchaseItem[i].ActualCost - PurchaseItem[i].ADisc) * PurchaseItem[i].AFOC);

					if (focVal > 0)
					{
						if (string.IsNullOrWhiteSpace(PurchaseItem[i].FOCCostMapg))
						{
                            PurchaseItem[i].TtlLnFOCAmt = (float)(PurchaseItem[i].TtlLnFOCAmt + focVal);
						}
						else
						{
							slNo = PurchaseItem[i].FOCCostMapg.Split(',');
							ttl = 0;
							for (intX = 0; intX <= slNo.GetUpperBound(0); intX++)
							{
								for (j = 1; j <= PurchaseItem.Count; j++)
								{
									if (PurchaseItem[j].SlNo == double.Parse(slNo[intX]) && PurchaseItem[j].IsRtn != true)
									{
										ttl += (double)((PurchaseItem[j].ActualCost - PurchaseItem[j].ADisc) * (PurchaseItem[j].Qty + PurchaseItem[j].AFOC));
										break;
									}
								}
							}

							for (intX = 0; intX <= slNo.GetUpperBound(0); intX++)
							{
								for (j = 1; j <= PurchaseItem.Count; j++)
								{
									if ((PurchaseItem[j].SlNo.ToString() == slNo[intX]) && PurchaseItem[j].IsRtn != true)
									{
                                        PurchaseItem[j].TtlLnFOCAmt = (float)((PurchaseItem[j].TtlLnFOCAmt) + focVal * (PurchaseItem[j].ActualCost -  PurchaseItem[j].ADisc) * (PurchaseItem[j].Qty +  PurchaseItem[j].AFOC) / ttl);
										break;
									}
								}
							}

							Array.Clear(slNo, 0, slNo.Length);
						}
					}
				}
			}
        Nexti:;
		}

		[RelayCommand]
        async Task SubmitAsync()
        {
			if (PurchaseDets != null)
			{

				
				QtyChangedCommand.Execute(null);
				PurchaseDets.IsCompleted = true;
				PurchaseDets = null;
				IsDelVisible = false;

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
