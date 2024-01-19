using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BranchTb
{
    public string BranchId { get; set; } = null!;

    public string? BranchName { get; set; }

    public int? CostOfSlHd { get; set; }

    public int? CostDiff { get; set; }

    public bool IsDefault { get; set; }

    public int? StockHd { get; set; }

    public string? BranchDb { get; set; }

    public DateTime? DtLstBrUpdtd { get; set; }

    public string? BranchServer { get; set; }

    public string? Btel1 { get; set; }

    public string? Btel2 { get; set; }

    public string? Baddr1 { get; set; }

    public string? Baddr2 { get; set; }

    public string? Baddr3 { get; set; }

    public string? ShortName { get; set; }

    public string? BrFc { get; set; }

    public int? IntnlPayable { get; set; }

    public byte? CntrznType { get; set; }

    public int BrPayableAcc { get; set; }

    public byte CntrznLinkType { get; set; }

    public byte[]? Img { get; set; }
}
