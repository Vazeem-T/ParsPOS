using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class CntrInvStlmnt
{
    public int? SettleIdLnk { get; set; }

    public double? SOpnQty { get; set; }

    public double? PhyQty { get; set; }

    public int? BaseId { get; set; }
}
