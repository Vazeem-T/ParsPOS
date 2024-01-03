using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.Model
{
    public class PurchaseDetTb
    {
        public short SlNo { get; set; }
        public string? Code { get; set; }
        public int? Serial { get; set; }
        public string? ProdDesr { get; set; }
        public bool? IsRtn { get; set; } = false;
        public string? Unit { get; set; }
        public string? LOC {  get; set; }
        public float? MPack { get; set; }
        public float? MQty { get; set; }
        public double? Qty { get; set; }
        public float? FOC { get; set; }
        public double? Cost { get; set; }
        public double? Linetotal { get; set; }
        public float? Discpercent { get; set; }
        public double? Discount { get; set; }
        public bool? Ispercent { get; set; } = true;
        public double? NetCost { get; set; }
        public float? ActS_Price { get; set; }
        public string FOCCostInfo { get; set; } 
        public string? FOCMapg { get; set; }
        public string? FOCCostMapg { get; set; }
        public float? ActOthCost { get; set; }
        public int? Mthd { get; set; }
        public float UVal { get; set; }
        public float? ActualDisc { get; set; }
        public  int? DMthd { get; set; }
        public DateTime? ExpiryDt { get; set; }
        public float? Taxpercent { get; set; }  
        public bool? IsAssorted { get; set; }
        public float? TtlLnFOCAmt { get; set; }
        public string? FOCItmMapg { get; set; }
        public bool? AFOC { get; set; }
        public float? ADisc { get; set; }
        public int? ImpLnId {  get; set; }
        public float? ActualCost { get; set;}
        public int JobACId {  get; set; }
        public float? PMult { get; set; }
        public int? UFra { get; set; }
        public int? BaseId { get; set; }
        public int? ItemId { get; set; } 
        public bool IsCompleted { get; set; }   
    }
}
