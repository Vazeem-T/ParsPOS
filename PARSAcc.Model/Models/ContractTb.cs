using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ContractTb
{
    public int ContractNo { get; set; }

    public DateTime? DocDt { get; set; }

    public string? Remark { get; set; }

    public long? PkgNo { get; set; }

    public long? PartyAcc { get; set; }

    public int? ApplNo { get; set; }

    public bool IsGroup { get; set; }

    public string? Ref { get; set; }

    public string? UserId { get; set; }

    public string? ModiBy { get; set; }

    public DateTime? CrtdDt { get; set; }

    public DateTime? ModiTm { get; set; }
}
