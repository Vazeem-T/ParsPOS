using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class OfferSession
{
    public int SessionId { get; set; }

    public string? OfferDescr { get; set; }

    public DateTime? PrdFrom { get; set; }

    public DateTime? PrdTo { get; set; }

    public bool IsEnabled { get; set; }

    public bool EnaWeekDays { get; set; }

    public bool Mon { get; set; }

    public bool Tue { get; set; }

    public bool Wed { get; set; }

    public bool Thu { get; set; }

    public bool Fri { get; set; }

    public bool Sat { get; set; }

    public bool Sun { get; set; }

    public bool DelId { get; set; }

    public int? Bgodid { get; set; }

    public int? Bgfid { get; set; }

    public int? Boaid { get; set; }
}
