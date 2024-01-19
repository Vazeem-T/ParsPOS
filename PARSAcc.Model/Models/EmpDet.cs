using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class EmpDet
{
    public string EmpId { get; set; } = null!;

    public int EmpNo { get; set; }

    public string? OthId { get; set; }

    public string? EmpName { get; set; }

    public int? Hra { get; set; }

    public short? NoDays { get; set; }

    public short? DaysAbsnt { get; set; }

    public double? NrWage { get; set; }

    public double? Otwage { get; set; }

    public double? Deduction1 { get; set; }

    public double? Deduction2 { get; set; }

    public double? Deduction3 { get; set; }

    public string? Remark { get; set; }

    public string? Status { get; set; }

    public double? Allowance { get; set; }

    public double? BasicPay { get; set; }

    public double? Advance { get; set; }

    public string? Designation { get; set; }

    public string? VsDesignation { get; set; }

    public string? DeptId { get; set; }

    public int? AccountNo { get; set; }

    public DateTime? DtOfBirth { get; set; }

    public float? ContSalary { get; set; }

    public DateTime? JoinDt { get; set; }

    public DateTime? ReJoinDt { get; set; }

    public string? PassportNo { get; set; }

    public DateTime? PssDtExpd { get; set; }

    public DateTime? PssDtIssd { get; set; }

    public string? PssPlaceIssd { get; set; }

    public string? VisaNo { get; set; }

    public DateTime? VsDtIssd { get; set; }

    public DateTime? VsRnew { get; set; }

    public DateTime? VsDtExpd { get; set; }

    public string? LabCardNo { get; set; }

    public DateTime? LabDtIssd { get; set; }

    public DateTime? LabDtExpd { get; set; }

    public string? Hcno { get; set; }

    public DateTime? HcdtIssd { get; set; }

    public DateTime? HcdtExpd { get; set; }

    public string? Hcinform { get; set; }

    public string? Addr1 { get; set; }

    public string? Addr2 { get; set; }

    public string? Addr3 { get; set; }

    public string? Phone { get; set; }

    public string? Nationality { get; set; }

    public bool OnLeave { get; set; }

    public string? Photo { get; set; }

    public double? Transport { get; set; }

    public byte SalStatus { get; set; }

    public float? OtRate { get; set; }

    public float? OthRate { get; set; }

    public byte WageCmthd { get; set; }

    public byte OtwageCmthd { get; set; }

    public float? NWHrs { get; set; }

    public float? WageHr { get; set; }

    public float? LeavePmonth { get; set; }

    public float? AirTaltmnt { get; set; }

    public short? AltdLvDays { get; set; }

    public DateTime? LastAirTissdDt { get; set; }

    public byte DutyStatus { get; set; }

    public string? FatherName { get; set; }

    public string? PlaceOfBirth { get; set; }

    public DateTime? HistReJoinDt { get; set; }

    public byte? HistDutyStatus { get; set; }

    public short? HistAltdLvDays { get; set; }

    public DateTime? HistLastAirTissdDt { get; set; }

    public bool DoUndoJoin { get; set; }

    public double? LvAdvAmt { get; set; }

    public int? PreEmpNo { get; set; }

    public string? BankAccountNo { get; set; }

    public string? LeaveInf { get; set; }

    public double? Allowance1 { get; set; }

    public double? Allowance2 { get; set; }

    public double? Allowance3 { get; set; }

    public double? Allowance4 { get; set; }

    public double? Allowance5 { get; set; }

    public int? SalaryAcc { get; set; }

    public int? SalaryProvAcc { get; set; }

    public int? LvSalAcc { get; set; }

    public int? LvSalProvAcc { get; set; }

    public int? GratuityAcc { get; set; }

    public int? GratuityProvAcc { get; set; }

    public int? BonusAcc { get; set; }

    public int? BonusProvAcc { get; set; }

    public int? AirTicketAcc { get; set; }

    public int? AirTicketProvAcc { get; set; }

    public float? AltdMleave { get; set; }

    public float? AltdCashLeave { get; set; }

    public string? SiteAlloc { get; set; }

    public byte Gender { get; set; }

    public byte PayMode { get; set; }

    public string? BankCode { get; set; }

    public string? BranchId { get; set; }

    public double? TtlLoanOs { get; set; }

    public double? TtlSecuOs { get; set; }

    public string? DrvLicenNo { get; set; }

    public DateTime? DrvLissdDt { get; set; }

    public DateTime? DrvLexpDt { get; set; }

    public string? VehPlateNo { get; set; }

    public string? VehRegCardNo { get; set; }

    public string? Vehicle { get; set; }

    public DateTime? CardExpiry { get; set; }

    public string? Sponsor { get; set; }

    public string? Company { get; set; }

    public string? Currency { get; set; }

    public string? DesgnId { get; set; }

    public DateTime? LvApplDt { get; set; }

    public bool WcfullHra { get; set; }

    public bool WcfullTpt { get; set; }

    public bool WcfullAllw1 { get; set; }

    public bool WcfullAllw2 { get; set; }

    public bool WcfullAllw3 { get; set; }

    public bool WcfullAllw4 { get; set; }

    public bool WcfullAllw5 { get; set; }

    public bool LsaddHra { get; set; }

    public bool LsaddTpt { get; set; }

    public bool LsaddAllw1 { get; set; }

    public bool LsaddAllw2 { get; set; }

    public bool LsaddAllw3 { get; set; }

    public bool LsaddAllw4 { get; set; }

    public bool LsaddAllw5 { get; set; }

    public string? ProfId { get; set; }

    public byte? WageEmode { get; set; }

    public string? EmpNameArb { get; set; }

    public DateTime? EndedDt { get; set; }

    public bool NoLabCard { get; set; }

    public string? EmiratesIdNo { get; set; }

    public DateTime? EidDtExpd { get; set; }

    public DateTime? EidDtIssd { get; set; }
}
