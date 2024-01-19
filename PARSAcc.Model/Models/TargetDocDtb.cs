using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TargetDocDtb
{
    public long? DocNo { get; set; }

    public string? Smcode { get; set; }

    public DateTime? ApplyMonth { get; set; }

    public decimal? TargetAmt { get; set; }

    public int? SlNo { get; set; }

    public DateTime? DelDt { get; set; }
}
