using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class TableUsedTb
{
    public int TbId { get; set; }

    public string Counter { get; set; }

    public int? InvNo { get; set; }

    public DateTime? UpdtdDt { get; set; }

    public bool Deltd { get; set; }
}
