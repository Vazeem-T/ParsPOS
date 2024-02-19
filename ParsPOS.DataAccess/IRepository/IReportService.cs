using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.DataAccess.IRepository
{
	public interface IReportService
	{
		byte[] CreateReportFile(string pathRdlc);
	}
}
