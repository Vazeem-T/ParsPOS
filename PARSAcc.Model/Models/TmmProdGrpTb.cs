using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TmmProdGrpTb
{
    public string? ServiceType { get; set; }

    public string? ServiceSubType { get; set; }

    public string? ServiceCategory { get; set; }

    public string? ServiceSubCategory { get; set; }

    public int SscId { get; set; }

    public string? IdPrnImgPath { get; set; }

    public string? IdBttnImgPath { get; set; }

    public DateTime CrtdTm { get; set; }

    public DateTime? ModiTm { get; set; }

    public byte[]? IdPrnImg { get; set; }

    public byte[]? IdBttnImg { get; set; }

    public long? RcprsProdNo { get; set; }

    public int AKey { get; set; }

    public DateTime? FlDtPrn { get; set; }

    public DateTime? FlDtBttn { get; set; }
}
