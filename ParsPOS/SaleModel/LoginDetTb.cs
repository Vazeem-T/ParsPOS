using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class LoginDetTb
{
    public DateTime InTm { get; set; }

    public DateTime? OutTm { get; set; }

    public long? LoginId { get; set; }

    public int? CounterNo { get; set; }
}
