using SQLite;
using System;
using System.Collections.Generic;

namespace ParsPOS.SaleModel;

public partial class NizPoscmn
{
    public int? CounterNo { get; set; }
    public short? HoldNo { get; set; }

    public int? CustNo { get; set; }

    public double? InvDisc { get; set; }

    public DateTime? Tm { get; set; }

    public string UserId { get; set; }

    public string SlsManId { get; set; }
}
