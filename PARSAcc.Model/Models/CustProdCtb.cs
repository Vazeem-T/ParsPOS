using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CustProdCtb
{
    public int PrdGrpNo { get; set; }

    public string? Descr { get; set; }

    public string? GrpCode { get; set; }

    public bool IsDefault { get; set; }
}
