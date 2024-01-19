using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdanewProdReq
{
    public string? Ic { get; set; }

    public string? Bc { get; set; }

    public string? Idescr { get; set; }

    public string? NUnit { get; set; }

    public double Price { get; set; }

    public double Cost { get; set; }

    public string? Pic { get; set; }

    public bool IsNew { get; set; }

    public long Id { get; set; }

    public int? SuppNo { get; set; }

    public string? GrpCode { get; set; }

    public int Vup { get; set; }

    public int Vdown { get; set; }
}
