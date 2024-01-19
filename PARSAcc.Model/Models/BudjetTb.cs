using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BudjetTb
{
    public int? AccountNo { get; set; }

    public int? Byear { get; set; }

    public double? Bjan { get; set; }

    public double? Bfeb { get; set; }

    public double? Bmar { get; set; }

    public double? Bapr { get; set; }

    public double? Bmay { get; set; }

    public double? Bjun { get; set; }

    public double? Bjul { get; set; }

    public double? Baug { get; set; }

    public double? Boct { get; set; }

    public double? Bsep { get; set; }

    public double? Bnov { get; set; }

    public double? Bdec { get; set; }

    public bool HavingBdgt { get; set; }
}
