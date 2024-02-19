using PARSAcc.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARSAcc.Model.ViewModel
{
	public class ItemTrReport
	{
		public SysTb SysTb { get; set; }
		public ItmInvCmnTb ItmInvCmn { get; set; }
		public IEnumerable<ItmInvTrTb> itmInvTrs { get; set; }
	}
}
