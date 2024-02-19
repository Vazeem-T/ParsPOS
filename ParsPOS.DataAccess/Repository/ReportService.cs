using AspNetCore.Reporting;
using Microsoft.Identity.Client;
using PARSAcc.Model.Models;
using PARSAcc.Model.ViewModel;
using ParsPOS.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.DataAccess.Repository
{
	public class ReportService : IReportService
	{

		private readonly IDbConnection _connection;
		private readonly ParsAccTrPlusContext _context;

		public ReportService()
		{
			//_connection = ParsAccTrPlusContext;
			_context = new ParsAccTrPlusContext();
		}
		public byte[] CreateReportFile(string pathRdlc)
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			LocalReport report = new LocalReport(pathRdlc);
			List<ItemTrReport> itemTrReports = new List<ItemTrReport>();
			List<ItmInvTrTb> itmInvTrTbs = new List<ItmInvTrTb>();
			itmInvTrTbs = _context.ItmInvTrTbs.Where(x => x.TrId == 16887).ToList();
			report.AddDataSource("ItmTrDataSet", itmInvTrTbs);
			var result = report.Execute(RenderType.Pdf, 1);
			return result.MainStream;
		}
	}
}
