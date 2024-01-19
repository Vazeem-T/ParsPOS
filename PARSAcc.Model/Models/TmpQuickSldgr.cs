using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpQuickSldgr
{
    public int? Rno { get; set; }

    public int? LoginId { get; set; }

    public string? Type { get; set; }

    public string? VrNo { get; set; }

    public DateTime? Dt { get; set; }

    public string? Unit { get; set; }

    public double? In { get; set; }

    public double? Out { get; set; }

    public string? Dbname { get; set; }

    public string? Reference { get; set; }

    public DateTime CrtdDt { get; set; }

    public int? TrId { get; set; }

    public double? CostAvg { get; set; }

    public double? LnBalCost { get; set; }

    public double? UnitCost { get; set; }

    public double? LnQty { get; set; }

    public float PurchCost { get; set; }

    public float Packing { get; set; }
}
