using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DepartmentTb
{
    public string? DeptId { get; set; }

    public string? DeptDescr { get; set; }

    public bool MasterOnly { get; set; }
}
