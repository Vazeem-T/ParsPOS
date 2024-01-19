using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SdepoTb
{
    public int? EmpNo { get; set; }

    public DateTime? SecuDt { get; set; }

    public DateTime? SecuEdt { get; set; }

    public byte? NoOfInstlmnt { get; set; }

    public double? SecuAmt { get; set; }

    public int SecuNo { get; set; }

    public string? SecRemark { get; set; }

    public bool FullSettld { get; set; }
}
