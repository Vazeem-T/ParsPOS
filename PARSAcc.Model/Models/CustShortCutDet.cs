using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CustShortCutDet
{
    public int MenuItemNo { get; set; }

    public int CustomNo { get; set; }

    public string? ItemName { get; set; }

    public int ParentNo { get; set; }

    public short OrdNo { get; set; }

    public string? SysIconKey { get; set; }

    public bool IsSysMenu { get; set; }
}
