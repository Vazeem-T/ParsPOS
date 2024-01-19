using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdatrCmn
{
    public string? Pdacode { get; set; }

    public int? DocNo { get; set; }

    public int? AccNo { get; set; }

    public byte? DocType { get; set; }

    public byte Updated { get; set; }

    public string? UserId { get; set; }

    public DateTime? CrtdTm { get; set; }

    public bool? IsCash { get; set; }

    public bool TransferFinished { get; set; }

    public int TrNo { get; set; }

    public string? InvNo { get; set; }

    public string? Reference { get; set; }

    public float InvDisc { get; set; }

    public float InvDiscPer { get; set; }

    public bool IsPer { get; set; }

    public long? EmpNo { get; set; }

    public string? JobCode { get; set; }
}
