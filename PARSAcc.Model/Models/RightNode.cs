using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RightNode
{
    public int NodeId { get; set; }

    public short? ParentId { get; set; }

    public string? Description { get; set; }

    public bool DefRight { get; set; }

    public bool IsTag { get; set; }

    public bool OnlyPrgmr { get; set; }

    public short? OrdNo { get; set; }

    public string? ProcessCode { get; set; }
}
