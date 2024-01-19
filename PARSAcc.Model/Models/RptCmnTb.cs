using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptCmnTb
{
    public string RptType { get; set; } = null!;

    public string? RptTypeName { get; set; }

    public int DefaultRpt { get; set; }

    public bool? IsCustom { get; set; }

    public string? DefCustRptName { get; set; }
}
