using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdabcprtReq
{
    public string? FmtName { get; set; }

    public int? Qty { get; set; }

    public string? Pdaid { get; set; }

    public string? BarObject { get; set; }

    /// <summary>
    /// 0 - Product, 1 - 
    /// </summary>
    public byte ObjType { get; set; }

    public DateTime ReqTm { get; set; }

    public DateTime? DeleDt { get; set; }

    public bool IsDoc { get; set; }

    public string? RptName { get; set; }

    public string? Condition { get; set; }
}
