using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NarationTb
{
    public int? ItemId { get; set; }

    public string? Naration { get; set; }

    public short? NarationNo { get; set; }

    public bool Suppress { get; set; }
}
