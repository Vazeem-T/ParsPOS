using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptBranchTb
{
    public string BrId { get; set; } = null!;

    public string? CompuName { get; set; }

    public int RptNo { get; set; }

    public bool IsCustom { get; set; }

    public bool IsGlobal { get; set; }

    public bool IsLocal { get; set; }

    public string RptTp { get; set; } = null!;
}
