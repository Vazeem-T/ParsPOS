using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpAccImg
{
    public int AccountNo { get; set; }

    public byte[]? AccBar { get; set; }

    public string? AccId { get; set; }
}
