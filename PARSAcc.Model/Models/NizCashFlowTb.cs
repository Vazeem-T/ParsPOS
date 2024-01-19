using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizCashFlowTb
{
    public string? Server { get; set; }

    public int? AccountNo { get; set; }

    public double? Obamt { get; set; }

    public double? DealAmt { get; set; }

    public DateTime? Jvdate { get; set; }

    public string? Category { get; set; }
}
