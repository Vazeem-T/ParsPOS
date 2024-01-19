using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class JobPriorYrTb
{
    public int? AccNo { get; set; }

    public double? PreYearAmt { get; set; }

    public string? JobCode { get; set; }

    public double? EstimateAmt { get; set; }
}
