using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ForSttntWhere
{
    public int AccountNo { get; set; }

    public string AccountId { get; set; } = null!;

    public string AccountName { get; set; } = null!;

    public string? GroupName { get; set; }

    public string? Category { get; set; }

    public string? SlsmanId { get; set; }

    public string? DeptId { get; set; }

    public string? Nature { get; set; }

    public short S1accId { get; set; }

    public string? AreaCode { get; set; }

    public string? CountryCode { get; set; }

    public string? BranchId { get; set; }

    public short? MaccId { get; set; }

    public string? Heading { get; set; }
}
