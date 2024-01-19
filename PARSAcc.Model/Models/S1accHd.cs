using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class S1accHd
{
    public short S1accId { get; set; }

    public short MaccId { get; set; }

    public string? Descr { get; set; }

    public string? GrpSetOn { get; set; }

    public bool IsContractGrp { get; set; }

    public string? ContractGrpId { get; set; }

    public bool? DelId { get; set; }

    public DateTime UpdtdTm { get; set; }
}
