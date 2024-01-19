using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DocTranTb
{
    public int? DocId { get; set; }

    public int? BaseId { get; set; }

    public int? ItemId { get; set; }

    public string? Unit { get; set; }

    public string? TrDetail { get; set; }

    public double Qty { get; set; }

    public double CostPunit { get; set; }

    public short? SlNo { get; set; }

    public double ProssdQty { get; set; }

    public string? Location { get; set; }

    public double? PriorProssdQty { get; set; }

    public float Pfraction { get; set; }

    public double MtrPqty { get; set; }

    public byte? MsgId { get; set; }

    public int? LmsgNo { get; set; }

    public string? Pack { get; set; }

    public int ImpDocId { get; set; }

    public int ImpDocLnNo { get; set; }

    public double QtyFoc { get; set; }

    public double ProssdQtyFoc { get; set; }

    public double NormalCost { get; set; }

    public byte UnitFraCount { get; set; }

    public double LnDisc { get; set; }

    public string? Focdescr { get; set; }

    public string? Focmapping { get; set; }

    public double NormalDisc { get; set; }

    public long Anum { get; set; }

    public float LnDisc1 { get; set; }

    public bool IsLnDisc { get; set; }

    public DateTime? ExpDt { get; set; }

    public decimal TaxPer { get; set; }

    public double UnitDisc { get; set; }

    public bool DoTrWithTax { get; set; }

    public double PriceWithTax { get; set; }
}
