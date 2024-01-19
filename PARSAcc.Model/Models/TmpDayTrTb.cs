using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpDayTrTb
{
    public DateTime? CrtdTm { get; set; }

    public int? AccountNo { get; set; }

    public string? Jvtype { get; set; }

    public int? Jvnum { get; set; }

    public string? PreFix { get; set; }

    public DateTime? Jvdate { get; set; }

    public string? EntryRef { get; set; }

    public double? DealAmt { get; set; }
}
