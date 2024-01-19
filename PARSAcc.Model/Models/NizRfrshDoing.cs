using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizRfrshDoing
{
    public string? ServerDb { get; set; }

    public int DoingDocNo { get; set; }

    public short DocType { get; set; }

    public DateTime ReqDtTm { get; set; }
}
