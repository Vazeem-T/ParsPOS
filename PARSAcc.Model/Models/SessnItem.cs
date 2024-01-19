using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SessnItem
{
    public int SessnId { get; set; }

    public int ItemId { get; set; }

    public bool Deleted { get; set; }

    public byte OfferTp { get; set; }
}
