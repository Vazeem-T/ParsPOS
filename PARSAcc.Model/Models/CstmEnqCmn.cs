using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CstmEnqCmn
{
    public byte? EnqId { get; set; }

    public string UserId { get; set; } = null!;

    public int FmtId { get; set; }

    public string? Pcname { get; set; }
}
