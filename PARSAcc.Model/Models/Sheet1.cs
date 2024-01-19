using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class Sheet1
{
    public string? AccId { get; set; }

    public DateTime? DocDate { get; set; }

    public string? DocNo { get; set; }

    public string? Reference { get; set; }

    public string? Narration { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }

    public double? PdcAmt { get; set; }

    public double? Opening { get; set; }

    public double? Balance { get; set; }

    public double? SaveAmt { get; set; }

    public int Id { get; set; }
}
