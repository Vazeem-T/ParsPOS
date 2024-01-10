using Microsoft.AspNetCore.Mvc;

namespace PARSAcc.Controllers
{
	public class APIController : Controller
	{
		public IActionResult GetAddPurchaseProd()
		{
			var data = "";
			return Json(data);
		}
	}
}
