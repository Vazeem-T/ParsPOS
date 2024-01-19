using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CountryTb
{
    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public int? ExistsCount { get; set; }

    public bool ExistsId { get; set; }
}
