using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class LocalLoginStatus
{
    public DateTime? Posdt { get; set; }

    public string Clerk { get; set; }

    public long LloginId { get; set; }

    public long CounterNo { get; set; }

    public bool IsClosed { get; set; }

    public bool IsSettled { get; set; }

    public DateTime? LstUpdtd { get; set; }

    public long? MloginId { get; set; }
}
