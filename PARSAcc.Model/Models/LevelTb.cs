using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LevelTb
{
    public byte Lcode { get; set; }

    public string? Lname { get; set; }

    public byte? Lorder { get; set; }

    public DateTime UpdtdTm { get; set; }
}
