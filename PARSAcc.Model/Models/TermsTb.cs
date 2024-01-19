using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TermsTb
{
    public string TermsId { get; set; } = null!;

    public string? TermsDescr { get; set; }

    public short? Ndays { get; set; }

    public byte Nmonths { get; set; }

    public DateTime UpdtdTm { get; set; }
}
