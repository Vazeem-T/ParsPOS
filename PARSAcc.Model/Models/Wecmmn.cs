using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class Wecmmn
{
    public int Weid { get; set; }

    public DateTime? Wemonth { get; set; }

    public int? EmpNo { get; set; }

    public float? OtRate { get; set; }

    public float? OthRate { get; set; }

    public byte? WageCmthd { get; set; }

    public byte? OtwageCmthd { get; set; }

    public float? NWHrs { get; set; }

    public double? Salary { get; set; }

    public byte? SalStatus { get; set; }

    public double? Hra { get; set; }

    public double? Transport { get; set; }

    public double? Advance { get; set; }

    public double? Deduction { get; set; }

    public double? Deduction1 { get; set; }

    public double? Deduction2 { get; set; }

    public double? Loan { get; set; }

    public double? LosonEffect { get; set; }

    public double? LosonIssd { get; set; }

    public bool Protected { get; set; }

    public float? WageHr { get; set; }

    public float? OtwageHr { get; set; }

    public float? AbsentHr { get; set; }

    public string? Designation { get; set; }

    public float? SickLeave { get; set; }

    public float? PaidLeave { get; set; }

    public bool OtonlyBp { get; set; }

    public double? OtcalSal { get; set; }

    public string? BankAccNo { get; set; }

    public string? SiteAlloc { get; set; }

    public byte? PayMode { get; set; }

    public string? BankCode { get; set; }

    public string? BranchId { get; set; }

    public double? Allowance1 { get; set; }

    public double? Allowance2 { get; set; }

    public double? Allowance3 { get; set; }

    public double? Allowance4 { get; set; }

    public double? Allowance5 { get; set; }

    public string? WdeptId { get; set; }

    public float? Mult { get; set; }

    public double? SpAllow { get; set; }

    public string? SpAllowDescr { get; set; }

    public double? RetentionAmt { get; set; }

    public string? PayDeduCap1 { get; set; }

    public string? PayDeduCap2 { get; set; }

    public string? PayDeduCap3 { get; set; }

    public float? Crate { get; set; }

    public string? Wcurrency { get; set; }

    public byte? WageMode { get; set; }

    public double? AdminExp { get; set; }

    public double? Deposit { get; set; }

    public bool? AccUpdtd { get; set; }

    public bool? PayUpdtd { get; set; }

    public bool? PaymentUpdtd { get; set; }
}
