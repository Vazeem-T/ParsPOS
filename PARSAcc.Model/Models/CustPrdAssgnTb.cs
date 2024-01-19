using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CustPrdAssgnTb
{
    public long? CprodNo { get; set; }

    public int? ItemNo { get; set; }

    public bool Deleted { get; set; }
}
