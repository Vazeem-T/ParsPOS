using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ColProperty
{
    public string ColFld { get; set; } = null!;

    public short? ModuleId { get; set; }

    public string? ColCaption { get; set; }

    public short? OrdNo { get; set; }

    public short FldSize { get; set; }

    public short FldType { get; set; }

    public short FldAlign { get; set; }

    public short? FldColWidth { get; set; }
}
