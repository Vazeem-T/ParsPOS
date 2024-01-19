using Dapper;
using Microsoft.AspNetCore.Mvc;
using PARSAcc.Model.Models;
using PARSAcc.Model.ViewModel;
using System.Data;

namespace PARSAcc.Controllers
{
	public class PurchaseController : Controller
	{
		string Slno;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IDbConnection _connection;
		PurchaseViewModel _purchaseViewModel;
		public PurchaseController(IHttpClientFactory httpClientFactory, IDbConnection connection, PurchaseViewModel purchaseviewmodel)
		{
			_httpClientFactory = httpClientFactory;
			_connection = connection;
			_purchaseViewModel = purchaseviewmodel;
		}
		public IActionResult Index()
		{
			//_purchaseViewModel = new PurchaseViewModel();
			return View(_purchaseViewModel);
		}
		public IActionResult AddPurchase()
		{
			//_purchaseViewModel = new PurchaseViewModel();
			return View(_purchaseViewModel);
		}

		public PartialViewResult PopProdTablePartial(int selectedOption = 1, string searchText = "")
		{
			try
			{
				TempData["SelectedOption"] = selectedOption;
				string sqlQuery;
				if (string.IsNullOrEmpty(searchText))
				{
					sqlQuery = $"Select top(30) [Item Code] as ItemCode , * from InvItm";
				}
				else
				{
					sqlQuery = $"Select top(30) [Item Code] as ItemCode , * from InvItm where {GetColumnName(selectedOption)} LIKE '%{searchText}%'";
				}
				_purchaseViewModel.InvItms = _connection.QueryAsync<InvItm>(sqlQuery).Result;
				return PartialView("~/Views/Purchase/_PurchasePartialView/_ProductTbLoad.cshtml", _purchaseViewModel.InvItms);
			}
			catch (Exception ex)
			{
				return PartialView("~/Views/Purchase/_PurchasePartialView/_ProductTbLoad.cshtml", null);
			}
		}

		private string GetColumnName(int selectedOption)
		{
			switch (selectedOption)
			{
				case 1: return "[Item Code]";
				case 2: return "Description";
				case 3: return "Unit";
				case 4: return "ActiveCost";
				case 5: return "UnitCost";
				case 6: return "Barcode";
				default: return string.Empty;
			}
		}

		public IActionResult FetchProd(string ProdCode)
		{
			try
			{
				if (ProdCode != null)
				{
					if (_purchaseViewModel.PurchaseDetTbItm.Count() == 0) Slno = "1";
					else Slno = (_purchaseViewModel.PurchaseDetTbItm.Count() + 1).ToString();
					var sqlquery = $"SELECT dbo.getTAXPer(BaseId) Taxper,[Item Code] as ItemCode,InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE [Item Code] = '{ProdCode}'";
					var itemlist = _connection.QueryAsync<dynamic>(sqlquery).Result;
					itemlist.ToList();
					foreach (var a in itemlist)
					{
						_purchaseViewModel.PurchaseDetTb = new()
						{
							SlNo = Slno,
							Code = a.ItemCode,
							ProdDesr = a.Description,
							Unit = a.Unit,
							Cost = (double)(((a.LastPurchCost != 0) ? a.LastPurchCost : (a.CostAverage > 0) ? a.CostAverage : (a.ActiveCost / a.PMult)) * a.PMult),
							ActualCost = (double)(((a.LastPurchCost != 0) ? a.LastPurchCost : (a.CostAverage > 0) ? a.CostAverage : (a.ActiveCost / a.PMult)) * a.PMult),
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
						_purchaseViewModel.PurchaseDetTbItm.Add(_purchaseViewModel.PurchaseDetTb);
					}
				}
				return PartialView("~/Views/Purchase/_PurchasePartialView/_AddPurchaseForm.cshtml", _purchaseViewModel.PurchaseDetTb);
			}
			catch (Exception ex)
			{
				return PartialView("~/Views/Purchase/_PurchasePartialView/_AddPurchaseForm.cshtml",null);
			}
		}
	}
}
