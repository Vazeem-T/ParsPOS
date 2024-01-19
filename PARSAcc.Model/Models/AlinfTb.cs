using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AlinfTb
{
    public int? EmpNo { get; set; }

    public DateTime? LastReJoin { get; set; }

    public DateTime? LeaveStDt { get; set; }

    public DateTime? ReJoin { get; set; }

    public float? LeavePmonth { get; set; }

    public float? AirTaltmnt { get; set; }

    public double? AirTamt { get; set; }

    public float? CalLeaveDys { get; set; }

    public double? CalLeaveSal { get; set; }

    public short? AltdLvDays { get; set; }

    public bool IsAirTgranded { get; set; }

    public float? TtlMonthWrkd { get; set; }

    public bool IsTermination { get; set; }

    public bool LvSwithHra { get; set; }

    public double? BsHra { get; set; }

    public DateTime? HistReJoinDt { get; set; }

    public byte? HistDutyStatus { get; set; }

    public short? HistAltdLvDays { get; set; }

    public DateTime? HistLastAirTissdDt { get; set; }

    public double? LvAdvAmt { get; set; }

    public double? HistLvAdvAmt { get; set; }

    public double? Allowance1 { get; set; }

    public double? Allowance2 { get; set; }

    public double? Allowance3 { get; set; }

    public double? Allowance4 { get; set; }

    public double? Allowance5 { get; set; }

    public double? Transport { get; set; }

    public int? Hra { get; set; }

    public int? SecAmt { get; set; }

    public long Ano { get; set; }
}
