using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RemoteReqTb
{
    public DateTime RequestDt { get; set; }

    public string? ProcessId { get; set; }

    public string RequestPc { get; set; } = null!;

    public string StationPc { get; set; } = null!;

    public DateTime? CounterRfrshTm { get; set; }

    public byte ApprovStatus { get; set; }

    public string? ApprUser { get; set; }

    public string? Clerk { get; set; }

    public string? Counter { get; set; }

    public byte[]? Scrn { get; set; }

    public string? ProcessName { get; set; }

    public string? Msg { get; set; }

    public bool DoBell { get; set; }

    public DateTime? ApprvdTm { get; set; }

    public short IsLogin { get; set; }
}
