using PARSAcc.Model.EnumServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARSAcc.Model.ViewModel
{
	public class ToastrMessage
	{
		public ToastrMessageType Type { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
	}
}
