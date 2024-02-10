using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Services
{
	public interface IPrintServices
	{
		IList<string> GetDeviceList();
		Task Print(string deviceName, byte[]? imageData,string text);
	}
}
