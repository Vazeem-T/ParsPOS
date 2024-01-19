using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ContractDetTb
{
    public int ContractNo { get; set; }

    public int SeqCntNo { get; set; }

    public string? CrtdBy { get; set; }

    public DateTime? CrtdTm { get; set; }

    public DateTime? CntrFrom { get; set; }

    public DateTime? CntrTo { get; set; }

    public decimal? CntrAmt { get; set; }

    public byte? Status { get; set; }

    public decimal DiscAmt { get; set; }

    public byte Optn { get; set; }

    public int OptnNo { get; set; }
}
