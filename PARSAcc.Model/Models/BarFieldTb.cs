using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BarFieldTb
{
    public string Field { get; set; } = null!;

    public string? ProcedureName { get; set; }

    public string? Format { get; set; }
}
