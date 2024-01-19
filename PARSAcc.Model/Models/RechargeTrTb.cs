using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RechargeTrTb
{
    public DateTime? TrDate { get; set; }

    public DateTime? TrTime { get; set; }

    public string? Reference { get; set; }

    public string? SalesManCode { get; set; }

    public long? FromAcc { get; set; }

    public long? ToAcc { get; set; }

    public decimal? TransferAmt { get; set; }

    public long WbTrId { get; set; }
}
