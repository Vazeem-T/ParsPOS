using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PriceGrpTb
{
    public int Pgid { get; set; }

    public string Pgcode { get; set; } = null!;

    public string? Pgname { get; set; }

    public bool PriceMthd { get; set; }

    public bool IsAdd { get; set; }

    public double Percentage { get; set; }

    public int? Fpgid { get; set; }

    public bool FisAdd { get; set; }

    public bool FisPer { get; set; }

    public double Fvalue { get; set; }

    public decimal RndFra { get; set; }
}
