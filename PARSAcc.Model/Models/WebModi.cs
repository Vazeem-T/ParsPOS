using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class WebModi
{
    public string FldObjId { get; set; } = null!;

    public short DocFor { get; set; }

    public DateTime ModiDt { get; set; }

    public bool Wait { get; set; }
}
