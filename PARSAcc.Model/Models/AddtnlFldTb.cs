using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AddtnlFldTb
{
    public int? TrId { get; set; }

    public string? Fld1 { get; set; }

    public string? Fld2 { get; set; }

    public string? Fld3 { get; set; }

    public string? Fld4 { get; set; }

    public string? Fld5 { get; set; }

    public string? Fld6 { get; set; }

    public string? Fld7 { get; set; }

    public string? Fld8 { get; set; }

    public string? CustMob { get; set; }

    public string? CustName { get; set; }

    public string? Fld9 { get; set; }

    public string? Fld10 { get; set; }

    public bool IsDocOrInv { get; set; }

    public bool IsInOut { get; set; }

    public double CashAmt { get; set; }

    public double Tendered { get; set; }

    public double CardAmt { get; set; }

    public double CreditAmt { get; set; }

    public double ChqAmt { get; set; }

    public int PartyAcc { get; set; }

    public string? ChqNo { get; set; }

    public string? Bank { get; set; }

    public DateTime? ChqDt { get; set; }
}
