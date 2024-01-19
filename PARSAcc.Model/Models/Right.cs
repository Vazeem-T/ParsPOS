using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class Right
{
    public int? Id { get; set; }

    public bool RightYn { get; set; }

    public bool IsMenus { get; set; }

    public string? ProcessCode { get; set; }

    public int? NodeId { get; set; }

    public bool IsVisible { get; set; }
}
