using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TaxsttlDetTb
{
    public int? LnkId { get; set; }

    public int? SlNo { get; set; }

    public int? AccNo1 { get; set; }

    public int? AccNo2 { get; set; }

    public int? AccNo3 { get; set; }

    public double? TaxAmt { get; set; }

    public double? SttlAmt { get; set; }

    public double? OpnAmt { get; set; }

    public double? IncAdjust { get; set; }
}
