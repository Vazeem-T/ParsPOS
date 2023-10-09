using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class LoginTb
{
    public long LoginId { get; set; }

    public DateTime StartTm { get; set; }

    public DateTime ClosingTm { get; set; }

    public DateTime? Posdt { get; set; }

    public string UserId { get; set; }

    public bool IsClosed { get; set; }

    public double? OpnAmt { get; set; }

    public string ModiBy { get; set; }

    public string ApprvdBy { get; set; }

    public int? CounterNo { get; set; }

    public double CardPhyTtl { get; set; }

    public double Mpay { get; set; }

    public bool NoCcsale { get; set; }

    public bool NoPettyPay { get; set; }

    public bool IsSettled { get; set; }
}
