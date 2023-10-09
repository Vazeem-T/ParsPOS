using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class Posrvdet
{
    public DateTime? SysDateTime { get; set; }

    public int CounterNo { get; set; }

    public string PayType { get; set; }

    public byte? Ctgry { get; set; }

    public string Description { get; set; }

    public int? SlNo { get; set; }

    public int? AccNo { get; set; }

    public double? Amount { get; set; }

    public double? Tendered { get; set; }

    public string Reference { get; set; }

    public double Rvdiscount { get; set; }

    public double RvdiscPer { get; set; }

    public string CardName { get; set; }
}
