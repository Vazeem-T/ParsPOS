using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptListTb
{
    public string? RptCode { get; set; }

    public string? ModuleCode { get; set; }

    public string? UserId { get; set; }

    public bool Visible { get; set; }

    public bool Block { get; set; }
}
