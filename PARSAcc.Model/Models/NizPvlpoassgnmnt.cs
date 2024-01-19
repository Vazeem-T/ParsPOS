using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizPvlpoassgnmnt
{
    public string? Server { get; set; }

    public int? SuppId { get; set; }

    public int? Po { get; set; }

    public double? Amount { get; set; }

    public string? Reference { get; set; }

    public byte? IsModi { get; set; }

    public bool GenByPrg { get; set; }

    public decimal Id { get; set; }
}
