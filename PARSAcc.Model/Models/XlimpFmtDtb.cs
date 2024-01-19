using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class XlimpFmtDtb
{
    public int XlimportedId { get; set; }

    public string? ColumName { get; set; }

    public string? FldName { get; set; }

    public string Type { get; set; } = null!;

    public bool? IsCompulsory { get; set; }

    public string? FldDescr { get; set; }

    public int? SlNo { get; set; }
}
