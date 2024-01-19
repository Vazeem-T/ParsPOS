using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RemoteRegTb
{
    public string StationPc { get; set; } = null!;

    public DateTime? StartTm { get; set; }

    public long? IdleTm { get; set; }

    public DateTime? RfrshTm { get; set; }

    public string? StationDescr { get; set; }
}
