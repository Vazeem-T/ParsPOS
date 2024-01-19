using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class Document
{
    public string DocCode { get; set; } = null!;

    public string? DocName { get; set; }

    public string? Building { get; set; }

    public int? IncAcc { get; set; }

    public int? AccrAcc { get; set; }

    public int? ContractGrpNo { get; set; }

    public bool ToOccupy { get; set; }

    public int? Deposit1Acc { get; set; }

    public int? Deposit2Acc { get; set; }
}
