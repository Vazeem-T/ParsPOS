using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class OfferBoatp
{
    public int Boaid { get; set; }

    public string? Boacode { get; set; }

    public string? Boaname { get; set; }

    public decimal? LimitAmt { get; set; }

    public bool ForEach { get; set; }

    public byte DiscBased { get; set; }

    public decimal? DiscPer { get; set; }

    public bool DelId { get; set; }
}
