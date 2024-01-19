using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SalesmanTb
{
    public string SmanCode { get; set; } = null!;

    public string? SmanName { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Tel { get; set; }

    public float? Commission { get; set; }

    public int? ExpAccount { get; set; }

    public bool DoHide { get; set; }
}
