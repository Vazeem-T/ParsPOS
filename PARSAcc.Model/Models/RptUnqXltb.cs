using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptUnqXltb
{
    public int? XlrptNo { get; set; }

    public int XlunqNo { get; set; }

    public string? Xlname { get; set; }

    public string? Xldescription { get; set; }

    public string? ConStr { get; set; }

    public byte[]? XlfileObj { get; set; }
}
