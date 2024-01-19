using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CurrencyTb
{
    public string? CurrencyCode { get; set; }

    public float? CurrencyRate { get; set; }

    public string? FractionCode { get; set; }

    public string? Description { get; set; }

    public byte? DecimalPlaces { get; set; }
}
