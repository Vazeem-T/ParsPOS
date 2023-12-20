using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.ResultModel
{
    public class PurchaseDetTb
    {
        public short SlNo { get; set; }
        public string? Code { get; set; }
        public string? ProdDesr { get; set; }
        public bool? IsRtn { get; set; } = false;
        public string? Unit { get; set; }
        public double? Qty { get; set; }
        public float? FOC { get; set; }
        public double? Cost { get; set; }
        public double? Linetotal { get; set; }
        public float? Discpercent { get; set; }
        public double? Discount { get; set; }
        public bool? Ispercent { get; set; } = true;
        public double? NetCost { get; set; }
        public float? ActS_Price { get; set; }
        public string? FOCMapg { get; set; }
        public double? FOCCostMapg { get; set; }
        public ICommand PopButCommand {  get; set; }
    }
}
