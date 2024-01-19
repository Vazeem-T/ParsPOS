using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BrPrice
{
    public int ItemId { get; set; }

    public string BrId { get; set; } = null!;

    public double BrPrice1 { get; set; }

    public double BrOfferPrice { get; set; }

    public bool DelId { get; set; }
}
