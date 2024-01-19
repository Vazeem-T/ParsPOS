using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ItmInvCmnTb
{
    public int TrId { get; set; }

    public decimal? InvTypeNo { get; set; }

    public DateTime? TrDate { get; set; }

    public string? TrType { get; set; }

    public string? PreFix { get; set; }

    public int? InvNo { get; set; }

    public int? Cscode { get; set; }

    public int? Psacc { get; set; }

    public string? TrRefNo { get; set; }

    public string? TrDescription { get; set; }

    public string? UserId { get; set; }

    public string? LstModiUsrId { get; set; }

    public double? InvTtlVol { get; set; }

    public double? InvTtlWt { get; set; }

    public double? InvTtlQty { get; set; }

    public double? Discount { get; set; }

    public double? OthCost { get; set; }

    public int? JobGrpId { get; set; }

    public int? Footer { get; set; }

    public string? DocLstTxt { get; set; }

    public string? SlsManId { get; set; }

    public bool IsAccUpdtd { get; set; }

    public bool Printed { get; set; }

    public string? RetInvIds { get; set; }

    public string? AreaCode { get; set; }

    public string? JobCode { get; set; }

    public string? Lpo { get; set; }

    public int? SlsPurchRetId { get; set; }

    public bool EnaJob { get; set; }

    public DateTime? DocDate { get; set; }

    public DateTime? SuppInvDate { get; set; }

    public string? TermsId { get; set; }

    public DateTime? DueDate { get; set; }

    public byte? ImpDoc { get; set; }

    public bool IsFc { get; set; }

    public double? Fcrate { get; set; }

    public int? Nfraction { get; set; }

    public string? Fc { get; set; }

    public double? Dis1 { get; set; }

    public double? Dis2 { get; set; }

    public double? Dis3 { get; set; }

    public string? BrId { get; set; }

    public string? OthInf { get; set; }

    public int? TypeNo { get; set; }

    public byte IsPos { get; set; }

    public byte? Approved { get; set; }

    public string? ApprvdBy { get; set; }

    public DateTime? ApprvdTime { get; set; }

    public string? DocDefLoc { get; set; }

    public bool DidExternal { get; set; }

    public double? Charge1 { get; set; }

    public double? Charge2 { get; set; }

    public double? Charge3 { get; set; }

    public double? Charge4 { get; set; }

    public double? Charge5 { get; set; }

    public string? Counter { get; set; }

    public int? OptId { get; set; }

    public DateTime? DelDate { get; set; }

    public bool DelStatus { get; set; }

    public DateTime? CrtDt { get; set; }

    public DateTime? ModiDt { get; set; }

    public string? DefStkOutBr { get; set; }

    public double? NetAmt { get; set; }

    public double? TtlOtherCost { get; set; }

    public double? TtlLnDisc { get; set; }

    public bool ChargesOnPl { get; set; }

    public bool IsInTransit { get; set; }

    public int PartyAccNo { get; set; }

    public double ReceiptAmt { get; set; }

    public double AdvanceAmt { get; set; }

    public long RcptLinkNo { get; set; }

    public byte DueCat { get; set; }

    public byte DueMonths { get; set; }

    public string DestBr { get; set; } = null!;

    public bool IsReadyToSend { get; set; }

    public float TaxAmt { get; set; }

    public bool DoRfrshTaxMnl { get; set; }

    public bool NoVatinv { get; set; }

    public int NoVatreasonId { get; set; }

    public float CalcTax { get; set; }

    public long? MtrId { get; set; }

    public string? SourceBr { get; set; }

    public float RddAmt { get; set; }

    public byte TaxtoNo { get; set; }

    public int? StateNo { get; set; }

    public byte RndIndex { get; set; }

    public decimal RndFra { get; set; }

    public bool IsPostrCompleted { get; set; }

    public bool WasRegistered { get; set; }

    public double TCessper { get; set; }

    public bool EnaSingleInc { get; set; }

    public float Cessamt { get; set; }

    public bool Asp { get; set; }

    public bool ElnBr { get; set; }

    public bool IsEstimate { get; set; }
}
