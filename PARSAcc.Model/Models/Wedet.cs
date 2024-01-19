using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class Wedet
{
    public int? Weid { get; set; }

    public string? JobCode { get; set; }

    public float? Nhr { get; set; }

    public float? OthrG { get; set; }

    public float? OthrH { get; set; }

    public float? BonusHrs { get; set; }

    public short? SlNo { get; set; }

    public float? WageHr { get; set; }

    public float? OtwageHr { get; set; }

    public string? ProfessionCode { get; set; }
}
