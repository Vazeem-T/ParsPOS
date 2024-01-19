using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DocAssgnTb
{
    public int? DocId { get; set; }

    public int? PriorTrId { get; set; }

    public int? TrId { get; set; }

    public int? ItemId { get; set; }

    public double TrQty { get; set; }

    public bool IsPrchOrSls { get; set; }

    public double TrMpqty { get; set; }

    public short? LineNo { get; set; }

    public double TrQtyFoc { get; set; }

    public int? BaseId { get; set; }
}
