using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PriceChgLog
{
    public int ItemId { get; set; }

    public DateTime PriceChgDt { get; set; }

    public double OldPrice { get; set; }

    public double Price { get; set; }

    public string? ChgBy { get; set; }

    public string? BrId { get; set; }
}
