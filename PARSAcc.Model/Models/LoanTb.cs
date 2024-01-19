using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LoanTb
{
    public int? EmpNo { get; set; }

    public DateTime? LoanDt { get; set; }

    public DateTime? LoanEdt { get; set; }

    public byte? NoOfInstlmnt { get; set; }

    public double? LoanAmt { get; set; }

    public int LoanNo { get; set; }

    public string? LoanName { get; set; }

    public DateTime? LoanIssdDt { get; set; }

    public bool FullSettld { get; set; }
}
