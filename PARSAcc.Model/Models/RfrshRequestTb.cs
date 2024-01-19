using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RfrshRequestTb
{
    public string? Server { get; set; }

    public DateTime StartDttm { get; set; }

    public string? ItemStr { get; set; }

    public double? TrTypeNo { get; set; }

    public int? TrId { get; set; }

    public byte? DoInvOrBoth { get; set; }

    public bool Wait { get; set; }

    /// <summary>
    /// 0 - Normal (based on last blockdt) 1 - Including Last Block ranage, 2 - All, 3 -  After given date
    /// </summary>
    public short ActionNo { get; set; }

    public DateTime? ActionDt { get; set; }
}
