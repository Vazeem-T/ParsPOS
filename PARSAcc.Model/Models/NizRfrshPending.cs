using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizRfrshPending
{
    public short DocType { get; set; }

    public DateTime ReqDtTm { get; set; }

    public int PendingDocNo { get; set; }

    public bool Wait { get; set; }

    /// <summary>
    /// 0 - Normal (based on last blockdt) 1 - Including Last Block ranage, 2 - All, 3 -  After given date
    /// </summary>
    public short ActionNo { get; set; }

    public DateTime? ActionDt { get; set; }

    public DateTime TmDelay { get; set; }
}
