using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class SettleTb
{
    public int SettleId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime CloseDay { get; set; }

    public bool Pause { get; set; }

    public string ModiBy { get; set; }

    public bool Closed { get; set; }

    public double? OpnAmt { get; set; }
}
