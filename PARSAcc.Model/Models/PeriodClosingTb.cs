using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PeriodClosingTb
{
    public int CloseNo { get; set; }

    public DateTime? ClosedUpTo { get; set; }

    public decimal? OpngStock { get; set; }

    public decimal? DirectExp { get; set; }

    public decimal? ClosingStock { get; set; }

    public decimal? DirectIncome { get; set; }

    public decimal? IndExp { get; set; }

    public decimal? IndIncome { get; set; }

    public DateTime CrtdTm { get; set; }

    public DateTime? ModiTm { get; set; }
}
