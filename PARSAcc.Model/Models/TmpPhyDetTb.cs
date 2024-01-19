using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpPhyDetTb
{
    public int? PhyNo { get; set; }

    public int? ItemId { get; set; }

    public double? TrQty { get; set; }

    public string? Unit { get; set; }

    public string? Location { get; set; }

    public float? Pfraction { get; set; }

    public string? ItmC { get; set; }

    public string? ItmN { get; set; }

    public string? FlName { get; set; }

    public double? Cost { get; set; }

    public string? Code { get; set; }

    public string? SExpDt { get; set; }

    public DateTime? ExpDt { get; set; }

    public long TRecNo { get; set; }

    public long? RecNo { get; set; }

    public string? Pcname { get; set; }

    public byte WhatInAssrtd { get; set; }

    public long ParenttRecNo { get; set; }

    public double UnitAssortedQty { get; set; }

    public DateTime? ScanTm { get; set; }

    public string? SysLocation { get; set; }

    public string? SysBranch { get; set; }

    public DateTime? StkTakenDt { get; set; }

    public double? StkTakenQty { get; set; }

    public bool IsAdjusted { get; set; }
}
