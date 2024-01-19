using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptLocalDef
{
    public string? CompuName { get; set; }

    public string? RptType { get; set; }

    public string? DefCustRptName { get; set; }

    public bool? IsCustom { get; set; }

    public int? DefaultRpt { get; set; }
}
