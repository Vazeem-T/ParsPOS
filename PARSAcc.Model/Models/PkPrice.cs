using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PkPrice
{
    public string? Ic { get; set; }

    public string? Unit { get; set; }

    public float? Price { get; set; }

    public long? ItemNo { get; set; }

    public float? Oprice { get; set; }
}
