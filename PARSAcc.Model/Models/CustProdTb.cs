using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CustProdTb
{
    public int? PrdGrpNo { get; set; }

    public long CustPno { get; set; }

    public string? CustPid { get; set; }

    public string? CustPbc { get; set; }

    public string? Descr { get; set; }

    public string? Punit { get; set; }

    public decimal? Price { get; set; }

    public string? Para1 { get; set; }

    public string? Para2 { get; set; }

    public string? CrtdBy { get; set; }

    public string? ModiBy { get; set; }

    public DateTime CrtdTm { get; set; }

    public DateTime? ModiTm { get; set; }
}
