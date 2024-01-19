using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TempTb
{
    public short? TempId { get; set; }

    public DateTime? DtFrm { get; set; }

    public string? ConfCode { get; set; }

    public DateTime? DtSpRestr { get; set; }
}
