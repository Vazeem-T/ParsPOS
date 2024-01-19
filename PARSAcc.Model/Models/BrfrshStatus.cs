using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BrfrshStatus
{
    public string SysName { get; set; } = null!;

    public DateTime StartTm { get; set; }

    public DateTime RefreshTm { get; set; }

    public byte IsLogedOff { get; set; }

    public DateTime? ExitRefreshTm { get; set; }
}
