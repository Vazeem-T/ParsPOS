using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ChqPrintTb
{
    public double? Amount { get; set; }

    public byte? Fraction { get; set; }

    public string? Payee { get; set; }

    public DateTime? ChqDate { get; set; }

    public string ChqNo { get; set; } = null!;

    public string? Descr { get; set; }

    public int Id { get; set; }
}
