using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdtdataTb
{
    public string? FlName { get; set; }

    public string? Location { get; set; }

    public string? BarCode { get; set; }

    public string? PdtbarCode { get; set; }

    public double Qty { get; set; }

    public int? SlNo { get; set; }

    public double Cost { get; set; }

    public float Pfraction { get; set; }

    public bool IsUpdated { get; set; }

    public int? Iid { get; set; }

    public int? BId { get; set; }

    public string? SExpDt { get; set; }

    public bool DoDel { get; set; }

    public DateTime? ExpDt { get; set; }

    public int RecNo { get; set; }

    public DateTime? ScanTm { get; set; }

    public string? IDescription { get; set; }

    public float SPrice { get; set; }

    public string? IUnit { get; set; }

    public string? SysLocation { get; set; }

    public string? SysBranch { get; set; }

    public bool IsAdjusted { get; set; }
}
