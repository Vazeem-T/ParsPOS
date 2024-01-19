using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PurchRegTb
{
    public long RegNo { get; set; }

    public int SuppNo { get; set; }

    public string Reference { get; set; } = null!;

    public DateTime InvDt { get; set; }

    public decimal Amount { get; set; }

    public long? TrId { get; set; }
}
