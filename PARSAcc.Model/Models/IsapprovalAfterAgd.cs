using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class IsapprovalAfterAgd
{
    public long PermitNo { get; set; }

    public DateTime? PermitTm { get; set; }

    public string? PermitBy { get; set; }

    public long? TrId { get; set; }

    public int? CustNo { get; set; }

    public bool Block { get; set; }
}
