using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class JobDetTbA
{
    public string JobCode { get; set; } = null!;

    public string? JobName { get; set; }

    public double? Amount { get; set; }

    public double? EstimateAmt { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? JobNature { get; set; }

    public double? OpnCost { get; set; }

    public double? OpnIncome { get; set; }

    public bool JobComplete { get; set; }

    public bool IsSubJob { get; set; }

    public int? CustAcc { get; set; }

    public string? Remark { get; set; }

    public string? SalesMan { get; set; }

    public int JobId { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModiDt { get; set; }

    public DateTime RfrshDt { get; set; }

    public bool IsOpen { get; set; }
}
