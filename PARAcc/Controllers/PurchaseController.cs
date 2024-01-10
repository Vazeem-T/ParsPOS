using Microsoft.AspNetCore.Mvc;

namespace PARSAcc.Controllers
{
	public class PurchaseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AddPurchase()
		{
			return View();
		}
	}
}
