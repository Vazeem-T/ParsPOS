using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BarCustFmt
{
    public int FmtNo { get; set; }

    public string FmtName { get; set; } = null!;

    public bool IsDefault { get; set; }

    public short? Heat { get; set; }

    public double? LabelHeight { get; set; }

    public double? LabelWidth { get; set; }

    public bool IsInInch { get; set; }

    public string? FmtPrinter { get; set; }

    public byte MasterNo { get; set; }

    public bool DoHide { get; set; }
}
