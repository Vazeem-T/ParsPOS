using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class BkPosacc
{
    public DateTime? SysDateTime { get; set; }

    public int? AccountNo { get; set; }

    public string TrDescription { get; set; }

    public double? Amount { get; set; }

    public string TypeName { get; set; }

    public bool IsFullRtn { get; set; }

    public int CounterNo { get; set; }

    public int? SlNo { get; set; }

    public short? Ctgry { get; set; }

    public bool CancelA { get; set; }

    public bool ForRpt { get; set; }

    public string CardName { get; set; }

    public float DiscIncAmt { get; set; }
}
