using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BaseItmDet
{
    public int BaseItemId { get; set; }

    public double QtyOpn { get; set; }

    public double CostOpen { get; set; }

    public double CostAverage { get; set; }

    public string ItemCategory { get; set; } = null!;

    public double LastPurchCost { get; set; }

    public byte LastCostMthdUsed { get; set; }

    public double CostAsOn { get; set; }

    public int SupplierNo { get; set; }

    public string? LstPurchInf1 { get; set; }

    public string? LstPurchInf2 { get; set; }

    public string? LstPurchInf3 { get; set; }

    public double IssdQty { get; set; }

    public double RcvdQty { get; set; }

    public double QtyInHand { get; set; }

    public double MissdQty { get; set; }

    public double MrcvdQty { get; set; }

    public bool HavingDetail { get; set; }

    public double MopnQty { get; set; }

    public bool ContainsTr { get; set; }

    public double MinQty { get; set; }

    public bool EnaExpiry { get; set; }

    public DateTime? ModiDtTm { get; set; }

    public double BactiveCost { get; set; }

    public double? TransitQty { get; set; }

    public double? BookedQty { get; set; }

    public bool IsFinished { get; set; }

    public float LpnetCost { get; set; }

    public short NsprofitPer { get; set; }

    public short Prvlg1 { get; set; }

    public short Prvlg2 { get; set; }

    public bool ExcldPerChkg { get; set; }

    public double C { get; set; }

    public string? SuppInf { get; set; }

    public long? Hsnno { get; set; }

    public byte PrdCostMthd { get; set; }

    public bool IsTmm { get; set; }
}
