using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ProvisionDetTb
{
    public int? EmpNo { get; set; }

    public byte? ProvisionId { get; set; }

    public int? DrAcc { get; set; }

    public int? CrAcc { get; set; }

    public double? Amt { get; set; }

    public int RecId { get; set; }
}
