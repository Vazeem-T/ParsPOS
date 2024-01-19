using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PrdGrpCmnTb
{
    public string ProdGrpCode { get; set; } = null!;

    public string? ProdGrpName { get; set; }

    public int GrpId { get; set; }
}
