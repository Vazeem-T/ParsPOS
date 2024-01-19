using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ShpgTb
{
    public int? ShpgGrpId { get; set; }

    public int SgpgId { get; set; }

    public int? SlNo { get; set; }

    public string? ConsgnId { get; set; }

    public string? Blno { get; set; }

    public string? InvNo { get; set; }

    public string? Supplier { get; set; }

    public string? PortOfLdg { get; set; }

    public string? PortOfDischarge { get; set; }

    public string Status { get; set; } = null!;
}
