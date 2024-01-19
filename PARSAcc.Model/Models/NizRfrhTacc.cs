using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizRfrhTacc
{
    public int Lid { get; set; }

    public int AccNo { get; set; }

    public decimal? TaxPer { get; set; }

    public short? SlNo { get; set; }

    public short ApplyFor { get; set; }
}
