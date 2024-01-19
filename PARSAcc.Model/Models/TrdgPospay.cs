using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TrdgPospay
{
    public int? TrId { get; set; }

    public string? SlsMan { get; set; }

    public string? PayType { get; set; }

    public byte? Ctgry { get; set; }

    public string? Description { get; set; }

    public int? SlNo { get; set; }

    public int? AccNoCr { get; set; }

    public int? AccNoDr { get; set; }

    public double? Amount { get; set; }

    public string? CardName { get; set; }

    public long? VchrNo { get; set; }

    public long Id { get; set; }

    public int CouponId { get; set; }

    public double Tendered { get; set; }

    public double AssignedAmt { get; set; }

    public int Pfid { get; set; }

    public bool IsRv { get; set; }

    public bool IsExp { get; set; }
}
