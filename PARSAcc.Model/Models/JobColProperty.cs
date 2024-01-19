using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class JobColProperty
{
    public string ColFld { get; set; } = null!;

    public string? ColCaption { get; set; }

    public short? OrdNo { get; set; }

    public short FldSize { get; set; }

    public short FldType { get; set; }

    public short FldAlign { get; set; }
}
