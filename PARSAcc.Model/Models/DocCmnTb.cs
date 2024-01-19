using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class DocCmnTb
{
    public int DocId { get; set; }

    public string? DocType { get; set; }

    public int? Dno { get; set; }

    public string? Reference { get; set; }

    public string? SlManId { get; set; }

    public int? Cscode { get; set; }

    public DateTime? Ddate { get; set; }

    public string? Comment { get; set; }

    public string? UserId { get; set; }

    public string? LstModiUsrId { get; set; }

    public string? Attn { get; set; }

    public string? Subject { get; set; }

    public double? Discount { get; set; }

    public int? Header { get; set; }

    public int? Footer { get; set; }

    public bool StkUpdtd { get; set; }

    public bool Printed { get; set; }

    public byte? ImpDoc { get; set; }

    public bool Imported { get; set; }

    public string? Note { get; set; }

    public string? TermsId { get; set; }

    public string? JobCode { get; set; }

    public byte? TrfrdAccUpdtd { get; set; }

    public byte Approved { get; set; }

    public string? ApprvdBy { get; set; }

    public DateTime? ApprvdTime { get; set; }

    public string? DocDefLoc { get; set; }

    public bool Suppress { get; set; }

    public double? DocAmt { get; set; }

    public bool Cancelled { get; set; }

    public string? CancelBy { get; set; }

    public DateTime? CancelTime { get; set; }

    public string? BrId { get; set; }

    public string? DeptId { get; set; }

    public DateTime? DelvDt { get; set; }

    public double ReceiptAmt { get; set; }

    public long RcptLinkNo { get; set; }

    public double AdvanceAmt { get; set; }

    public string? Pmail { get; set; }

    public int Otp { get; set; }

    public DateTime CrtDt { get; set; }

    public DateTime? ModiDt { get; set; }

    public bool DoSend { get; set; }

    public float TaxAmt { get; set; }

    public bool NoVatinv { get; set; }

    public int NoVatreasonId { get; set; }

    public int? TmpDocId { get; set; }

    public bool CancelPendg { get; set; }
}
