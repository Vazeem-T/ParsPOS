using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BankTb
{
    public string BankCode { get; set; } = null!;

    public string? BankName { get; set; }

    public string? BankAcc { get; set; }

    public int? DefaRptNo { get; set; }

    public string? RptInf { get; set; }

    public bool IsCustom { get; set; }

    public DateTime UpdtdTm { get; set; }
}
