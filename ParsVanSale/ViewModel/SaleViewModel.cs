using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Views;
using ParsVanSale.Model;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using ParsVanSale.Views.BottomSheet;
using System.Data;
using ParsVanSale.ViewModel.BottomSheetViewModel;
using Dapper;
using ParsVanSale.Views.Sale;
using ParsVanSale.Services;

namespace ParsVanSale.ViewModel
{
	public partial class SaleViewModel : BaseViewModel
	{

		public ObservableCollection<PurchaseDetTb> SaleItem { get; set; } = new();
		//public ObservableCollection<string> PurchaseType { get; set; } = new();
		public ObservableCollection<string> DeviceList { get; set; } = new();
		private readonly IDbConnection _connection;
		private bool isButtonClickable = true;


		[ObservableProperty]
		short slno;

		[ObservableProperty]
		PurchaseDetTb saleDet;

		[ObservableProperty]
		PurchaseDetCmn saleDetCmn;

		[ObservableProperty]
		string selectedItemcode;

		[ObservableProperty]
		string partyAcAlias;

		[ObservableProperty]
		string partyAcDesc;

		[ObservableProperty]
		int partyAcNo;

		[ObservableProperty]
		int selectOn = 0;

		//[ObservableProperty]
		//int seletedType = 0;

		[ObservableProperty]
		bool delButtonVisible = false;

		[ObservableProperty]
		float qty;

		[ObservableProperty]
		double trQty;

		[ObservableProperty]
		double totalPrice;
		[ObservableProperty]
		double ttlLnDisc;
		[ObservableProperty]
		bool chkNoVAT = false;
		[ObservableProperty]
		double discount;

		[ObservableProperty]
		double tax;

		[ObservableProperty]
		double totalWTax;
		[ObservableProperty]
		int mainSlNo;

		private readonly IPrintServices _printServices;
		public SaleViewModel(IDbConnection connection,IServiceProvider provider)
		{
			SaleDetCmn = new();
			SaleDet = new();
			_connection = connection;
			LoadOnOpenCommand.Execute(null);
			_printServices = provider.GetService<IPrintServices>();
		
		}

		[RelayCommand]
		async Task LoadOnOpen()
		{
			try
			{
				await Task.Run(async () =>
				{
					
					SaleDetCmn.InvDate = DateTime.Now;
					OnPropertyChanged(nameof(SaleDetCmn));
					Expression<Func<PurchaseDetCmn, int>> orderBy = item => item.Id;
					Expression<Func<PurchaseDetCmn, bool>> iscompletePredicate = item => item.isCompleted == true;
					Expression<Func<PurchaseDetTb, bool>> filterDet = item => item.Serial == 0;
					var ItemDetail = await App.Database.GetLastAsync(iscompletePredicate, orderBy);
					var DetFind = await App.Database.GetFilteredAsync<PurchaseDetTb, bool>(filterDet, null);
					if (DetFind.Count() > 0)
					{
						foreach (var item in DetFind)
						{
							SaleItem.Add(item);
						}
						if (ItemDetail != null)
						{
							MainSlNo = ItemDetail.SlNo + 1;
						}
						else MainSlNo = 1;
					}
					else
					{
						
						Expression<Func<PurchaseDetCmn, bool>> predicate = item => item.isCompleted == false;
						var lastItem = await App.Database.GetLastAsync(predicate, orderBy);
						if (lastItem != null && lastItem.Id > 0)
						{
							MainSlNo = lastItem.SlNo;
							SaleDetCmn = lastItem;

							Expression<Func<PurchaseDetTb, bool>> sort = item => item.Serial == lastItem.Id;
							var pageData = await App.Database.GetFilteredAsync<PurchaseDetTb, bool>(sort, null);

							if (pageData != null)
							{
								foreach (var item in pageData)
								{
									SaleItem.Add(item);
								}
							}
						}
						else if (ItemDetail != null && ItemDetail.Id > 0)
						{
							MainSlNo = ItemDetail.SlNo + 1;
							//Expression<Func<PurchaseDetTb, bool>> sort = item => item.Serial == ItemDetail.Id;
							//var pageData = await App.Database.GetFilteredAsync<PurchaseDetTb, bool>(sort, null);

							//if (pageData != null)
							//{
							//	foreach (var item in pageData)
							//	{
							//		SaleItem.Add(item);
							//	}
							//}
						}
						else
						{
							MainSlNo = 1;
						}
					}
					OnPropertyChanged(nameof(MainSlNo));
					AssignTotal(true);
				});

			}
			catch (Exception ex)
			{
			}
		}

		[RelayCommand]
		async Task OpenPopAsync(string Pop)
		{

			if (Pop == "Party")
			{
				PartyViewModel model = new(_connection, this);
				PartyBtmSht page = new(model);
				await page.ShowAsync();
			}
			else
			{
				AddProdViewModel model = new(this);
				ProdSearch page = new(model);
				await page.ShowAsync();
			}
		}

		[RelayCommand]
		async Task GoToAddSaleAsync()
		{
			try
			{
				await Shell.Current.GoToAsync($"{nameof(AddPurchase)}");
			}
			catch (Exception ex)
			{
				throw;
			}

		}
		[RelayCommand]
		async Task LoadCmn()
		{
			OnPropertyChanged(nameof(SaleDetCmn));
		}

		[RelayCommand]
		async Task LoadSelectedItm()
		{
			if (SelectedItemcode != null)
			{
				IEnumerable<dynamic> itemlist = null;
				try
				{
					var Code = SelectedItemcode;
					if (Code != null)
					{
						if (SaleItem.Count == 0) Slno = 1;
						else if (SaleDet != null) Slno = SaleDet.SlNo;
						else Slno = (short)(SaleItem.Count + 1);
						var sqlquery = $"SELECT InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE ItemCode = '{Code}'";
						itemlist = await _connection.QueryAsync<dynamic>(sqlquery);
						itemlist.ToList();

						if (SaleDet != null)
						{
							if (SaleDet.IsCompleted == false)
							{
								int index = SaleItem.IndexOf(SaleItem.FirstOrDefault(item => item.SlNo == SaleDet.SlNo));
								if (index != -1)
								{
									SaleItem[index] = SaleDet;
									SaleItem.Remove(SaleDet);
									OnPropertyChanged(nameof(SaleItem));
								}
							}
						}
						foreach (var a in itemlist)
						{
							if (SelectOn == 0)
							{
								Code = a.ItemCode;
							}
							else Code = a.BarCode;
							SaleDet = new()
							{
								SlNo = Slno,
								Code = Code,
								ProdDesr = a.Description,
								Unit = a.Unit,
								Cost = (double)(((a.LastPurchCost != 0) ? a.LastPurchCost : (a.CostAverage > 0) ? a.CostAverage : (a.ActiveCost / a.PMult)) * a.PMult),
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
							//AverageCost = (float)a.CostAverage;
							//QIH = (float)a.QtyInHand;
							//LpCost = (float)a.LastPurchCost;
						}
						SaleItem.Add(SaleDet);
						DelButtonVisible = true;
						//AssignTotal(true);
					}
				}
				catch (Exception ex)
				{

				}
				finally
				{
				}
			}
		}

		[RelayCommand]
		async Task SearchProd()
		{
			if (SaleDet.Code != null)
			{
				IEnumerable<dynamic> itemlist = null;
				try
				{
					var Code = SaleDet.Code;
					if (Code != null)
					{
						if (SaleItem.Count == 0) Slno = 1;
						else if (SaleDet != null) Slno = SaleDet.SlNo;
						else Slno = (short)(SaleItem.Count + 1);
						string sqlquery;
						sqlquery = $"SELECT InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE ItemCode = '{Code}'";
						itemlist = await _connection.QueryAsync<dynamic>(sqlquery);
						itemlist.ToList();
						if(itemlist.Count() == 0)
						{
							sqlquery = $"SELECT InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE Barcode = '{Code}'";
							itemlist = await _connection.QueryAsync<dynamic>(sqlquery);
							itemlist.ToList();
						}
						if (itemlist.Count() != 0)
						{
							if (SaleDet != null)
							{
								if (SaleDet.IsCompleted == false)
								{
									int index = SaleItem.IndexOf(SaleItem.FirstOrDefault(item => item.SlNo == SaleDet.SlNo));
									if (index != -1)
									{
										SaleItem[index] = SaleDet;
										SaleItem.Remove(SaleDet);
										OnPropertyChanged(nameof(SaleItem));
									}
								}
							}
							foreach (var a in itemlist)
							{
								if (SelectOn == 0)
								{
									Code = a.ItemCode;
								}
								else Code = a.BarCode;
								
								SaleDet = new()
								{
									SlNo = Slno,
									Code = Code,
									ProdDesr = a.Description,
									Unit = a.Unit,
									Cost = (double)(((a.LastPurchCost != 0) ? a.LastPurchCost : (a.CostAverage > 0) ? a.CostAverage : (a.ActiveCost / a.PMult)) * a.PMult),
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
								//AverageCost = (float)a.CostAverage;
								//QIH = (float)a.QtyInHand;
								//LpCost = (float)a.LastPurchCost;
							}
							SaleItem.Add(SaleDet);
							DelButtonVisible = true;
						}
						else await Shell.Current.DisplayAlert("Alert", "Item cannot be found", "OK");
						//AssignTotal(true);
					}
				}
				catch (Exception ex)
				{
					await Shell.Current.DisplayAlert("Alert",ex.Message,"OK");
				}
				finally
				{
				}
			}
		}

		[RelayCommand]
		async Task SubmitAsync()
		{
			if (SaleDet != null)
			{
				DelButtonVisible = false;
				if (SaleDet.IsCompleted == false)
				{
					SaleDet.IsCompleted = true;
					QtyChangedCommand.Execute(SaleDet);
					await App.Database.InsertAsync(SaleDet);
				}
				else
				{
					QtyChangedCommand.Execute(SaleDet);
					await App.Database.UpdateAsync(SaleDet);
				}
				SaleDet = new();
				Qty = 0;
			}
		}
		[RelayCommand]
		async Task DeleteAsync()
		{
			if (SaleDet != null)
			{
				SaleItem.Remove(SaleDet);
				if (SaleDet.IsCompleted == true) await App.Database.DeleteAsync(SaleDet);
				SaleDet = new();
				Qty = 0;
				DelButtonVisible = false;
			}
		}
		[RelayCommand]
		async Task SelectionChanged()
		{
			DelButtonVisible = true;
			if(SaleDet != null)
			{
				if(SaleDet.IsFOC == true) Qty = (float)(SaleDet.AFOC);
				else Qty = (float)(SaleDet.Qty);
				OnPropertyChanged(nameof(Qty));
			}
		}

		private void GetDeviceList()
		{
			//IPrintServices service = DependencyService.Get<IPrintServices>();
			var getDeviceList = _printServices.GetDeviceList();

			if (getDeviceList == null)
				return;

			if (getDeviceList.Count == 0)
			{
				App.Current.MainPage.DisplayAlert("Alert", "No Bluetooth Device found", "Ok");
			}
			else
			{
				var deviceList = new List<string>(getDeviceList);
				foreach (var device in deviceList) 
				{
					DeviceList.Add(device);
				}
			}
		}
		[RelayCommand]
		async Task DeleteAll()
		{
			await App.Database.DeleteAllAsync<PurchaseDetCmn>();
			await App.Database.DeleteAll<PurchaseDetTb>();
		}

		[RelayCommand]
		async Task PrintOnSubmit()
		{
			try
			{
				
				if (string.IsNullOrWhiteSpace(SaleDetCmn.Description) || string.IsNullOrWhiteSpace(SaleDetCmn.Reference) || (SaleDetCmn.SuppAcNo == 0))
				{
					await Shell.Current.DisplayAlert("Alert", "Sale Entry Cannot be null", "OK");
				}
				else if(SaleItem.Count > 0)
				{
					AssignTotal(true);
					var itemsToRemove = SaleItem.Where(item => item.AFOC == 0 && item.Qty == 0).ToList();
					foreach (var itemToRemove in itemsToRemove)
					{
						SaleItem.Remove(itemToRemove);
					}
					SaleDetCmn.SlNo = MainSlNo;
					SaleDetCmn.isCompleted = true;
					SaleDetCmn.CreatdTm = DateTime.Now;
					await App.Database.InsertAsync(SaleDetCmn);
					Expression<Func<PurchaseDetCmn, int>> orderered = item => item.Id;
					var SaleCmnadded = await App.Database.GetLastAsync(null, orderered);
					if(SaleCmnadded.Id != 0)
					{
						foreach (var item in SaleItem)
						{
							item.Serial = SaleCmnadded.Id;
							await App.Database.UpdateAsync(item);
						}
					}

					Expression<Func<SettingsTb, int>> orderBy = item => item.Id;
					SettingsTb settings = await App.Database.GetFirstAsync(null, orderBy);
					if(settings.PrintOnsubmit == true) 
					{
						string boldCompanyName = settings.CompanyName.ToUpper();
						string doubleWidthHeight = "\x1B" + "!" + "\x30";
						string invoiceText = doubleWidthHeight + boldCompanyName;
						int totalCharacters = 26;
						int companyNameLength = boldCompanyName.Length;
						int spacesToAdd = (totalCharacters - companyNameLength) / 2;
						if (spacesToAdd < 0)
						{
							spacesToAdd = -spacesToAdd + spacesToAdd;
						}
						string spaces = new string(' ', spacesToAdd);
						invoiceText = spaces + invoiceText;
						string resetFormat = "\x1B" + "!" + "\x00";
						invoiceText += resetFormat;
						invoiceText += "\n\n";
						invoiceText += $"Invoice No : {MainSlNo}\n";
						invoiceText += $"Customer : {SaleDetCmn.SuppDesc}\n";
						invoiceText += $"Date : {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}\n";
						invoiceText += "Item               Qty     Price\n";
						invoiceText += "--------------------------------\n";
						foreach (var item in SaleItem)
						{
							string itemName = item.ProdDesr.Length >= 15 ? item.ProdDesr.Substring(0, 15) : item.ProdDesr.PadRight(15);
							string itemQty = item.Qty.ToString("0.00").PadLeft(7);
							string itemcost = item.Cost.ToString("0.00").PadLeft(10);
							invoiceText += $"{itemName,-15}{itemQty,-7}{itemcost,-10}\n";
						}
						invoiceText += "--------------------------------\n";
						var text = (TotalPrice + Tax).ToString("0.00");
						invoiceText += $"NET{TotalPrice.ToString("0.00").PadLeft(29)}";
						invoiceText += $"VAT{Tax.ToString("0.00").PadLeft(29)}";
						invoiceText += $"Total{text.PadLeft(27)}";
						invoiceText += "\n\n\n\n";
						GetDeviceList();
						selectedDevice = DeviceList.FirstOrDefault();
						await _printServices.Print(selectedDevice, settings.Logo, invoiceText);
					}
					MainSlNo = SaleCmnadded.SlNo + 1;
					OnPropertyChanged(nameof(MainSlNo));
					SaleDetCmn = new();
					SaleDet = new();
					SaleItem = new();
					SaleDetCmn.InvDate = DateTime.Now;
					PartyAcAlias = "".Trim();
					PartyAcDesc = "".Trim();
					PartyAcNo = 0;
					OnPropertyChanged(nameof(SaleItem));
					OnPropertyChanged(nameof(SaleDet));
					OnPropertyChanged(nameof(SaleDetCmn));
				}
				else
				{
					await Shell.Current.DisplayAlert("Alert", "Add any Item", "OK");
				}

			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert",ex.Message,"OK");
			}
		}

		public string selectedDevice;
		void MyDevicePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			selectedDevice = ((Picker)sender).SelectedItem as string;
		}

		[RelayCommand]
		async Task MapFOCAsync()
		{
			if (SaleDet != null)
			{
				foreach (var item in SaleItem)
				{
					item.ISMapping = false;
					if (SaleDet.FOCCostMapg != null)
					{
						string[] pairs = SaleDet.FOCCostMapg.Split(',');
						foreach (var pair in pairs)
						{
							if (int.TryParse(pair, out int pairNumber))
							{
								if (pairNumber == item.SlNo)
								{
									item.ISMapping = true;
								}
							}
						}
					}
				}

				await Shell.Current.GoToAsync(nameof(MapFOC));
			}
				
		}
		[RelayCommand]
		async Task QtyChanged()
		{
			try
			{
				if (SaleDet != null)
				{
					if (Qty != 0)
					{
						if (SaleDet.IsFOC == true)
						{
							SaleDet.Qty = 0;
							SaleDet.AFOC = Qty;
						}
						else
						{
							SaleDet.Qty = Qty;
							SaleDet.AFOC = 0;
						}
						SaleDet.Linetotal = SaleDet.Qty * SaleDet.Cost;
						//SaleDet.NetCost = SaleDet.Cost;
						AssignTotal(true);
						OnPropertyChanged(nameof(SaleDet));
						int index = SaleItem.IndexOf(SaleItem.FirstOrDefault(item => item.SlNo == SaleDet.SlNo));
						if (index != -1)
						{
							SaleItem[index] = SaleDet;
							OnPropertyChanged(nameof(SaleItem));
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
		async Task PurchaseRightButton()
		{
			Expression<Func<PurchaseDetCmn, int>> orderBy = item => item.Id;
			var lastItem = await App.Database.GetLastAsync(null, orderBy);
			if (lastItem != null && lastItem.Id > 0)
			{
				var UpdtdSlNo = MainSlNo;
				if (MainSlNo < lastItem.SlNo)
				{
					doagaian: 
					UpdtdSlNo++;
					Expression<Func<PurchaseDetCmn, bool>> fetch = item => item.SlNo == UpdtdSlNo;
					var getitem = await App.Database.GetLastAsync(fetch, orderBy);
					if (getitem == null) goto doagaian;
					else
					{
						SaleItem.Clear();
						SaleDetCmn = getitem;
						MainSlNo = getitem.SlNo;
						Expression<Func<PurchaseDetTb, bool>> sort = item => item.Serial == getitem.Id;
						var pageData = await App.Database.GetFilteredAsync<PurchaseDetTb, bool>(sort, null);
						foreach ( var item in pageData ) 
						{
							SaleItem.Add(item);
						}
						OnPropertyChanged(nameof(SaleItem));
						OnPropertyChanged(nameof(SaleDetCmn));
						OnPropertyChanged(nameof(MainSlNo));
					}
				}
			}
		}
		[RelayCommand]
		async Task PurchaseLeftButton()
		{
			Expression<Func<PurchaseDetCmn, int>> orderBy = item => item.Id;
			var lastItem = await App.Database.GetFirstAsync(null, orderBy);
			if (lastItem != null && lastItem.Id > 0)
			{
				var UpdtdSlNo = MainSlNo;
				if (MainSlNo > lastItem.SlNo && MainSlNo != 1)
				{
				doagaian:
					UpdtdSlNo--;
					Expression<Func<PurchaseDetCmn, bool>> fetch = item => item.SlNo == UpdtdSlNo;
					var getitem = await App.Database.GetLastAsync(fetch, orderBy);
					if (getitem == null) goto doagaian;
					else
					{
						SaleItem.Clear();
						SaleDetCmn = getitem;
						MainSlNo = getitem.SlNo;
						Expression<Func<PurchaseDetTb, bool>> sort = item => item.Serial == getitem.Id;
						var pageData = await App.Database.GetFilteredAsync<PurchaseDetTb, bool>(sort, null);
						foreach (var item in pageData)
						{
							SaleItem.Add(item);
						}
						OnPropertyChanged(nameof(SaleItem));
						OnPropertyChanged(nameof(SaleDetCmn));
						OnPropertyChanged(nameof(MainSlNo));
					}
				}
			}
		}

		[RelayCommand]
		async Task SubmitFOCAsync()
		{
			var afocItems = SaleItem.Where(item => item.ISMapping == true);
			SaleDet.FOCCostMapg = string.Join(",", afocItems.Select(item => item.SlNo));
			await Shell.Current.GoToAsync("..");
		}
		private async void AssignTotal(bool rfrshDisp = false)
		{
			try
			{
				int i;
				double ttl = 0;
				double qty = 0;
				double oth = 0;
				double tax = 0;

				for (i = 0; i < SaleItem.Count; i++)
				{
					if ((SaleItem[i].Discpercent) > 100 || ((SaleItem[i].ADisc) > (SaleItem[i].ActualCost)))
					{
						SaleItem[i].Discpercent = 100.00;
						SaleItem[i].Discount = SaleItem[i].Cost;
						SaleItem[i].ADisc = SaleItem[i].Cost;
					}
				}


				await CalOthCost();

				for (i = 0; i < SaleItem.Count; i++)
				{
					//if (SaleItem[i].Qty == 0) SaleItem[i].Qty = 0;
					//Doubt

					ttl += (((SaleItem[i].IsRtn) ? -1 : 1) * (SaleItem[i].Qty) * (SaleItem[i].ActualCost));

					qty += (((SaleItem[i].IsRtn) ? -1 : 1) * (SaleItem[i].Qty) + (SaleItem[i].AFOC));

					TtlLnDisc += (((SaleItem[i].IsRtn) ? -1 : 1) * SaleItem[i].Qty) * (SaleItem[i].ADisc);

					oth += (((SaleItem[i].Qty) + (SaleItem[i].AFOC)) * SaleItem[i].ActOthCost);
					//Need to UpdateLater;
					if (App.IsInvTaxEna && ChkNoVAT == false)
					{
						tax += (SaleItem[i].Qty *
							   (SaleItem[i].ActualCost) - SaleItem[i].ActualDisc - SaleItem[i].ADisc) *
							   ((SaleItem[i].IsRtn) ? -1 : 1) * (SaleItem[i].Taxpercent) / 100;
						Tax = tax;
					}

					if (rfrshDisp)
					{
						SaleItem[i].Cost = (SaleItem[i].ActualCost);
						SaleItem[i].Linetotal = (SaleItem[i].Qty) * (SaleItem[i].ActualCost) - SaleItem[i].ADisc;
					}

					TrQty = qty;
					TotalPrice = ttl;
					TotalWTax = ttl + Tax;
				}
			}
			catch (Exception ex)
			{
			}
		}

		[RelayCommand]
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

				foreach (var item in SaleItem)
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
				//tOthVal = (double)(OthCost / FCRt - tOthVal);
				tDAmt = Discount - tDAmt;
				TrQty = 0;
				foreach (var item in SaleItem)
				{
					AUnitCost = 0;
					TrQty = TrQty + (item.Qty + item.AFOC);
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
				foreach (var item in SaleItem)
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

			for (i = 0; i < SaleItem.Count; i++)
			{
				if (SaleItem[i].IsRtn == true)
				{
					SaleItem[i].TtlLnFOCAmt = 0;
					goto Nexti;
				}

				if (SaleItem[i].SlNo != 0 && SaleItem[i].AFOC != 0)
				{
					focVal = (double)((SaleItem[i].ActualCost - SaleItem[i].ADisc) * SaleItem[i].AFOC);

					if (focVal > 0)
					{
						if (string.IsNullOrWhiteSpace(SaleItem[i].FOCCostMapg))
						{
							SaleItem[i].TtlLnFOCAmt = (float)(SaleItem[i].TtlLnFOCAmt + focVal);
						}
						else
						{
							slNo = SaleItem[i].FOCCostMapg.Split(',');
							ttl = 0;
							for (intX = 0; intX < slNo.Count(); intX++)
							{
								for (j = 0; j < SaleItem.Count; j++)
								{
									if (SaleItem[j].SlNo == double.Parse(slNo[intX]) && SaleItem[j].IsRtn != true)
									{
										ttl += (double)((SaleItem[j].ActualCost - SaleItem[j].ADisc) * (SaleItem[j].Qty + SaleItem[j].AFOC));
										break;
									}
								}
							}

							for (intX = 0; intX < slNo.Count(); intX++)
							{
								for (j = 0; j < SaleItem.Count; j++)
								{
									if ((SaleItem[j].SlNo.ToString() == slNo[intX]) && SaleItem[j].IsRtn != true)
									{
										SaleItem[j].TtlLnFOCAmt = (float)((SaleItem[j].TtlLnFOCAmt) + focVal * (SaleItem[j].ActualCost - SaleItem[j].ADisc) * (SaleItem[j].Qty + SaleItem[j].AFOC) / ttl);
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

	}
}
