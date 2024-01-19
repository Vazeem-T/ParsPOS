using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ProdPadTb
{
    public int ItemId { get; set; }

    public string? Descr { get; set; }

    public int? Ord { get; set; }

    public byte[]? Img { get; set; }

    public DateTime? DelIdDt { get; set; }

    public string Code { get; set; } = null!;

    public bool WithCode { get; set; }
}
