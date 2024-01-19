using Dapper;
using Microsoft.AspNetCore.Mvc;
using PARAcc.Model.Models;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace PARSAcc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbConnection _connection;
        public HomeController(ILogger<HomeController> logger , IDbConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public IActionResult Index()
        {
            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
