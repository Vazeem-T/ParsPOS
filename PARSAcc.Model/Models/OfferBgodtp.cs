using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class OfferBgodtp
{
    public int Bgodid { get; set; }

    public string? Bgodcode { get; set; }

    public string? Bgodname { get; set; }

    public decimal? BuyQty { get; set; }

    public decimal? GetQty { get; set; }

    public byte DiscBased { get; set; }

    public decimal? DiscPer { get; set; }

    public bool DelId { get; set; }
}
