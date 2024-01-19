using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PhyCmnTb
{
    public int PhyNo { get; set; }

    public int? StockAcc { get; set; }

    public int? StockShort { get; set; }

    public int? StockExc { get; set; }

    public string? CmnDescription { get; set; }

    public DateTime? PhyDate { get; set; }

    public bool UpDtdStatus { get; set; }

    public string? TrRefNo { get; set; }

    public string? UserId { get; set; }

    public string? LstModiUsrId { get; set; }

    public bool NotSaved { get; set; }

    public long? Phino { get; set; }

    public long? Phono { get; set; }

    public bool QihisZeroForRemain { get; set; }

    public DateTime UpdtdTm { get; set; }

    public long? InvTrId { get; set; }
}
