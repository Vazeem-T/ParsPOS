using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ContrRcptTb
{
    public long ContSeqNo { get; set; }

    public int SlNo { get; set; }

    public DateTime? RcptDt { get; set; }

    public decimal? RcptAmt { get; set; }

    public string? Descr { get; set; }

    public long? AccLnk { get; set; }

    public bool IsCard { get; set; }

    public DateTime DelDt { get; set; }
}
