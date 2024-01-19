using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdatrDet
{
    public string? Ic { get; set; }

    public string? Bc { get; set; }

    public string? Iname { get; set; }

    public double? Qty { get; set; }

    public double? Cost { get; set; }

    public int? TrNo { get; set; }

    public byte? DocType { get; set; }

    public int? SlNo { get; set; }

    public int? ItemId { get; set; }

    public string? Unit { get; set; }

    public bool IsFoc { get; set; }

    public string? Focmpg { get; set; }

    public float LnDisc { get; set; }

    public float LnDiscPer { get; set; }

    public bool IsPer { get; set; }

    public string? LocId { get; set; }
}
