using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BarDirectPrtReq
{
    public int FmtNo { get; set; }

    public string? SystemIfRequest { get; set; }

    public string? FmtPrinter { get; set; }

    public string? MasterQr { get; set; }

    public int Attempt { get; set; }

    public DateTime ReqTm { get; set; }

    public string? ReqBy { get; set; }

    public string? ReqSystem { get; set; }

    public bool IsPrintIc { get; set; }

    public bool DoDel { get; set; }

    public bool TreatAsSingle { get; set; }

    public string? ErrMsg { get; set; }
}
