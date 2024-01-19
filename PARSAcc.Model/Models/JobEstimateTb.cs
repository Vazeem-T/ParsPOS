using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class JobEstimateTb
{
    public int? JobId { get; set; }

    public short? SlNo { get; set; }

    public int? ItemId { get; set; }

    public string? EstDescription { get; set; }

    public float Qty { get; set; }

    public float Rate { get; set; }
}
