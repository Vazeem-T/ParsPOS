using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LocationTb
{
    public string LocationId { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDefault { get; set; }

    public int? Whno { get; set; }

    public int LocNo { get; set; }
}
