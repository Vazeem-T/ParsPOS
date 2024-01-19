using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TargetDocTb
{
    public long DocNo { get; set; }

    public DateTime? DocDt { get; set; }

    public string? CrtdBy { get; set; }

    public string? ModiBy { get; set; }

    public DateTime? ModiTm { get; set; }

    public DateTime? CrtdTm { get; set; }

    public DateTime? OrdDate { get; set; }

    public string? OrdRef { get; set; }

    public string? Description { get; set; }
}
