using SQLite;

namespace ParsVanSale.Model
{
    public class BaseItmDet
    {
        public int BaseItemId { get; set; }
        public int? BaseItemID1 { get; set; }
        public float QtyOpn { get; set; }
        public float CostOpen { get; set; }
        public float CostAverage { get; set; }
        [MaxLength(10)]
        public string ItemCategory { get; set; }
        public float LastPurchCost { get; set; }
        public short LastCostMthdUsed { get; set; }
        public float CostAsOn { get; set; }
        public int SupplierNo { get; set; }
        [MaxLength(40)]
        public string? LstPurchInf1 { get; set; }
        [MaxLength(40)]
        public string? LstPurchInf2 { get; set; }
        [MaxLength(40)]
        public string? LstPurchInf3 { get; set; }
        public float IssdQty { get; set; }
        public float RcvdQty { get; set; }
        public float QtyInHand { get; set; }
        public float MIssdQty { get; set; }
        public float MRcvdQty { get; set; }
        public bool HavingDetail { get; set; }
        public float MOpnQty { get; set; }
        public bool ConstainsTr { get; set; }
        public float MinQty { get; set; }
        public bool EnaExpiry { get; set; }
        public DateTime? ModiDtTm { get; set; }
        public float BActiveCost { get; set; }
        public float? TransitQty { get; set; }
        public float? BookedQty { get; set; }
        public bool IsFinished { get; set; }
        public double LPNetCost { get; set; }
        public short NSProfitPer { get; set; }
        [Column("[Prvlg1%]")]
        public short Prvlg1 { get; set; }
        [Column("[Prvlg2%]")]
        public short Prvlg2 { get; set; }
        public bool ExcldPerChkg { get; set; }
        [MaxLength(60)]
        public string? SupplInf { get; set; }
        public long? HSNNo { get; set; }
        public short PrdCostMthd { get; set; }

    }
}
