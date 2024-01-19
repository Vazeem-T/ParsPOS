using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LoanDetTb
{
    public int? LoanNo { get; set; }

    public DateTime? InsMonth { get; set; }

    public double? Amount { get; set; }

    public double? Pamount { get; set; }
}
