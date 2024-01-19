using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LastPsinfTb
{
    public int? ItemId { get; set; }

    public int? BaseId { get; set; }

    public int? PartyNo { get; set; }

    public byte? TrTypeNo { get; set; }

    public string? LastDescr { get; set; }

    public DateTime? LastDt { get; set; }

    public double? Amt { get; set; }

    public int? TrId { get; set; }

    public float? Pfraction { get; set; }
}
