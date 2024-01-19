using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ScanProdTb
{
    public int? ItmNo { get; set; }

    public string? Bc { get; set; }

    public double? Qty { get; set; }

    public string? Location { get; set; }

    public string? User { get; set; }

    public DateTime ScanTm { get; set; }

    public long RecNo { get; set; }

    public string Device { get; set; } = null!;
}
