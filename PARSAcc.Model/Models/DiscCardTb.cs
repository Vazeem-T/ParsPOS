using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DiscCardTb
{
    public DateTime CardDt { get; set; }

    public int? SlNo { get; set; }

    public int? AccNo { get; set; }

    public string? PlotNo { get; set; }

    public string? CardName { get; set; }

    public DateTime? PinDt { get; set; }

    public string? DispMob { get; set; }

    public string? ContactNo { get; set; }

    public string? Location { get; set; }

    public string? HouseNo { get; set; }

    public string? Street { get; set; }

    public string? Authority { get; set; }

    public string? Eid { get; set; }

    public string? CompName { get; set; }

    public string? Profession { get; set; }

    public string? TradeLicence { get; set; }

    public byte CustType { get; set; }

    public DateTime UpdtdTm { get; set; }
}
