using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RptCustTb
{
    public int CustRptNo { get; set; }

    public string? CustRptName { get; set; }

    public string? CustRptType { get; set; }

    public string? CustRptCaption { get; set; }

    public string? CustPath { get; set; }

    public bool IsAtSharePath { get; set; }

    public string? BranchId { get; set; }

    public bool IsRpt11 { get; set; }

    public byte[]? RptFileObj { get; set; }

    public DateTime? RptFileMtm { get; set; }

    public DateTime? UpdtdTm { get; set; }
}
