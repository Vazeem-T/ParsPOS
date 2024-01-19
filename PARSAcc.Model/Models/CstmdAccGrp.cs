using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CstmdAccGrp
{
    public int CgrpId { get; set; }

    public string CgrpCode { get; set; } = null!;

    public string CgrpName { get; set; } = null!;

    public int AddrAccId { get; set; }
}
