using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DayPettyTr
{
    public int TrId { get; set; }

    public DateTime? Dt { get; set; }

    public string? UserId { get; set; }

    public int? AccountNo { get; set; }

    public string? Description { get; set; }

    public byte TypeNo { get; set; }

    public double? Amt { get; set; }

    public string? Remark { get; set; }

    public string? Party { get; set; }

    public int ChdocId { get; set; }
}
