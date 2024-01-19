using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DayLeaveRegTb
{
    public int? EmpNo { get; set; }

    public DateTime? DayDt { get; set; }

    public byte? LeaveId { get; set; }

    public float? Part { get; set; }

    public string? Remark { get; set; }
}
