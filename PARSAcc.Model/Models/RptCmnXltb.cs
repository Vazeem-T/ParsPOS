using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptCmnXltb
{
    public int XlrptNo { get; set; }

    public string XlrptTp { get; set; } = null!;

    public string? XlrptName { get; set; }

    public byte MastNo { get; set; }

    public bool IsPublic { get; set; }
}
