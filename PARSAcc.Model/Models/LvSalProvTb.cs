using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LvSalProvTb
{
    public int? EmpNo { get; set; }

    public DateTime? DtMonth { get; set; }

    public double? LvSalAmt { get; set; }

    public bool Suppress { get; set; }
}
