using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LocTrCmn
{
    public int TrId { get; set; }

    public DateTime? TrDate { get; set; }

    public string? TrType { get; set; }

    public int? InvNo { get; set; }

    public int? Cscode { get; set; }

    public string? TrRefNo { get; set; }

    public string? TrDescription { get; set; }

    public string? UserId { get; set; }

    public string? LstModiUsrId { get; set; }

    public int? Footer { get; set; }

    public string? SlsManId { get; set; }

    public string? JobCode { get; set; }

    public string? BrId { get; set; }

    public string? DefLocFrom { get; set; }

    public string? DefLocTo { get; set; }
}
