using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class AccTrCmn
{
    public decimal? JvtypeNo { get; set; }

    public string? Jvtype { get; set; }

    public int? Jvnum { get; set; }

    public string? PreFix { get; set; }

    public DateTime? Jvdate { get; set; }

    public string? UserId { get; set; }

    public string? LstModiUsrId { get; set; }

    public byte? TypeNo { get; set; }

    public int LnkBkgNo { get; set; }

    public int LnkContNo { get; set; }

    public int LnkNo { get; set; }

    public bool ContractTran { get; set; }

    public int LinkNo { get; set; }

    public DateTime CrtDtTm { get; set; }

    public string? VrDescr { get; set; }

    public string? OthInf { get; set; }

    public string? CmnBrId { get; set; }

    public byte LnkDocType { get; set; }

    public DateTime? ModiDtTm { get; set; }

    public string? CmnJobCode { get; set; }

    public int? TmpLinkNo { get; set; }

    public long? LTrId { get; set; }

    public short PrdDays { get; set; }

    public string? SourceBr { get; set; }

    public int MlinkNo { get; set; }

    public byte IsPos { get; set; }
}
