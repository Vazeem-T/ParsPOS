using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizPrdOpnClVal
{
    public string? SrvrMdulId { get; set; }

    public int? BaseId { get; set; }

    public double OpnCost { get; set; }

    public double CloseCost { get; set; }

    public DateTime LddDt { get; set; }
}
