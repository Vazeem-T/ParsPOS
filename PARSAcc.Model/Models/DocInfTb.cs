using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DocInfTb
{
    public string DocCode { get; set; } = null!;

    public string? DocName { get; set; }

    public DateTime? DocDate { get; set; }

    public double? Amount { get; set; }

    public string? Remark { get; set; }

    public DateTime? ExpDate { get; set; }

    public short? AlertBefore { get; set; }

    public bool Suppress { get; set; }

    public bool All { get; set; }
}
