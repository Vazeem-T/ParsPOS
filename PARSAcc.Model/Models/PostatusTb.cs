using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PostatusTb
{
    public int? PriorTrId { get; set; }

    public int? TranId { get; set; }

    public string? Jvtype { get; set; }

    public int? Jvnum { get; set; }

    public string? PreFix { get; set; }

    public int? Po { get; set; }

    public double? Amount { get; set; }

    public string? Reference { get; set; }
}
