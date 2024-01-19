using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SysPara
{
    public string ProcessCode { get; set; } = null!;

    public string? Description { get; set; }

    public bool DefValue { get; set; }

    public bool OnlyPrgmr { get; set; }

    public short? OrdNo { get; set; }
}
