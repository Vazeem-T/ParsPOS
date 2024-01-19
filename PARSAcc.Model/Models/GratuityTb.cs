using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class GratuityTb
{
    public int? EmpNo { get; set; }

    public DateTime? EndDate { get; set; }

    public double? Gratuity { get; set; }

    public float? TtlYearWrkd { get; set; }

    public byte? ProcessId { get; set; }
}
