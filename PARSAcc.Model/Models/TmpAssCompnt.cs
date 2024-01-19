using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpAssCompnt
{
    public DateTime? Dt { get; set; }

    public int? SlNo { get; set; }

    public double? TrQty { get; set; }

    public double? UnitCost { get; set; }

    public float? Pfraction { get; set; }

    public int? ItemId { get; set; }

    public int? BaseId { get; set; }

    public bool IsCommon { get; set; }

    public int? PSlNo { get; set; }

    public string? Unit { get; set; }

    public string? Location { get; set; }

    public string ItemClass { get; set; } = null!;
}
