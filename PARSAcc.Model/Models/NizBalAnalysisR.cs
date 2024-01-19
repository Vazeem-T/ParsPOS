using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizBalAnalysisR
{
    public string? SrvrMdulId { get; set; }

    public double? InvAmt { get; set; }

    public double? SrAmt { get; set; }

    public double? AdjAmt { get; set; }

    public double? Amt { get; set; }

    public DateTime? VrDate { get; set; }

    public DateTime? DueDt { get; set; }

    public string? Reference { get; set; }

    public int? AccNo { get; set; }

    public DateTime LddDt { get; set; }
}
