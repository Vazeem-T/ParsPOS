using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PrdGrpDetTb
{
    public int GrpId { get; set; }

    public int ItemId { get; set; }

    public byte[]? Img { get; set; }

    public int? Ord { get; set; }

    public DateTime? DelIdDt { get; set; }

    public string? Descr { get; set; }
}
