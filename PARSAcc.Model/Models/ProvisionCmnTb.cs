using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ProvisionCmnTb
{
    public int? RecId { get; set; }

    public int? Jvnum { get; set; }

    public string? PreFix { get; set; }

    public DateTime? ProvisionDt { get; set; }

    public int? DrCmnAcc { get; set; }

    public int? CrCmnAcc { get; set; }

    public bool IsSepProvision { get; set; }

    public bool IsSepOppAcc { get; set; }
}
