using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class UnitsTb
{
    public string Units { get; set; } = null!;

    public string? Description { get; set; }

    public byte? FraCount { get; set; }

    public bool IsDefault { get; set; }

    public bool? DelId { get; set; }

    public DateTime UpdtdTm { get; set; }
}
