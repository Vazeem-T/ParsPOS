using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DocImgTb
{
    public int? KeyId { get; set; }

    public string? DocName { get; set; }

    public DateTime? ExpDt { get; set; }

    public string? DocImg { get; set; }

    public short ModuleId { get; set; }
}
