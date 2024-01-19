using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SysTb
{
    public string? CompName { get; set; }

    public string? BasicCurrencyId { get; set; }

    public byte? NoOfDecimal { get; set; }

    public DateTime? AccPeriodFrm { get; set; }

    public DateTime? AccPeriodTo { get; set; }

    public string? Tel1 { get; set; }

    public string? Tel2 { get; set; }

    public string? Addr1 { get; set; }

    public string? Addr2 { get; set; }

    public string? Addr3 { get; set; }

    public string? Email { get; set; }

    public string? Www { get; set; }

    public byte? NoDysWarn { get; set; }

    public byte? CostingMethod { get; set; }

    public byte? WarnPdc { get; set; }

    public byte? ItemClass { get; set; }

    public byte? TimeOut { get; set; }

    public DateTime? ProtectUntil { get; set; }

    public int? MaxPer { get; set; }

    public string? DefLoc { get; set; }

    public string? DefLocName { get; set; }

    public byte? CrLmtId { get; set; }

    public byte? ItmTabNo { get; set; }

    public float? MarginPer { get; set; }

    public int? DefServiceItem { get; set; }

    public int? DontWarnAny { get; set; }

    public short? EquityGrpOfBS { get; set; }

    public string? EquityGrpOfBSdescr { get; set; }

    public string? CounterDb { get; set; }

    public string? ActiveBranch { get; set; }

    public bool IsHo { get; set; }

    public DateTime? DtLstBrUpdtd { get; set; }

    public DateTime? Posdate { get; set; }

    public string DefIc { get; set; } = null!;

    public bool OtonlyBp { get; set; }

    public bool LvSwithHra { get; set; }

    public bool WcfullHra { get; set; }

    public bool WcfullTpt { get; set; }

    public bool WcfullAllw1 { get; set; }

    public bool WcfullAllw2 { get; set; }

    public bool WcfullAllw3 { get; set; }

    public bool WcfullAllw4 { get; set; }

    public bool WcfullAllw5 { get; set; }

    public bool LsaddHra { get; set; }

    public bool LsaddTpt { get; set; }

    public bool LsaddAllw1 { get; set; }

    public bool LsaddAllw2 { get; set; }

    public bool LsaddAllw3 { get; set; }

    public bool LsaddAllw4 { get; set; }

    public bool LsaddAllw5 { get; set; }

    public string? LnkdPosbrDb { get; set; }

    public string? LnkdPosbrServer { get; set; }

    public bool? IsRestricted { get; set; }

    public string? CustKey { get; set; }

    public bool IsLinkedPos { get; set; }

    public string? EmailDb { get; set; }

    public string? Msg { get; set; }

    public bool Dccrtble { get; set; }

    public short? StockInHandGrp { get; set; }

    public DateTime? PoschgDtTm { get; set; }

    public string? EanstartWith { get; set; }

    public byte SwitchCntrInvMthd { get; set; }

    public byte CntrInvMthd { get; set; }

    public double MaxAllwdDisc { get; set; }

    public float MaxAllwdDiscPer { get; set; }

    public int? MaxPerPrvlgIi { get; set; }

    public byte[]? ImgLogo { get; set; }

    public double CntrDefOpn { get; set; }

    public string? LogDbName { get; set; }

    public bool EnaLog { get; set; }

    public short LogDays { get; set; }

    public short EnaCentralization { get; set; }

    public int RegNo { get; set; }

    public int TregNo { get; set; }

    public string? TestMsg { get; set; }

    public string? TestMsg1 { get; set; }

    public DateTime? PdalstUsdDt { get; set; }

    public byte Pdbno { get; set; }

    public string? CountryCode { get; set; }

    public double RoundFra { get; set; }

    public double MaxRvdisc { get; set; }

    public byte CntrznType { get; set; }

    public byte CntrznLinkType { get; set; }

    public int? CntrznNo { get; set; }

    public bool OtakId { get; set; }

    public bool EnaTax { get; set; }

    public string Trnno { get; set; } = null!;

    public string Prnno { get; set; } = null!;

    public DateTime TaxStDt { get; set; }

    public byte SlsRndIndex { get; set; }

    public byte PurRndIndex { get; set; }

    public decimal SlsRndFra { get; set; }

    public decimal PurRndFra { get; set; }

    public int? DProvinceNo { get; set; }

    public long LastUpdtdQrId { get; set; }

    public byte Taxlvl { get; set; }

    public DateTime? ProdctnDt { get; set; }

    public bool Qsmsactvate { get; set; }

    public string? Qsmspass { get; set; }

    public string? Qsmsurl { get; set; }

    public string? Qsmsmsg { get; set; }

    public bool FixStockValuesPl { get; set; }

    public double StkOpn { get; set; }

    public double StkEnd { get; set; }

    public double NstkOpn { get; set; }

    public double NstkEnd { get; set; }

    public long? AccForExpAdj { get; set; }
}
