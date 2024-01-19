using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class GrpItmTb
{
    public string GrpItmCode { get; set; } = null!;

    public byte? Lcode { get; set; }

    public string? Description { get; set; }

    public int? ParentId { get; set; }

    public int UnqGrpId { get; set; }

    public bool? DelId { get; set; }

    public string? Pid { get; set; }

    public DateTime UpdtdTm { get; set; }
}
