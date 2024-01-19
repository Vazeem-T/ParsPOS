using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmmPlanTb
{
    public int? SscId { get; set; }

    public int PlanId { get; set; }

    public float? Mrp { get; set; }

    public string? Pname { get; set; }

    public string? TmmPrdCode { get; set; }

    public decimal? Commission { get; set; }

    public DateTime? CrtdTm { get; set; }

    public DateTime? ModiTm { get; set; }

    public long? VcprsProdNo { get; set; }
}
