using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.Services;
using ParsPOS.Views.InventoryView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
	public partial class FOCViewModel : BaseViewModel
	{
		public ObservableCollection<PurchaseDetTb> Items { get; set; } = new();
		public ObservableCollection<RFOCInvitm> FOCBase { get; set; } = new();
		private readonly IDbConnection _connection;
		public PurchaseViewModel _purchaseViewModel { get; set; }
		public FOCViewModel(PurchaseViewModel purchaseView, IDbConnection connection)
		{
			_purchaseViewModel = purchaseView;
			_connection = connection;
			LoadCommand.Execute(null);
		}
		[ObservableProperty]
		RFOCInvitm _rFOCInvItm;

		[ObservableProperty]
		PurchaseDetTb purchDetTb;

		[ObservableProperty]
		string? qtyDisplay;

		[ObservableProperty]
		double? totalFOCQty;

		[RelayCommand]
		async Task LoadAsync()
		{
			try
			{
				if (_purchaseViewModel.PurchaseDets != null)
				{
					PurchDetTb = _purchaseViewModel.PurchaseDets;
					Items = _purchaseViewModel.PurchaseItem;
					int Slno = 0;
					float FocQty = 0;
					var sqlquery = $"SELECT InvItm.*, BaseItmDet.LPNetCost FROM InvItm LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE baseid = '{_purchaseViewModel.PurchaseDets.BaseId}'";
					var pageData = await _connection.QueryAsync<dynamic>(sqlquery);
					pageData.ToList();
					//var pageData = await App.Database.GetItemOnBaseId(_purchaseViewModel.PurchaseDets.BaseId);
					foreach (var item in pageData)
					{
						var LPNetCost = Convert.IsDBNull(item.LPNetCost) ? item.ActiveCost : item.LPNetCost;
						if(_purchaseViewModel.PurchaseDets.FOCMapg != null)
						{
							TotalFOCQty = _purchaseViewModel.PurchaseDets.FOC;
							QtyDisplay = _purchaseViewModel.PurchaseDets.FOCCostInfo;
							string[] pairs = _purchaseViewModel.PurchaseDets.FOCMapg.Split(',');
							foreach (var pair in pairs)
							{
								var match = System.Text.RegularExpressions.Regex.Match(pair, @"\((\d+)\)-([\d.]+)");
								if (match.Success)
								{
									if (int.TryParse(match.Groups[1].Value, out int itemId) && float.TryParse(match.Groups[2].Value, out float qty))
									{
										if (itemId == item.ItemId)
										{
											FocQty = qty;
										}
									}
								}
							}
						}
						Slno++;
						RFOCInvitm rFOC = new RFOCInvitm
						{
							Slno = Slno,
							Unit = item.Unit,
							Qty = FocQty,
							ItemId = Convert.ToInt32(item.ItemId),
							Packing = CustomCalculations.Packing(Convert.ToInt32(item.ItemId)),
							ProdCode = item.ItemCode,
							Barcode = item.BarCode,
							ProdDescr = item.Description,
							LPCost = (float)(Convert.ToDouble(LPNetCost) * item.PMult),
							ActiveCost = (float)Convert.ToDouble(item.ActiveCost),
							Price = (float)Convert.ToDouble(item.UnitPrice),
						};
						FOCBase.Add(rFOC);
						FocQty = 0;
					}

					foreach (var item in Items)
					{
						item.ISMapping = false;
						if (_purchaseViewModel.PurchaseDets.FOCCostMapg != null)
						{
							string[] pairs = _purchaseViewModel.PurchaseDets.FOCCostMapg.Split(',');
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
					int index = Items.IndexOf(Items.FirstOrDefault(item => item.SlNo == _purchaseViewModel.PurchaseDets.SlNo));
					if (index != -1)
					{
						Items[index] = _purchaseViewModel.PurchaseDets;
						OnPropertyChanged(nameof(Items));
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}


		}
		[RelayCommand]
		async Task FOCBaseSelectionChanged(RFOCInvitm rFOCInvitm)
		{
			RFOCInvItm = rFOCInvitm;
		}
		[RelayCommand]
		async Task QtyChanged()
		{
			if (RFOCInvItm != null && RFOCInvItm.Qty.HasValue)
			{
				OnPropertyChanged(nameof(RFOCInvItm));
				int index = FOCBase.IndexOf(FOCBase.FirstOrDefault(item => item.Slno == RFOCInvItm.Slno));
				if (index != -1)
				{
					FOCBase[index] = RFOCInvItm;
					OnPropertyChanged(nameof(FOCBase));
				}
				QtyDisplay = CustomCalculations.DisplayQty(FOCBase);
				TotalFOCQty = CustomCalculations.TotalFOCQty(PurchDetTb, FOCBase);
				OnPropertyChanged(nameof(QtyDisplay));
				OnPropertyChanged(nameof(TotalFOCQty));
			}
		}

		[RelayCommand]
		async Task CancelButtonAsync()
		{
			await Shell.Current.GoToAsync("..");
		}
		[RelayCommand]
		async Task OKButtonAsync()
		{
			try
			{
				await FOCMpg();
				_purchaseViewModel.PurchaseDets.AFOC = TotalFOCQty ?? 0;
				_purchaseViewModel.PurchaseDets.FOC = TotalFOCQty ?? 0;
				_purchaseViewModel.PurchaseDets.FOCCostInfo = QtyDisplay ?? string.Empty;
				_purchaseViewModel.PurchaseDets.FOCMapg = PurchDetTb.FOCMapg;
				var afocItems = _purchaseViewModel.PurchaseItem.Where(item => item.ISMapping == true);
				_purchaseViewModel.PurchaseDets.FOCCostMapg = string.Join(",", afocItems.Select(item => item.SlNo));
				//FOC Calulation
				if(afocItems.Count() == 0)
				{
					_purchaseViewModel.PurchaseDets.NetCost = (double)(_purchaseViewModel.PurchaseDets.Linetotal / (_purchaseViewModel.PurchaseDets.Qty + TotalFOCQty)); 
				}
				await _purchaseViewModel.CalOthCost();
				_purchaseViewModel.RefreshAddPurchaseCommand.Execute(null);
				await Shell.Current.GoToAsync("..");
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
		}

		async Task FOCMpg()
		{
			PurchDetTb.FOCMapg = null;

			for (int i = 0; i < FOCBase.Count; i++)
			{
				if (FOCBase[i].Qty > 0)
				{
					PurchDetTb.FOCMapg += $"({FOCBase[i].ItemId})-{FOCBase[i].Qty}";

					if (i + 1 < FOCBase.Count && FOCBase[i + 1].Qty > 0)
					{
						PurchDetTb.FOCMapg += ",";
					}
				}
			}
		}
	}
}
