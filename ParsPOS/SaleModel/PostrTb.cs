using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class PostrTb
{
    public DateTime? SysDateTime { get; set; }

    public int? ItemId { get; set; }

    public int? SlNo { get; set; }

    public double? TrQty { get; set; }

    public string Unit { get; set; }

    public double? UnitCost { get; set; }

    public string Idescription { get; set; }

    public double? UnitDiscount { get; set; }

    public byte? SaleDoneIn { get; set; }

    public float? Pfraction { get; set; }

    public double? LineDiscount { get; set; }

    public float? LineDisc { get; set; }

    public byte? IsLineDisc { get; set; }

    public bool IsReturn { get; set; }

    public int CounterNo { get; set; }

    public string CategotyCode { get; set; }

    public bool IsCategorySale { get; set; }

    public string CatDescription { get; set; }

    public int? BaseId { get; set; }

    public DateTime? ExpiryDt { get; set; }

    public byte WhatInAssrtd { get; set; }

    public int? ParentItemId { get; set; }

    public bool IsPrepared { get; set; }

    public bool NoQtyPrint { get; set; }

    public double CatDisc { get; set; }

    public double CatDisc1 { get; set; }

    public bool IsCatDisc { get; set; }

    public decimal TaxPer { get; set; }

    public bool DoTrWithTax { get; set; }

    public double PriceWithTax { get; set; }
}
