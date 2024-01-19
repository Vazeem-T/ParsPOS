using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpPmr
{
    public DateTime? UnqDt { get; set; }

    public long? BaseId { get; set; }

    public decimal? Pmr { get; set; }

    public decimal? CalcIpper { get; set; }

    public long? IptrId { get; set; }

    public long? FistrId { get; set; }

    public long? ListrId { get; set; }

    public int? NDays { get; set; }

    public decimal? Qih { get; set; }

    public decimal? SoldOutProjection { get; set; }

    public decimal? Ipqty { get; set; }

    public decimal? SoldQty { get; set; }

    public bool? OnProgress { get; set; }

    public DateTime? Qihdt { get; set; }

    public long? FromDtNo { get; set; }

    public long? ToDtNo { get; set; }
}
