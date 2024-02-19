using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PARSAcc.Model.Models;

public partial class ItmInvTrTb
{
    public int? TrId { get; set; }

    public int? BaseId { get; set; }

    public int? ItemId { get; set; }

    public int? SlNo { get; set; }

    public double TrQty { get; set; }

    public string? Unit { get; set; }

    public double UnitCost { get; set; }

    public string? Idescription { get; set; }

    public double UnitOthCost { get; set; }

    public byte Method { get; set; }

    public float UnitValue { get; set; }

    public byte Dmethod { get; set; }

    public double UnitDiscount { get; set; }

    public double CostAvg { get; set; }

    public string? Location { get; set; }

    public float Pfraction { get; set; }

    public double LnBalCost { get; set; }

    public double PurchCost { get; set; }

    public double MtrPqty { get; set; }

    public string? LnJobCode { get; set; }

    public int? LnAcc { get; set; }

    public byte? MsgId { get; set; }

    public int? LmsgNo { get; set; }

    public string? Pack { get; set; }

    public int ImpDocId { get; set; }

    public int ImpDocLnNo { get; set; }

    public double LineDiscount { get; set; }
	[Column("LineDisc%")]
	public float LineDisc { get; set; }
	[Column("IsLineDisc%")]
	public bool IsLineDisc { get; set; }

    public float? Dim1 { get; set; }

    public float? Dim2 { get; set; }

    public float? Dim3 { get; set; }

    public double SaleAmt { get; set; }

    public decimal? TrTypeNo { get; set; }

    public int? TrDateNo { get; set; }

    public double? UnitLnCharge { get; set; }

    public int? Ino { get; set; }

    public byte UnitFraCount { get; set; }

    public double QtyFoc { get; set; }

    public double NormalCost { get; set; }

    public string? Focdescr { get; set; }

    public string? Focmapping { get; set; }

    public double NormalDisc { get; set; }

    public string? OutLoc { get; set; }

    public string? Aloc { get; set; }

    public bool IsTransit { get; set; }

    public string? Srllst { get; set; }

    public string? FoccostMpg { get; set; }

    public DateTime? ExpiryDt { get; set; }

    public long? PhyRecNo { get; set; }

    public short? PSlNo { get; set; }

    public byte WhatInAssrtd { get; set; }

    public DateTime LastDt { get; set; }

    public double UnitAssrtdQty { get; set; }

    public decimal TaxPer { get; set; }

    public bool DoTrWithTax { get; set; }

    public double PriceWithTax { get; set; }

    public byte C { get; set; }

    public string? Taxmpg { get; set; }

    public byte ItemClassNo { get; set; }

    public bool IsExtnl { get; set; }

    public decimal Cessper { get; set; }
}
