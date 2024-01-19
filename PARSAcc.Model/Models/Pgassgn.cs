using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class Pgassgn
{
    public int? PgrpId { get; set; }

    public double Amount { get; set; }

    public bool IsAmt { get; set; }

    public double Per { get; set; }

    /// <summary>
    /// 0 - Record related to Product, 1 - Related to First Level Group
    /// </summary>
    public byte SourceCat { get; set; }

    public int? SourceVal { get; set; }

    public DateTime? DeleteDt { get; set; }
}
