using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class UpdtdStatusDeleted
{
    public byte MasterNo { get; set; }

    public string? ItemKey { get; set; }

    public DateTime DeltedTm { get; set; }

    public string? Code { get; set; }

    public string? Descr { get; set; }
}
