using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SpTaxtb
{
    public int AccNo { get; set; }

    public string? Descr { get; set; }

    public decimal? Per { get; set; }

    public int SpTaxno { get; set; }

    public DateTime? SpTaxfrom { get; set; }

    public DateTime? SpTaxto { get; set; }

    public byte SpTaxcalcMthd { get; set; }

    public string? SpTaxid { get; set; }
}
