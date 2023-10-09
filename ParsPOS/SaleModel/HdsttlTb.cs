using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class HdsttlTb
{
    public long HdsttlId { get; set; }

    public int? EmpNo { get; set; }

    public DateTime SttlDt { get; set; }

    public float? OpnCash { get; set; }

    public float? ClosingCash { get; set; }
}
