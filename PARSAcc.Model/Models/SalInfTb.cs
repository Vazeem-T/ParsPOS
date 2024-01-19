using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SalInfTb
{
    public int? EmpNo { get; set; }

    public DateTime? SalDt { get; set; }

    public double? Basic { get; set; }

    public double? Hra { get; set; }

    public double? Transport { get; set; }

    public double? Allowance1 { get; set; }

    public double? Allowance2 { get; set; }

    public double? Allowance3 { get; set; }

    public double? Allowance4 { get; set; }

    public double? Allowance5 { get; set; }

    public string? Designation { get; set; }

    public string? DesgnId { get; set; }
}
