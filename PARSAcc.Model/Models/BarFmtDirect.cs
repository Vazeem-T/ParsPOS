using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BarFmtDirect
{
    public int FmtNo { get; set; }

    public string FmtName { get; set; } = null!;

    public bool IsDefault { get; set; }

    public bool IsRequest { get; set; }

    public string? SystemIfRequest { get; set; }

    public string? PrintScript { get; set; }

    public string? FmtPrinter { get; set; }

    public string? FldQr { get; set; }

    public byte MasterNo { get; set; }

    public bool IsEan13or8 { get; set; }

    public string? Ean13code { get; set; }

    public string? Ean8code { get; set; }

    public string? OthCode { get; set; }

    public string? PrinterModel { get; set; }

    public bool DoHide { get; set; }

    public short NoOfLabels { get; set; }
}
