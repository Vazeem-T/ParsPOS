using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class BkPospay
{
    public DateTime? SysDateTime { get; set; }

    public int CounterNo { get; set; }

    public string PayType { get; set; }

    public byte? Ctgry { get; set; }

    public string Description { get; set; }

    public int? SlNo { get; set; }

    public int? AccNoCr { get; set; }

    public int? AccNoDr { get; set; }

    public double? Amount { get; set; }

    public bool CancelP { get; set; }

    public long? UnqL { get; set; }

    public string CardName { get; set; }

    public long? VchrNo { get; set; }

    public int CouponId { get; set; }
}
