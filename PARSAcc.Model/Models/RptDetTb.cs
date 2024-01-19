using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptDetTb
{
    public string? RptType { get; set; }

    public string? RptName { get; set; }

    public string? RptCaption { get; set; }

    public int RptNo { get; set; }

    public bool IsRpt11 { get; set; }
}
