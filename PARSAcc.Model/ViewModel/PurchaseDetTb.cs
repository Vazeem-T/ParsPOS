using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARSAcc.Model.ViewModel
{
	public class PurchaseDetTb
	{
		public string SlNo { get; set; }
		public string Code { get; set; }
		public int? Serial { get; set; }
		public string ProdDesr { get; set; }
		public bool IsRtn { get; set; } = false;
		public string Unit { get; set; }
		public string? LOC { get; set; }
		public double? MPack { get; set; }
		public double? MQty { get; set; }
		public double? Qty { get; set; }
		public double? FOC { get; set; }
		public double? Cost { get; set; }
		public double? Linetotal { get; set; }
		public double? Discpercent { get; set; }
		public double? Discount { get; set; }
		public bool Ispercent { get; set; } = true;
		public double? NetCost { get; set; }
		public double? ActS_Price { get; set; }
		public string? FOCCostInfo { get; set; }
		public string? FOCMapg { get; set; }
		public string? FOCCostMapg { get; set; }
		public double? ActOthCost { get; set; }
		public int Mthd { get; set; }
		public double? UVal { get; set; }
		public double? ActualDisc { get; set; }
		public int DMthd { get; set; }
		public DateTime? ExpiryDt { get; set; }
		public double Taxpercent { get; set; }
		public bool? IsAssorted { get; set; }
		public double? TtlLnFOCAmt { get; set; }
		public string? FOCItmMapg { get; set; }
		public double? AFOC { get; set; }
		public double? ADisc { get; set; }
		public int? ImpLnId { get; set; }
		public double ActualCost { get; set; }
		public int? JobACId { get; set; }
		public double PMult { get; set; }
		public int? UFra { get; set; }
		public int BaseId { get; set; }
		public int ItemId { get; set; }
		public bool? ISMapping { get; set; }
		public bool IsCompleted { get; set; }
	}
}
