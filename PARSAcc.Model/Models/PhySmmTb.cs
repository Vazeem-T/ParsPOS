using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PhySmmTb
{
    public int? PhyNo { get; set; }

    public int? Iid { get; set; }

    public double? Pqty { get; set; }

    public double? Qih { get; set; }

    public double? Cost { get; set; }

    public bool IsAutoAdjstd { get; set; }

    public double CalcCost { get; set; }

    public byte WhatInAssrtd { get; set; }

    public string? SysBranch { get; set; }
}
