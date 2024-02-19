using Microsoft.AspNetCore.Mvc;
using ParsPOS.DataAccess.IRepository;
using System.Reflection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PARSPOSAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private readonly IHostingEnvironment _hostingEnvironment;
		private IReportService _reportService;

		public ReportController(IReportService iService,IHostingEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
			_reportService = iService;
		}


		[HttpGet]
		[Route("Export_Data")]
		public ActionResult Export_Data()
		{
			var byteRes = new byte[] { };
			string contentRootPath = _hostingEnvironment.ContentRootPath;

			// Remove "PARSPOSAPI" and add "ParsAcc.Services"
			string newPath = Path.Combine(
				Path.GetDirectoryName(contentRootPath),
				"ParsAcc.Services"
			);

			string path = Path.Combine(newPath, "Report", "ReportTest.rdlc");
			byteRes = _reportService.CreateReportFile(path);
			return File(byteRes, System.Net.Mime.MediaTypeNames.Application.Octet, "ReportName.pdf");
		}
	}
}
