using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AdvanceTb
{
    public int? EmpNo { get; set; }

    public DateTime? AdvDate { get; set; }

    public float? AdvAmount { get; set; }

    public string? Description { get; set; }
}
