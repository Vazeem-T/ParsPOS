using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CustShortcutCmn
{
    public int CustomNo { get; set; }

    public bool IsGlobal { get; set; }

    public int? UserNo { get; set; }

    public string? SystemName { get; set; }
}
