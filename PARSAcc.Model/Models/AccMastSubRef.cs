using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AccMastSubRef
{
    public long? AccNo { get; set; }

    public long SubAccNo { get; set; }

    public string? AcCode { get; set; }

    public string? AcName { get; set; }

    public float Ob { get; set; }

    public float Cbal { get; set; }
}
