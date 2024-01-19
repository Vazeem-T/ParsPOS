using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AccTrOb
{
    public short? TrSlNo { get; set; }

    public int? AccountNo { get; set; }

    public DateTime? Jvdate { get; set; }

    public string? UserId { get; set; }

    public string? LstModiUsrId { get; set; }

    public int? LnkBkgNo { get; set; }

    public string? LnkContNo { get; set; }

    public DateTime? DueDate { get; set; }

    public string? Reference { get; set; }

    public string? EntryRef { get; set; }

    public double? DealAmt { get; set; }

    public string? CurrencyCode { get; set; }

    public int? JobGrpId { get; set; }

    public string? JobCode { get; set; }

    public string? SmanCode { get; set; }

    public double? CurrRate { get; set; }

    public string? Pdcstatus { get; set; }

    public int? Pdcacc { get; set; }

    public string? BankCode { get; set; }

    public string? DeptId { get; set; }

    public bool? ChqPrinted { get; set; }

    public byte? TrInf { get; set; }

    public string? PurchInvNo { get; set; }

    public bool IsBounced { get; set; }

    public DateTime? PdctrfrDt { get; set; }

    public string? BrId { get; set; }

    public string? ChqNo { get; set; }

    public DateTime? ChqDate { get; set; }

    public int UnqNo { get; set; }

    public DateTime? SuppInvDate { get; set; }
}
