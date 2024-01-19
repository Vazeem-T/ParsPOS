using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class UpdtdStatus
{
    /// <summary>
    /// 0-Leavel &amp; Group detail, 1 - Bank, 2- Unit
    /// </summary>
    public byte MasterNo { get; set; }

    public DateTime UpdtdTm { get; set; }
}
