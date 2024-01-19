using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TrEdtExcmptTb
{
    public long ExcemptId { get; set; }

    /// <summary>
    /// 0 - except specific doc, 1 - within a range for specific type,, 2 - within a range
    /// </summary>
    public short? ExcemptTp { get; set; }

    public long? LinkNo { get; set; }

    public bool? IsAcc { get; set; }

    public string? TrType { get; set; }

    public DateTime? PrdFrom { get; set; }

    public DateTime? PrdTo { get; set; }

    public bool AllowOnlyOnce { get; set; }

    public string? SInvNo { get; set; }
}
