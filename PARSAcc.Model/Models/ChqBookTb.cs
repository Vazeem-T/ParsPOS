using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ChqBookTb
{
    public int ChqBookId { get; set; }

    public DateTime? ChqBookDate { get; set; }

    public string? BankCode { get; set; }

    public string? ChqBookLotId { get; set; }

    public long StartingNumber { get; set; }

    public short NoOfLeaves { get; set; }

    public DateTime CrtdDt { get; set; }

    public DateTime? ModiDt { get; set; }

    public string? CrtdBy { get; set; }

    public string? ModiBy { get; set; }
}
