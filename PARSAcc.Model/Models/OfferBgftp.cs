using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class OfferBgftp
{
    public int Bgfid { get; set; }

    public string? Bgfcode { get; set; }

    public string? Bgfname { get; set; }

    public decimal? BuyQty { get; set; }

    public decimal? GetQty { get; set; }

    public bool OnlySingleCat { get; set; }

    public bool DelId { get; set; }
}
