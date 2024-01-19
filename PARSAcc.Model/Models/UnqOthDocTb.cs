using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class UnqOthDocTb
{
    public string Tp { get; set; } = null!;

    public long DocNo { get; set; }

    public DateTime? DocDt { get; set; }
}
