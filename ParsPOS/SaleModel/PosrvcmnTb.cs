using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class PosrvcmnTb
{
    public DateTime? SysDateTime { get; set; }

    public DateTime? TrDate { get; set; }

    public int? InvNo { get; set; }

    public string UserId { get; set; }

    public string AreaCode { get; set; }

    public string BrId { get; set; }

    public string Counter { get; set; }

    public string Location { get; set; }

    public double? Tendered { get; set; }

    public double? Balance { get; set; }

    public bool Updated { get; set; }

    public string InvKey { get; set; }

    public int CounterNo { get; set; }

    public bool IsPv { get; set; }

    public long LoginId { get; set; }

    public double Rvdisc { get; set; }

    public double RvdisPer { get; set; }

    public double SettleAmt { get; set; }

    public long LLoginId { get; set; }

    public DateTime? LSysDateTime { get; set; }

    public bool IsMainUpdated { get; set; }
}
