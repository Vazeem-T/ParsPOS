using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AreaTb
{
    public string AreaCode { get; set; } = null!;

    public string? AreaDescr { get; set; }

    public double? TotlSale { get; set; }

    public DateTime? LstSaleDate { get; set; }

    public double? LstSlAmt { get; set; }
}
