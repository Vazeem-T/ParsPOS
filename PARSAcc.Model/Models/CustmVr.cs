using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CustmVr
{
    public string TypeId { get; set; } = null!;

    public string? TypeName { get; set; }

    public string? PreFix { get; set; }

    public int? VrNo { get; set; }
}
