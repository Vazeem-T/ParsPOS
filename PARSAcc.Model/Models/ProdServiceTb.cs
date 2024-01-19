using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ProdServiceTb
{
    public int DocNo { get; set; }

    public int SrvLink { get; set; }

    public DateTime? SrvDt { get; set; }

    public string? SrlNo { get; set; }

    public string? SrvBranch { get; set; }

    public string? SrvDescr { get; set; }

    public string? MobNo { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public float? EstAmt { get; set; }

    public float? AdvAmt { get; set; }

    public float? BalRcptAmt { get; set; }

    public string? CrtdBy { get; set; }

    public string? ModiBy { get; set; }

    public DateTime? CrtdTm { get; set; }

    public int? RvLink { get; set; }

    public bool SrvCompleted { get; set; }
}
