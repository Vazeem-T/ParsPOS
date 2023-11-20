using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class Invitm
    {
        [PrimaryKey , AutoIncrement]
        public int ItemId { get; set; }
        public string BaseId { get; set; }
        [JsonProperty("Item Code")]
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public string Unit { get; set; }
        public string POSDescription { get; set; }
        public string Model { get; set; }
        public float? UnitPrice { get; set; }
        public float? ActiveCost { get; set; }
        public string UnitPriceWS { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public int VUP { get; set; }
        public int VDown { get; set; }
        public double PMult { get; set; }
        public bool SDiscOn { get; set; }
        public float DiscountVal { get; set; }
        public double? Dim1 { get; set; }
        public double? Dim2 { get; set; }
        public double? Dim3 { get; set; }
        public string Dim1Caption { get; set; }
        public string Dim2Caption { get; set; }
        public string Dim3Caption { get; set; }
        public bool? EnaDimPara { get; set; }
        public bool? ItemWithSrNo { get; set; }
        [JsonProperty("IsWeighing")]
        public bool? IsWeighting { get; set; }
        public bool? IsPCS { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTm { get; set; }
        public bool IsComment { get; set; }
        public float OfferPrice { get; set; }
        public bool EnaRestrict { get; set; }
        public string ItmBrId { get; set; }
        public short? Tmp { get; set; }
        public byte WgCodeLenth { get; set; }
        public float? SPMult { get; set; }
        public bool AQtyPrint { get; set; }
        public string ArbDescription { get; set; }
        public bool AskWgt { get; set; }
        public float DisplayCost { get; set; }
        public short ExpDays { get; set; }
        public bool IsOrdered { get; set; }
        public bool EnaLnDisc { get; set; }
        public bool DoTrWithTax { get; set; }
        public float PriceWithTax { get; set; }
        public int? OldId { get; set; }
        public float MRP { get; set; }
    }
}
