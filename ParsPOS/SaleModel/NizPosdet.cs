using System;
using System.Collections.Generic;

namespace ParsPOS.SaleModel;

public partial class NizPosdet
{
    public int? CounterNo { get; set; }

    public short? HoldNo { get; set; }

    public short? SlNo { get; set; }

    public int? ItemId { get; set; }

    public byte? PackNo { get; set; }

    public string Unit { get; set; }

    public bool IsRet { get; set; }

    public double? Qty { get; set; }

    public double? UnitPrice { get; set; }

    public float? DisP { get; set; }

    public double? Discount { get; set; }

    public string CategotyCode { get; set; }

    public bool IsCategorySale { get; set; }

    public string CatDescription { get; set; }

    public DateTime? Expirydt { get; set; }

    public byte WhatInAssrtd { get; set; }

    public bool IsLnDisc { get; set; }

    public bool DoTrWithTax { get; set; }

    public double PriceWithTax { get; set; }
}
