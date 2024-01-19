using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ShpgItm
{
    public int? ShpgId { get; set; }

    public string? Code { get; set; }

    public string? Pname { get; set; }

    public string? Unit { get; set; }

    public double? Qty { get; set; }

    public int? SlNo { get; set; }

    public double Ucost { get; set; }

    public double Uocost { get; set; }

    public double Udisc { get; set; }

    public byte TrFor { get; set; }
}
