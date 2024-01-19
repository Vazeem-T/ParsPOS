using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpQuickStmnt
{
    public int? SlNo { get; set; }

    public int? LoginId { get; set; }

    public string? Type { get; set; }

    public string? VrNo { get; set; }

    public DateTime? Dt { get; set; }

    public string? Description { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }

    public double? Bal { get; set; }

    public long? LinkNo { get; set; }

    public string? Dbname { get; set; }

    public string? Reference { get; set; }

    public DateTime CrtdDt { get; set; }

    public DateTime? ChqDate { get; set; }

    public decimal? WalletTr { get; set; }
}
