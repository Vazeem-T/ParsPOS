using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LocTrDet
{
    public int? TrId { get; set; }

    public int? BaseId { get; set; }

    public int? ItemId { get; set; }

    public int? SlNo { get; set; }

    public double TrQty { get; set; }

    public string? Unit { get; set; }

    public double UnitCost { get; set; }

    public string? Idescription { get; set; }

    public string? InLoc { get; set; }

    public byte? MsgId { get; set; }

    public int? LmsgNo { get; set; }

    public decimal? TrTypeNo { get; set; }

    public int? TrDateNo { get; set; }

    public string? OutLoc { get; set; }
}
