using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AccMastAddr
{
    public int AccountNo { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? Address4 { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Reference { get; set; }

    public string? ContactName { get; set; }

    public string? Email { get; set; }

    public string? Mob { get; set; }

    public bool DelId { get; set; }

    public string? Address1Arb { get; set; }

    public string? Address2Arb { get; set; }

    public byte[]? Img { get; set; }
}
