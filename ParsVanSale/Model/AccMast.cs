using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
	public class AccMast 
	{
		public int AccountNo { get; set; }
		[MaxLength(10)]
		public string Alias {  get; set; }
		public int S1AccId { get; set; }
		[MaxLength(10)]
		[DisplayName("Purch A/C")]
		public string AccDescr { get; set; }
		[MaxLength(3)]
		public string CurrencyCode { get; set; }
		public double OpnBal { get; set; }
		public double ClosingBal { get; set;}
		public float OpenFCRt { get; set; }
		public DateTime aCrtdDt { get; set; }
		public DateTime aModiDt { get; set; }
		public string PartyTRNNo { get; set; }
 	}
}
