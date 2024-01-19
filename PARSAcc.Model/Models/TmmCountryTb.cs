using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmmCountryTb
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Abbreviation { get; set; }

    public string? Currency { get; set; }

    public string? CurrencyAbbreviation { get; set; }

    public int? Extension { get; set; }

    public byte? NumberLength { get; set; }

    public string? ImageName { get; set; }

    public bool IsFavourite { get; set; }
}
