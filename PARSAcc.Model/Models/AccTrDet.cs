using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AccTrDet
{
    public int? LinkNo { get; set; }

    public int? AccountNo { get; set; }

    public DateTime? DueDate { get; set; }

    public short? TrSlNo { get; set; }

    public string? Reference { get; set; }

    public string? EntryRef { get; set; }

    public double? DealAmt { get; set; }

    public string? CurrencyCode { get; set; }

    public double? CurrRate { get; set; }

    public int? JobGrpId { get; set; }

    public string? JobCode { get; set; }

    public string? SmanCode { get; set; }

    public string? Pdcstatus { get; set; }

    public int? Pdcacc { get; set; }

    public string? Status { get; set; }

    public double? ApplAmt { get; set; }

    public string? BankCode { get; set; }

    public string? Lpono { get; set; }

    public string? DeptId { get; set; }

    public byte? OthCost { get; set; }

    public bool? ChqPrinted { get; set; }

    public byte? TrInf { get; set; }

    public string? TermsId { get; set; }

    public string? JobStr { get; set; }

    public string? PurchInvNo { get; set; }

    public bool RecntnTag { get; set; }

    public string? BrId { get; set; }

    public bool Approved { get; set; }

    public string? ApprvdBy { get; set; }

    public DateTime? ApprvdTime { get; set; }

    public int? CustAcc { get; set; }

    public int? Pono { get; set; }

    public double? SaleAmt { get; set; }

    public DateTime? PdctrfrDt { get; set; }

    public string? Counter { get; set; }

    public string? AccWithRef { get; set; }

    public bool IsBounced { get; set; }

    public bool DoHide { get; set; }

    public DateTime? ChqDate { get; set; }

    public string? ChqNo { get; set; }

    public string? ChqInf { get; set; }

    public int UnqNo { get; set; }

    public DateTime? DocDate { get; set; }

    public DateTime? SuppInvDate { get; set; }

    public DateTime? ModiDt { get; set; }

    public decimal AcTypeNo { get; set; }

    public DateTime? PhyDt { get; set; }

    public string? Remark { get; set; }

    public bool NotCosting { get; set; }

    public double TaxAmt { get; set; }

    public long? AccSubRef { get; set; }

    public byte? TaxtpNo { get; set; }

    public decimal SpTaxper { get; set; }

    public int SpTaxno { get; set; }

    public long? RchgId { get; set; }
}
