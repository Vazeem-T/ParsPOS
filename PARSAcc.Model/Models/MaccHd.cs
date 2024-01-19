using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class MaccHd
{
    public short MaccId { get; set; }

    public string? Descr { get; set; }

    public bool? DelId { get; set; }

    public DateTime UpdtdTm { get; set; }
}
