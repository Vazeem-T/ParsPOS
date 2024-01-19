using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class XlimpCmnTb
{
    public int XlimportedId { get; set; }

    public string? XlimpDescription { get; set; }

    public short? ModuleNo { get; set; }

    public DateTime? CrtdDt { get; set; }

    public string? CrtdBy { get; set; }

    public string? XlfileName { get; set; }

    public string? HdrKeyStr { get; set; }

    public string? EndKeyStr { get; set; }
}
