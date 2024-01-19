using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NprdCode
{
    public string Pfix { get; set; } = null!;

    public double Num { get; set; }

    public byte Ncount { get; set; }
}
