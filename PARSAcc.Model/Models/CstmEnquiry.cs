using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CstmEnquiry
{
    public int FmtId { get; set; }

    public string? FldName { get; set; }

    public byte Pos { get; set; }

    public int Cwidth { get; set; }

    public string? Fmt { get; set; }

    public byte Align { get; set; }

    public bool Hide { get; set; }

    public byte? EnqId { get; set; }
}
