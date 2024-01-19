using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PassId
{
    public string UserId { get; set; } = null!;

    public int Id { get; set; }

    public bool MasterYn { get; set; }

    public string? Password { get; set; }

    public string? LstOpnBr { get; set; }

    public string? DefLoc { get; set; }

    public string? StripData { get; set; }

    public short Category { get; set; }

    public bool Suppress { get; set; }

    public byte[]? Ph { get; set; }
}
