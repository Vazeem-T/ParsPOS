using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PoscrNoteTb
{
    public long VchrNo { get; set; }

    public DateTime? MsysDateTime { get; set; }

    public decimal? Amt { get; set; }

    public int? AccNo { get; set; }

    public DateTime? IssdPosdt { get; set; }

    public string? IssdBy { get; set; }

    public DateTime CrtdTm { get; set; }

    public bool IsUsed { get; set; }

    public string? IssdCounter { get; set; }

    public DateTime? UsedLsysDateTime { get; set; }

    public int? UsedCounterNo { get; set; }

    public bool IsPos { get; set; }

    public int? TrId { get; set; }

    public bool AllowMultipleTr { get; set; }
}
