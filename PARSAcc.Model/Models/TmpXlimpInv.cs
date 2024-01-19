using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmpXlimpInv
{
    public string? XlprodCode { get; set; }

    public string? Xldescription { get; set; }

    public string? Xlunit { get; set; }

    public float XlunitVal { get; set; }

    public float Xlqty { get; set; }

    public DateTime? SysDtTm { get; set; }

    public int? SysXlimportedId { get; set; }

    public int? SysSlNo { get; set; }

    public DateTime? SysDoDelDt { get; set; }

    public string? Xlbcode { get; set; }

    public bool XlisNew { get; set; }

    public float Xlacost { get; set; }

    public decimal XllnDisc { get; set; }

    public decimal XllnDisc1 { get; set; }
}
