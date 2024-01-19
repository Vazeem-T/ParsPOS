using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AccMast
{
    public int AccountNo { get; set; }

    public string Alias { get; set; } = null!;

    public short S1accId { get; set; }

    public string AccDescr { get; set; } = null!;

    public string? CurrencyCode { get; set; }

    public double OpnBal { get; set; }

    public double? CreditLimit { get; set; }

    public string? DeptId { get; set; }

    public string? TermsId { get; set; }

    public string? SlsmanId { get; set; }

    public string? AreaCode { get; set; }

    public string? CountryCode { get; set; }

    public short? DueDays { get; set; }

    public byte? CommPer { get; set; }

    public DateTime? OpnDate { get; set; }

    public bool Hide { get; set; }

    public string? AccSetId { get; set; }

    public bool ForJobYn { get; set; }

    public bool JobAssgble { get; set; }

    public string? BranchId { get; set; }

    public bool IsObdet { get; set; }

    public double? ClosingBal { get; set; }

    public double? ClosingPdcramt { get; set; }

    public double OpnFcrt { get; set; }

    public float? DiscPer { get; set; }

    public string? Status { get; set; }

    public bool IsContract { get; set; }

    public string? AccPhoto { get; set; }

    public double? ContrAmt { get; set; }

    public byte? PriceGrp { get; set; }

    public bool Lpooptional { get; set; }

    public bool? DelId { get; set; }

    public string? Dloc { get; set; }

    public double? PromPer { get; set; }

    public bool EnableLimit { get; set; }

    public bool EnaDueDays { get; set; }

    public bool IsValidPos { get; set; }

    public DateTime ACrtdDt { get; set; }

    public DateTime AModiDt { get; set; }

    public byte DueDtClass { get; set; }

    public string? AccDescrArb { get; set; }

    public bool DealsInCash { get; set; }

    public bool IsValidCos { get; set; }

    public int? ShUnqNo { get; set; }

    public string PartyTrnno { get; set; } = null!;

    public string? Title { get; set; }

    public byte TaxtypeNo { get; set; }

    public int? ProvinceNo { get; set; }

    public string? NickName { get; set; }
}
