using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmmPrdSaleCmn
{
    public long UnqNo { get; set; }

    public long LotNumber { get; set; }

    public int? CounterNo { get; set; }

    public DateTime? SysDateTime { get; set; }

    public string? UserId { get; set; }

    public string? Response { get; set; }

    public decimal? Qty { get; set; }

    public int PrintedCount { get; set; }

    public decimal? Amt { get; set; }

    public string? BeneficiaryNo { get; set; }

    public string? Operator { get; set; }

    public decimal? Fcamt { get; set; }

    public string? Country { get; set; }

    public string? Lc { get; set; }

    public string? Fc { get; set; }

    public DateTime CrtdTm { get; set; }

    public string? Package { get; set; }
}
