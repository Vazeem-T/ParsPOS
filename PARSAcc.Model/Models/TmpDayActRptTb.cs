using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpDayActRptTb
{
    public DateTime? CrtdTm { get; set; }

    public string? TypeName { get; set; }

    public string? DrDescr { get; set; }

    public string? DrEdescr { get; set; }

    public string? CrDescr { get; set; }

    public string? CrEdescr { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }

    public double? Ob { get; set; }
}
