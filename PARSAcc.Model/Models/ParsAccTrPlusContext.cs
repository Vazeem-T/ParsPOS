using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PARSAcc.Model.Models;

public partial class ParsAccTrPlusContext : DbContext
{
    public ParsAccTrPlusContext()
    {
    }

    public ParsAccTrPlusContext(DbContextOptions<ParsAccTrPlusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccMast> AccMasts { get; set; }

    public virtual DbSet<AccMastAddr> AccMastAddrs { get; set; }

    public virtual DbSet<AccMastSubRef> AccMastSubRefs { get; set; }

    public virtual DbSet<AccTrCmn> AccTrCmns { get; set; }

    public virtual DbSet<AccTrDet> AccTrDets { get; set; }

    public virtual DbSet<AccTrOb> AccTrObs { get; set; }

    public virtual DbSet<AddtnlFldTb> AddtnlFldTbs { get; set; }

    public virtual DbSet<AdvanceTb> AdvanceTbs { get; set; }

    public virtual DbSet<AlinfTb> AlinfTbs { get; set; }

    public virtual DbSet<AreaTb> AreaTbs { get; set; }

    public virtual DbSet<BalanceQr> BalanceQrs { get; set; }

    public virtual DbSet<BankTb> BankTbs { get; set; }

    public virtual DbSet<BarCustFmt> BarCustFmts { get; set; }

    public virtual DbSet<BarDirectPrtReq> BarDirectPrtReqs { get; set; }

    public virtual DbSet<BarFieldTb> BarFieldTbs { get; set; }

    public virtual DbSet<BarFmtDirect> BarFmtDirects { get; set; }

    public virtual DbSet<BarObject> BarObjects { get; set; }

    public virtual DbSet<BaseItmDet> BaseItmDets { get; set; }

    public virtual DbSet<BaseTb> BaseTbs { get; set; }

    public virtual DbSet<Bcode> Bcodes { get; set; }

    public virtual DbSet<BinTb> BinTbs { get; set; }

    public virtual DbSet<BplogTb> BplogTbs { get; set; }

    public virtual DbSet<BrItem> BrItems { get; set; }

    public virtual DbSet<BrPrice> BrPrices { get; set; }

    public virtual DbSet<BranchTb> BranchTbs { get; set; }

    public virtual DbSet<BrfrshStatus> BrfrshStatuses { get; set; }

    public virtual DbSet<BudjetTb> BudjetTbs { get; set; }

    public virtual DbSet<ChqBookTb> ChqBookTbs { get; set; }

    public virtual DbSet<ChqLeaf> ChqLeaves { get; set; }

    public virtual DbSet<ChqPrintTb> ChqPrintTbs { get; set; }

    public virtual DbSet<CmnVrTypeTb> CmnVrTypeTbs { get; set; }

    public virtual DbSet<CntrInvProd> CntrInvProds { get; set; }

    public virtual DbSet<ColPopup> ColPopups { get; set; }

    public virtual DbSet<ColProperty> ColProperties { get; set; }

    public virtual DbSet<ComponentTb> ComponentTbs { get; set; }

    public virtual DbSet<ContrRcptTb> ContrRcptTbs { get; set; }

    public virtual DbSet<ContractDetTb> ContractDetTbs { get; set; }

    public virtual DbSet<ContractTb> ContractTbs { get; set; }

    public virtual DbSet<CounterStatus> CounterStatuses { get; set; }

    public virtual DbSet<CounterTb> CounterTbs { get; set; }

    public virtual DbSet<CountryTb> CountryTbs { get; set; }

    public virtual DbSet<CshHdocTb> CshHdocTbs { get; set; }

    public virtual DbSet<CshHopn> CshHopns { get; set; }

    public virtual DbSet<CstmAccLst> CstmAccLsts { get; set; }

    public virtual DbSet<CstmEnqCmn> CstmEnqCmns { get; set; }

    public virtual DbSet<CstmEnquiry> CstmEnquiries { get; set; }

    public virtual DbSet<CstmdAccGrp> CstmdAccGrps { get; set; }

    public virtual DbSet<CuponTb> CuponTbs { get; set; }

    public virtual DbSet<CurrencyTb> CurrencyTbs { get; set; }

    public virtual DbSet<CustGrpAssgnTb> CustGrpAssgnTbs { get; set; }

    public virtual DbSet<CustPrdAssgnTb> CustPrdAssgnTbs { get; set; }

    public virtual DbSet<CustProdCtb> CustProdCtbs { get; set; }

    public virtual DbSet<CustProdTb> CustProdTbs { get; set; }

    public virtual DbSet<CustShortCutDet> CustShortCutDets { get; set; }

    public virtual DbSet<CustShortcutCmn> CustShortcutCmns { get; set; }

    public virtual DbSet<CustmVr> CustmVrs { get; set; }

    public virtual DbSet<DayLeaveRegTb> DayLeaveRegTbs { get; set; }

    public virtual DbSet<DayPettyTr> DayPettyTrs { get; set; }

    public virtual DbSet<DefPayrollAcGrp> DefPayrollAcGrps { get; set; }

    public virtual DbSet<DepartmentTb> DepartmentTbs { get; set; }

    public virtual DbSet<DesignationTb> DesignationTbs { get; set; }

    public virtual DbSet<DiscCardTb> DiscCardTbs { get; set; }

    public virtual DbSet<DocAdnlFldTb> DocAdnlFldTbs { get; set; }

    public virtual DbSet<DocAssgnTb> DocAssgnTbs { get; set; }

    public virtual DbSet<DocCmnTb> DocCmnTbs { get; set; }

    public virtual DbSet<DocImgTb> DocImgTbs { get; set; }

    public virtual DbSet<DocInfTb> DocInfTbs { get; set; }

    public virtual DbSet<DocTranTb> DocTranTbs { get; set; }

    public virtual DbSet<DocUsrLstTb> DocUsrLstTbs { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DsubClassTb> DsubClassTbs { get; set; }

    public virtual DbSet<EmpDet> EmpDets { get; set; }

    public virtual DbSet<EmpFldCapTb> EmpFldCapTbs { get; set; }

    public virtual DbSet<EmpItemsTb> EmpItemsTbs { get; set; }

    public virtual DbSet<EmpNotesTb> EmpNotesTbs { get; set; }

    public virtual DbSet<ExpAdjustTb> ExpAdjustTbs { get; set; }

    public virtual DbSet<ExpFlUnq> ExpFlUnqs { get; set; }

    public virtual DbSet<FixedVr> FixedVrs { get; set; }

    public virtual DbSet<FldCaptionTb> FldCaptionTbs { get; set; }

    public virtual DbSet<ForSttntWhere> ForSttntWheres { get; set; }

    public virtual DbSet<GlAcc> GlAccs { get; set; }

    public virtual DbSet<GratProvTb> GratProvTbs { get; set; }

    public virtual DbSet<GratuityTb> GratuityTbs { get; set; }

    public virtual DbSet<GrpItmTb> GrpItmTbs { get; set; }

    public virtual DbSet<HeadFoot> HeadFeet { get; set; }

    public virtual DbSet<Hsntb> Hsntbs { get; set; }

    public virtual DbSet<InvItm> InvItms { get; set; }

    public virtual DbSet<InvNo> InvNos { get; set; }

    public virtual DbSet<InvNoImgTb> InvNoImgTbs { get; set; }

    public virtual DbSet<IsapprovalAfterAgd> IsapprovalAfterAgds { get; set; }

    public virtual DbSet<ItemMastLevel> ItemMastLevels { get; set; }

    public virtual DbSet<ItmInvCmnTb> ItmInvCmnTbs { get; set; }

    public virtual DbSet<ItmInvTrTb> ItmInvTrTbs { get; set; }

    public virtual DbSet<JobColPopup> JobColPopups { get; set; }

    public virtual DbSet<JobColProperty> JobColProperties { get; set; }

    public virtual DbSet<JobDetTbA> JobDetTbAs { get; set; }

    public virtual DbSet<JobEstimateTb> JobEstimateTbs { get; set; }

    public virtual DbSet<JobInfTb> JobInfTbs { get; set; }

    public virtual DbSet<JobPriorYrTb> JobPriorYrTbs { get; set; }

    public virtual DbSet<LanguageTb> LanguageTbs { get; set; }

    public virtual DbSet<LastDocNoTb> LastDocNoTbs { get; set; }

    public virtual DbSet<LastJobDid> LastJobDids { get; set; }

    public virtual DbSet<LastPsinfTb> LastPsinfTbs { get; set; }

    public virtual DbSet<LevelTb> LevelTbs { get; set; }

    public virtual DbSet<LmsgTb> LmsgTbs { get; set; }

    public virtual DbSet<LoanDetTb> LoanDetTbs { get; set; }

    public virtual DbSet<LoanTb> LoanTbs { get; set; }

    public virtual DbSet<LocTrCmn> LocTrCmns { get; set; }

    public virtual DbSet<LocTrDet> LocTrDets { get; set; }

    public virtual DbSet<LocationTb> LocationTbs { get; set; }

    public virtual DbSet<LoginStatusTb> LoginStatusTbs { get; set; }

    public virtual DbSet<LvSalProvTb> LvSalProvTbs { get; set; }

    public virtual DbSet<MaccHd> MaccHds { get; set; }

    public virtual DbSet<MenuTb> MenuTbs { get; set; }

    public virtual DbSet<ModuEnaTb> ModuEnaTbs { get; set; }

    public virtual DbSet<ModuleColourTb> ModuleColourTbs { get; set; }

    public virtual DbSet<ModuleCustomTb> ModuleCustomTbs { get; set; }

    public virtual DbSet<NarationTb> NarationTbs { get; set; }

    public virtual DbSet<NizBalAnalysis> NizBalAnalyses { get; set; }

    public virtual DbSet<NizBalAnalysisR> NizBalAnalysisRs { get; set; }

    public virtual DbSet<NizCashFlowTb> NizCashFlowTbs { get; set; }

    public virtual DbSet<NizPrdOpnClVal> NizPrdOpnClVals { get; set; }

    public virtual DbSet<NizPvlpoassgnmnt> NizPvlpoassgnmnts { get; set; }

    public virtual DbSet<NizRfrhT> NizRfrhTs { get; set; }

    public virtual DbSet<NizRfrhTacc> NizRfrhTaccs { get; set; }

    public virtual DbSet<NizRfrshDoing> NizRfrshDoings { get; set; }

    public virtual DbSet<NizRfrshPending> NizRfrshPendings { get; set; }

    public virtual DbSet<NoTaxtypeTb> NoTaxtypeTbs { get; set; }

    public virtual DbSet<NprdCode> NprdCodes { get; set; }

    public virtual DbSet<NprdUser> NprdUsers { get; set; }

    public virtual DbSet<NsinvPurchAcc> NsinvPurchAccs { get; set; }

    public virtual DbSet<NsmnthlyExp> NsmnthlyExps { get; set; }

    public virtual DbSet<OfferBgftp> OfferBgftps { get; set; }

    public virtual DbSet<OfferBgodtp> OfferBgodtps { get; set; }

    public virtual DbSet<OfferBoatp> OfferBoatps { get; set; }

    public virtual DbSet<OfferSession> OfferSessions { get; set; }

    public virtual DbSet<PassCardTb> PassCardTbs { get; set; }

    public virtual DbSet<PassFngrTb> PassFngrTbs { get; set; }

    public virtual DbSet<PassId> PassIds { get; set; }

    public virtual DbSet<PassSuperCardTb> PassSuperCardTbs { get; set; }

    public virtual DbSet<PdabcprtReq> PdabcprtReqs { get; set; }

    public virtual DbSet<Pdalist> Pdalists { get; set; }

    public virtual DbSet<PdanewProdReq> PdanewProdReqs { get; set; }

    public virtual DbSet<PdaprdChgReqCmn> PdaprdChgReqCmns { get; set; }

    public virtual DbSet<PdaprdChgReqDet> PdaprdChgReqDets { get; set; }

    public virtual DbSet<PdaprodList> PdaprodLists { get; set; }

    public virtual DbSet<PdatrCmn> PdatrCmns { get; set; }

    public virtual DbSet<PdatrDet> PdatrDets { get; set; }

    public virtual DbSet<PdtdataTb> PdtdataTbs { get; set; }

    public virtual DbSet<PeriodClosingTb> PeriodClosingTbs { get; set; }

    public virtual DbSet<PettyDescrTb> PettyDescrTbs { get; set; }

    public virtual DbSet<Pgassgn> Pgassgns { get; set; }

    public virtual DbSet<PhyCmnTb> PhyCmnTbs { get; set; }

    public virtual DbSet<PhyDetTb> PhyDetTbs { get; set; }

    public virtual DbSet<PhyDoingTb> PhyDoingTbs { get; set; }

    public virtual DbSet<PhySmmTb> PhySmmTbs { get; set; }

    public virtual DbSet<PkPrice> PkPrices { get; set; }

    public virtual DbSet<PoscrNoteTb> PoscrNoteTbs { get; set; }

    public virtual DbSet<PostatusTb> PostatusTbs { get; set; }

    public virtual DbSet<PrdGrpCmnTb> PrdGrpCmnTbs { get; set; }

    public virtual DbSet<PrdGrpDetTb> PrdGrpDetTbs { get; set; }

    public virtual DbSet<PrdSrlNoTrTb> PrdSrlNoTrTbs { get; set; }

    public virtual DbSet<PreFixTb> PreFixTbs { get; set; }

    public virtual DbSet<PriceChgLog> PriceChgLogs { get; set; }

    public virtual DbSet<PriceGrpTb> PriceGrpTbs { get; set; }

    public virtual DbSet<PriorYearInfTb> PriorYearInfTbs { get; set; }

    public virtual DbSet<ProdImgTb> ProdImgTbs { get; set; }

    public virtual DbSet<ProdPadTb> ProdPadTbs { get; set; }

    public virtual DbSet<ProdServiceTb> ProdServiceTbs { get; set; }

    public virtual DbSet<ProvinceTb> ProvinceTbs { get; set; }

    public virtual DbSet<ProvisionCmnTb> ProvisionCmnTbs { get; set; }

    public virtual DbSet<ProvisionDetTb> ProvisionDetTbs { get; set; }

    public virtual DbSet<PrvlgSrvrInfTb> PrvlgSrvrInfTbs { get; set; }

    public virtual DbSet<PurchRegTb> PurchRegTbs { get; set; }

    public virtual DbSet<RechargeTrTb> RechargeTrTbs { get; set; }

    public virtual DbSet<RecoveredTab2> RecoveredTab2s { get; set; }

    public virtual DbSet<RemoteRegTb> RemoteRegTbs { get; set; }

    public virtual DbSet<RemoteReqTb> RemoteReqTbs { get; set; }

    public virtual DbSet<RentedAccTb> RentedAccTbs { get; set; }

    public virtual DbSet<RfrshRequestTb> RfrshRequestTbs { get; set; }

    public virtual DbSet<Right> Rights { get; set; }

    public virtual DbSet<RightNode> RightNodes { get; set; }

    public virtual DbSet<RptBranchTb> RptBranchTbs { get; set; }

    public virtual DbSet<RptCmnTb> RptCmnTbs { get; set; }

    public virtual DbSet<RptCmnXltb> RptCmnXltbs { get; set; }

    public virtual DbSet<RptCustTb> RptCustTbs { get; set; }

    public virtual DbSet<RptDetTb> RptDetTbs { get; set; }

    public virtual DbSet<RptListTb> RptListTbs { get; set; }

    public virtual DbSet<RptLocalDef> RptLocalDefs { get; set; }

    public virtual DbSet<RptUnqXltb> RptUnqXltbs { get; set; }

    public virtual DbSet<S1accHd> S1accHds { get; set; }

    public virtual DbSet<SalInfTb> SalInfTbs { get; set; }

    public virtual DbSet<SalesmanTb> SalesmanTbs { get; set; }

    public virtual DbSet<ScaleSttgTb> ScaleSttgTbs { get; set; }

    public virtual DbSet<ScanProdTb> ScanProdTbs { get; set; }

    public virtual DbSet<SdepoDetTb> SdepoDetTbs { get; set; }

    public virtual DbSet<SdepoTb> SdepoTbs { get; set; }

    public virtual DbSet<SessnItem> SessnItems { get; set; }

    public virtual DbSet<ShareSrvrInfTb> ShareSrvrInfTbs { get; set; }

    public virtual DbSet<Sheet1> Sheet1s { get; set; }

    public virtual DbSet<ShpgGrpTb> ShpgGrpTbs { get; set; }

    public virtual DbSet<ShpgItm> ShpgItms { get; set; }

    public virtual DbSet<ShpgTb> ShpgTbs { get; set; }

    public virtual DbSet<SpTaxtb> SpTaxtbs { get; set; }

    public virtual DbSet<SuppPrdTb> SuppPrdTbs { get; set; }

    public virtual DbSet<SysPara> SysParas { get; set; }

    public virtual DbSet<SysParaOpt> SysParaOpts { get; set; }

    public virtual DbSet<SysTb> SysTbs { get; set; }

    public virtual DbSet<TargetDocDtb> TargetDocDtbs { get; set; }

    public virtual DbSet<TargetDocTb> TargetDocTbs { get; set; }

    public virtual DbSet<TaxsttlDetTb> TaxsttlDetTbs { get; set; }

    public virtual DbSet<TaxtpTb> TaxtpTbs { get; set; }

    public virtual DbSet<TempTb> TempTbs { get; set; }

    public virtual DbSet<TermsTb> TermsTbs { get; set; }

    public virtual DbSet<TmmCountryTb> TmmCountryTbs { get; set; }

    public virtual DbSet<TmmPlanTb> TmmPlanTbs { get; set; }

    public virtual DbSet<TmmPrdSaleCmn> TmmPrdSaleCmns { get; set; }

    public virtual DbSet<TmmProdGrpTb> TmmProdGrpTbs { get; set; }

    public virtual DbSet<TmmStng> TmmStngs { get; set; }

    public virtual DbSet<TmpAccImg> TmpAccImgs { get; set; }

    public virtual DbSet<TmpAssCompnt> TmpAssCompnts { get; set; }

    public virtual DbSet<TmpDayActRptTb> TmpDayActRptTbs { get; set; }

    public virtual DbSet<TmpDayTrTb> TmpDayTrTbs { get; set; }

    public virtual DbSet<TmpPhyDetTb> TmpPhyDetTbs { get; set; }

    public virtual DbSet<TmpPhySmmTb> TmpPhySmmTbs { get; set; }

    public virtual DbSet<TmpPmr> TmpPmrs { get; set; }

    public virtual DbSet<TmpQuickSldgr> TmpQuickSldgrs { get; set; }

    public virtual DbSet<TmpQuickStmnt> TmpQuickStmnts { get; set; }

    public virtual DbSet<TmpUnqDt> TmpUnqDts { get; set; }

    public virtual DbSet<TmpXlimpInv> TmpXlimpInvs { get; set; }

    public virtual DbSet<TrEdtExcmptTb> TrEdtExcmptTbs { get; set; }

    public virtual DbSet<TrdgPospay> TrdgPospays { get; set; }

    public virtual DbSet<UniqInvTb> UniqInvTbs { get; set; }

    public virtual DbSet<UniqInvTb1> UniqInvTb1s { get; set; }

    public virtual DbSet<UnitsTb> UnitsTbs { get; set; }

    public virtual DbSet<UnqOthDocTb> UnqOthDocTbs { get; set; }

    public virtual DbSet<UpdtdStatus> UpdtdStatuses { get; set; }

    public virtual DbSet<UpdtdStatus4IndCntr> UpdtdStatus4IndCntrs { get; set; }

    public virtual DbSet<UpdtdStatusDeleted> UpdtdStatusDeleteds { get; set; }

    public virtual DbSet<UserPostb> UserPostbs { get; set; }

    public virtual DbSet<UsrBr> UsrBrs { get; set; }

    public virtual DbSet<UwaccsTb> UwaccsTbs { get; set; }

    public virtual DbSet<UwitemsTb> UwitemsTbs { get; set; }

    public virtual DbSet<ValidChildTb> ValidChildTbs { get; set; }

    public virtual DbSet<VrCmn> VrCmns { get; set; }

    public virtual DbSet<WebModi> WebModis { get; set; }

    public virtual DbSet<Wecmmn> Wecmmns { get; set; }

    public virtual DbSet<Wedet> Wedets { get; set; }

    public virtual DbSet<Whtb> Whtbs { get; set; }

    public virtual DbSet<XlimpCmnTb> XlimpCmnTbs { get; set; }

    public virtual DbSet<XlimpFmtDtb> XlimpFmtDtbs { get; set; }

    public virtual DbSet<XlrptQrTb> XlrptQrTbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = LAPTOP-EVI0DDQV;Database=PARSAccTrPlusFLN; User ID = sa; Password=#1802kjh;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccMast>(entity =>
        {
            entity.HasKey(e => e.AccountNo);

            entity.ToTable("AccMast");

            entity.HasIndex(e => e.Alias, "IX_AccMast").IsUnique();

            entity.HasIndex(e => e.AccDescr, "IX_AccMast_1").IsUnique();

            entity.Property(e => e.AccountNo).ValueGeneratedNever();
            entity.Property(e => e.ACrtdDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("aCrtdDt");
            entity.Property(e => e.AModiDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("aModiDt");
            entity.Property(e => e.AccDescr).HasMaxLength(60);
            entity.Property(e => e.AccDescrArb).HasMaxLength(120);
            entity.Property(e => e.AccPhoto).HasMaxLength(20);
            entity.Property(e => e.AccSetId).HasMaxLength(50);
            entity.Property(e => e.Alias).HasMaxLength(10);
            entity.Property(e => e.AreaCode).HasMaxLength(10);
            entity.Property(e => e.BranchId).HasMaxLength(10);
            entity.Property(e => e.ClosingBal).HasDefaultValue(0.0);
            entity.Property(e => e.ClosingPdcramt).HasColumnName("ClosingPDCRAmt");
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CurrencyCode).HasMaxLength(3);
            entity.Property(e => e.DeptId).HasMaxLength(10);
            entity.Property(e => e.Dloc)
                .HasMaxLength(50)
                .HasColumnName("DLoc");
            entity.Property(e => e.ForJobYn).HasColumnName("ForJobYN");
            entity.Property(e => e.IsContract).HasColumnName("isContract");
            entity.Property(e => e.IsObdet).HasColumnName("IsOBDet");
            entity.Property(e => e.IsValidCos).HasColumnName("IsValidCOS");
            entity.Property(e => e.IsValidPos).HasColumnName("IsValidPOS");
            entity.Property(e => e.Lpooptional).HasColumnName("LPOOptional");
            entity.Property(e => e.NickName).HasMaxLength(10);
            entity.Property(e => e.OpnDate).HasColumnType("datetime");
            entity.Property(e => e.OpnFcrt)
                .HasDefaultValue(1.0)
                .HasColumnName("OpnFCRt");
            entity.Property(e => e.PartyTrnno)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("PartyTRNNo");
            entity.Property(e => e.S1accId).HasColumnName("S1AccId");
            entity.Property(e => e.ShUnqNo).HasColumnName("shUnqNo");
            entity.Property(e => e.SlsmanId).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.TaxtypeNo).HasColumnName("TAXTypeNo");
            entity.Property(e => e.TermsId).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(4);
        });

        modelBuilder.Entity<AccMastAddr>(entity =>
        {
            entity.HasKey(e => e.AccountNo);

            entity.ToTable("AccMastAddr");

            entity.Property(e => e.AccountNo).ValueGeneratedNever();
            entity.Property(e => e.Address1).HasMaxLength(150);
            entity.Property(e => e.Address1Arb).HasMaxLength(200);
            entity.Property(e => e.Address2).HasMaxLength(60);
            entity.Property(e => e.Address2Arb).HasMaxLength(120);
            entity.Property(e => e.Address3).HasMaxLength(60);
            entity.Property(e => e.Address4).HasMaxLength(100);
            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMail");
            entity.Property(e => e.Fax).HasMaxLength(30);
            entity.Property(e => e.Img).HasColumnType("image");
            entity.Property(e => e.Mob).HasMaxLength(30);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Reference).HasMaxLength(50);
        });

        modelBuilder.Entity<AccMastSubRef>(entity =>
        {
            entity.HasKey(e => e.SubAccNo);

            entity.ToTable("AccMastSubRef");

            entity.HasIndex(e => e.AcCode, "IX_AccMastSubRef").IsUnique();

            entity.Property(e => e.SubAccNo).ValueGeneratedNever();
            entity.Property(e => e.AcCode).HasMaxLength(20);
            entity.Property(e => e.AcName).HasMaxLength(100);
            entity.Property(e => e.Cbal).HasColumnName("CBal");
            entity.Property(e => e.Ob).HasColumnName("OB");
        });

        modelBuilder.Entity<AccTrCmn>(entity =>
        {
            entity.HasKey(e => e.LinkNo);

            entity.ToTable("AccTrCmn");

            entity.HasIndex(e => new { e.Jvtype, e.Jvnum, e.PreFix }, "IX_Query").IsUnique();

            entity.Property(e => e.CmnBrId).HasMaxLength(10);
            entity.Property(e => e.CmnJobCode)
                .HasMaxLength(10)
                .HasColumnName("cmnJobCode");
            entity.Property(e => e.CrtDtTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPos).HasColumnName("IsPOS");
            entity.Property(e => e.Jvdate)
                .HasColumnType("datetime")
                .HasColumnName("JVDate");
            entity.Property(e => e.Jvnum).HasColumnName("JVNum");
            entity.Property(e => e.Jvtype)
                .HasMaxLength(3)
                .HasColumnName("JVType");
            entity.Property(e => e.JvtypeNo)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("JVTypeNo");
            entity.Property(e => e.LTrId).HasColumnName("lTrId");
            entity.Property(e => e.LstModiUsrId).HasMaxLength(10);
            entity.Property(e => e.MlinkNo).HasColumnName("MLinkNo");
            entity.Property(e => e.ModiDtTm).HasColumnType("datetime");
            entity.Property(e => e.OthInf).HasMaxLength(60);
            entity.Property(e => e.PreFix)
                .HasMaxLength(15)
                .HasDefaultValue("");
            entity.Property(e => e.SourceBr).HasMaxLength(10);
            entity.Property(e => e.TmpLinkNo).HasColumnName("tmpLinkNo");
            entity.Property(e => e.UserId).HasMaxLength(10);
            entity.Property(e => e.VrDescr).HasMaxLength(200);
        });

        modelBuilder.Entity<AccTrDet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AccTrDet");

            entity.HasIndex(e => new { e.LinkNo, e.UnqNo }, "IX_AccTrDet");

            entity.HasIndex(e => e.AccountNo, "IX_AccTrDet_AccountNo");

            entity.Property(e => e.AcTypeNo).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.AccWithRef).HasMaxLength(50);
            entity.Property(e => e.ApprvdBy).HasMaxLength(10);
            entity.Property(e => e.ApprvdTime).HasColumnType("datetime");
            entity.Property(e => e.BankCode).HasMaxLength(10);
            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.ChqDate).HasColumnType("datetime");
            entity.Property(e => e.ChqInf).HasMaxLength(150);
            entity.Property(e => e.ChqNo).HasMaxLength(10);
            entity.Property(e => e.Counter).HasMaxLength(10);
            entity.Property(e => e.CurrencyCode).HasMaxLength(5);
            entity.Property(e => e.DeptId).HasMaxLength(10);
            entity.Property(e => e.DocDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.EntryRef).HasMaxLength(250);
            entity.Property(e => e.JobCode).HasMaxLength(10);
            entity.Property(e => e.JobStr).HasMaxLength(50);
            entity.Property(e => e.Lpono).HasColumnName("LPONo");
            entity.Property(e => e.ModiDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NotCosting).HasColumnName("notCosting");
            entity.Property(e => e.Pdcacc).HasColumnName("PDCAcc");
            entity.Property(e => e.Pdcstatus)
                .HasMaxLength(1)
                .HasColumnName("PDCStatus");
            entity.Property(e => e.PdctrfrDt)
                .HasColumnType("datetime")
                .HasColumnName("PDCTrfrDt");
            entity.Property(e => e.PhyDt).HasColumnType("datetime");
            entity.Property(e => e.Pono).HasColumnName("PONo");
            entity.Property(e => e.PurchInvNo).HasMaxLength(30);
            entity.Property(e => e.RchgId).HasColumnName("rchgId");
            entity.Property(e => e.Reference).HasMaxLength(30);
            entity.Property(e => e.SmanCode)
                .HasMaxLength(10)
                .HasColumnName("SManCode");
            entity.Property(e => e.SpTaxno).HasColumnName("SpTAXNo");
            entity.Property(e => e.SpTaxper)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("SpTAXPer");
            entity.Property(e => e.Status).HasMaxLength(1);
            entity.Property(e => e.SuppInvDate).HasColumnType("datetime");
            entity.Property(e => e.TaxtpNo).HasColumnName("TAXTpNo");
            entity.Property(e => e.TermsId).HasMaxLength(15);
            entity.Property(e => e.TrInf).HasDefaultValue((byte)0);
            entity.Property(e => e.UnqNo).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<AccTrOb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AccTrOB");

            entity.HasIndex(e => new { e.AccountNo, e.Jvdate }, "IX_AccTrOB1").IsClustered();

            entity.HasIndex(e => e.UnqNo, "IX_AccTrOB_UnqNo");

            entity.Property(e => e.BankCode).HasMaxLength(10);
            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.ChqDate).HasColumnType("datetime");
            entity.Property(e => e.ChqNo).HasMaxLength(10);
            entity.Property(e => e.CurrencyCode).HasMaxLength(5);
            entity.Property(e => e.DeptId).HasMaxLength(10);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.EntryRef).HasMaxLength(250);
            entity.Property(e => e.JobCode).HasMaxLength(10);
            entity.Property(e => e.Jvdate)
                .HasColumnType("datetime")
                .HasColumnName("JVDate");
            entity.Property(e => e.LnkContNo).HasMaxLength(20);
            entity.Property(e => e.LstModiUsrId).HasMaxLength(10);
            entity.Property(e => e.Pdcacc).HasColumnName("PDCAcc");
            entity.Property(e => e.Pdcstatus)
                .HasMaxLength(1)
                .HasColumnName("PDCStatus");
            entity.Property(e => e.PdctrfrDt)
                .HasColumnType("datetime")
                .HasColumnName("PDCTrfrDt");
            entity.Property(e => e.PurchInvNo).HasMaxLength(12);
            entity.Property(e => e.Reference).HasMaxLength(30);
            entity.Property(e => e.SmanCode)
                .HasMaxLength(10)
                .HasColumnName("SManCode");
            entity.Property(e => e.SuppInvDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<AddtnlFldTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AddtnlFldTb");

            entity.HasIndex(e => new { e.TrId, e.IsDocOrInv }, "IX_AddtnlFldTb").IsUnique();

            entity.Property(e => e.Bank).HasMaxLength(10);
            entity.Property(e => e.ChqDt).HasColumnType("datetime");
            entity.Property(e => e.ChqNo).HasMaxLength(10);
            entity.Property(e => e.CustMob).HasMaxLength(50);
            entity.Property(e => e.CustName).HasMaxLength(80);
            entity.Property(e => e.Fld1).HasMaxLength(50);
            entity.Property(e => e.Fld10).HasMaxLength(50);
            entity.Property(e => e.Fld2).HasMaxLength(50);
            entity.Property(e => e.Fld3).HasMaxLength(50);
            entity.Property(e => e.Fld4).HasMaxLength(50);
            entity.Property(e => e.Fld5).HasMaxLength(50);
            entity.Property(e => e.Fld6).HasMaxLength(50);
            entity.Property(e => e.Fld7).HasMaxLength(50);
            entity.Property(e => e.Fld8).HasMaxLength(50);
            entity.Property(e => e.Fld9).HasMaxLength(50);
        });

        modelBuilder.Entity<AdvanceTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AdvanceTb");

            entity.Property(e => e.AdvDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<AlinfTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ALInfTb");

            entity.Property(e => e.AirTaltmnt).HasColumnName("AirTAltmnt");
            entity.Property(e => e.AirTamt).HasColumnName("AirTAmt");
            entity.Property(e => e.Ano).HasColumnName("ANo");
            entity.Property(e => e.BsHra).HasColumnName("BS+HRA");
            entity.Property(e => e.HistLastAirTissdDt)
                .HasColumnType("datetime")
                .HasColumnName("HistLastAirTIssdDt");
            entity.Property(e => e.HistReJoinDt).HasColumnType("datetime");
            entity.Property(e => e.Hra).HasColumnName("HRA");
            entity.Property(e => e.IsAirTgranded).HasColumnName("IsAirTGranded");
            entity.Property(e => e.LastReJoin).HasColumnType("datetime");
            entity.Property(e => e.LeavePmonth).HasColumnName("LeavePMonth");
            entity.Property(e => e.LeaveStDt).HasColumnType("datetime");
            entity.Property(e => e.LvSwithHra).HasColumnName("LvSWithHRA");
            entity.Property(e => e.ReJoin).HasColumnType("datetime");
        });

        modelBuilder.Entity<AreaTb>(entity =>
        {
            entity.HasKey(e => e.AreaCode);

            entity.ToTable("AreaTb");

            entity.Property(e => e.AreaCode).HasMaxLength(10);
            entity.Property(e => e.AreaDescr).HasMaxLength(30);
            entity.Property(e => e.LstSaleDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<BalanceQr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BalanceQr");
        });

        modelBuilder.Entity<BankTb>(entity =>
        {
            entity.HasKey(e => e.BankCode);

            entity.ToTable("BankTb");

            entity.Property(e => e.BankCode).HasMaxLength(10);
            entity.Property(e => e.BankAcc).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(35);
            entity.Property(e => e.IsCustom).HasColumnName("isCustom");
            entity.Property(e => e.RptInf).HasMaxLength(150);
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BarCustFmt>(entity =>
        {
            entity.HasKey(e => e.FmtNo);

            entity.ToTable("BarCustFmt");

            entity.HasIndex(e => e.FmtName, "IX_BarCustFmt").IsUnique();

            entity.Property(e => e.FmtNo).ValueGeneratedNever();
            entity.Property(e => e.DoHide).HasColumnName("doHide");
            entity.Property(e => e.FmtName).HasMaxLength(100);
            entity.Property(e => e.FmtPrinter)
                .HasMaxLength(200)
                .HasColumnName("fmtPrinter");
            entity.Property(e => e.IsInInch).HasDefaultValue(true);
        });

        modelBuilder.Entity<BarDirectPrtReq>(entity =>
        {
            entity.HasKey(e => e.ReqTm);

            entity.ToTable("BarDirectPrtReq");

            entity.Property(e => e.ReqTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DoDel).HasColumnName("doDel");
            entity.Property(e => e.FmtPrinter)
                .HasMaxLength(200)
                .HasColumnName("fmtPrinter");
            entity.Property(e => e.IsPrintIc).HasColumnName("IsPrintIC");
            entity.Property(e => e.MasterQr).HasColumnName("masterQr");
            entity.Property(e => e.ReqBy).HasMaxLength(10);
            entity.Property(e => e.ReqSystem).HasMaxLength(60);
            entity.Property(e => e.SystemIfRequest).HasMaxLength(60);
        });

        modelBuilder.Entity<BarFieldTb>(entity =>
        {
            entity.HasKey(e => e.Field).HasName("PK_FieldTb");

            entity.ToTable("BarFieldTb");

            entity.Property(e => e.Field).HasMaxLength(50);
            entity.Property(e => e.Format).HasMaxLength(50);
            entity.Property(e => e.ProcedureName).HasMaxLength(50);
        });

        modelBuilder.Entity<BarFmtDirect>(entity =>
        {
            entity.HasKey(e => e.FmtNo);

            entity.ToTable("BarFmtDirect");

            entity.Property(e => e.FmtNo).ValueGeneratedNever();
            entity.Property(e => e.DoHide).HasColumnName("doHide");
            entity.Property(e => e.Ean13code)
                .HasMaxLength(10)
                .HasColumnName("EAN13Code");
            entity.Property(e => e.Ean8code)
                .HasMaxLength(10)
                .HasColumnName("EAN8Code");
            entity.Property(e => e.FmtName).HasMaxLength(100);
            entity.Property(e => e.FmtPrinter)
                .HasMaxLength(200)
                .HasColumnName("fmtPrinter");
            entity.Property(e => e.IsEan13or8)
                .HasDefaultValue(true)
                .HasColumnName("IsEAN13or8");
            entity.Property(e => e.NoOfLabels).HasDefaultValue((short)1);
            entity.Property(e => e.OthCode).HasMaxLength(10);
            entity.Property(e => e.PrinterModel).HasMaxLength(50);
            entity.Property(e => e.SystemIfRequest).HasMaxLength(60);
        });

        modelBuilder.Entity<BarObject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BarObject");

            entity.HasIndex(e => e.FmtNo, "IX_BarObject");

            entity.Property(e => e.CurrCode).HasMaxLength(5);
            entity.Property(e => e.Ean13).HasColumnName("EAN13");
            entity.Property(e => e.FontName).HasMaxLength(255);
            entity.Property(e => e.HasText).HasColumnName("hasText");
            entity.Property(e => e.Img).HasColumnType("image");
            entity.Property(e => e.IsElseBtype)
                .HasDefaultValue((byte)21)
                .HasColumnName("IsElseBType");
        });

        modelBuilder.Entity<BaseItmDet>(entity =>
        {
            entity.HasKey(e => e.BaseItemId).HasName("PK_Query");

            entity.ToTable("BaseItmDet");

            entity.Property(e => e.BaseItemId).ValueGeneratedNever();
            entity.Property(e => e.BactiveCost).HasColumnName("BActiveCost");
            entity.Property(e => e.C).HasColumnName("c");
            entity.Property(e => e.Hsnno).HasColumnName("HSNNo");
            entity.Property(e => e.ItemCategory)
                .HasMaxLength(10)
                .HasDefaultValue("Stock");
            entity.Property(e => e.LpnetCost).HasColumnName("LPNetCost");
            entity.Property(e => e.LstPurchInf1).HasMaxLength(40);
            entity.Property(e => e.LstPurchInf2).HasMaxLength(40);
            entity.Property(e => e.LstPurchInf3).HasMaxLength(40);
            entity.Property(e => e.MissdQty).HasColumnName("MIssdQty");
            entity.Property(e => e.ModiDtTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MopnQty).HasColumnName("MOpnQty");
            entity.Property(e => e.MrcvdQty).HasColumnName("MRcvdQty");
            entity.Property(e => e.NsprofitPer).HasColumnName("NSProfitPer");
            entity.Property(e => e.PrdCostMthd).HasColumnName("prdCostMthd");
            entity.Property(e => e.Prvlg1).HasColumnName("Prvlg1%");
            entity.Property(e => e.Prvlg2).HasColumnName("Prvlg2%");
            entity.Property(e => e.SuppInf).HasMaxLength(60);
        });

        modelBuilder.Entity<BaseTb>(entity =>
        {
            entity.HasKey(e => e.BaseId);

            entity.ToTable("BaseTb");

            entity.Property(e => e.BaseId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Bcode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bcode");

            entity.Property(e => e.Bcode1)
                .HasMaxLength(50)
                .HasColumnName("bcode");
        });

        modelBuilder.Entity<BinTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BinTb");

            entity.Property(e => e.BinName)
                .HasMaxLength(30)
                .HasColumnName("Bin Name");
            entity.Property(e => e.BinNo).HasColumnName("Bin No");
        });

        modelBuilder.Entity<BplogTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BPLogTb");

            entity.Property(e => e.DtTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BrItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BrItem");

            entity.HasIndex(e => new { e.ItemId, e.BrId }, "IX_BrItem").IsUnique();

            entity.Property(e => e.BrId).HasMaxLength(10);
        });

        modelBuilder.Entity<BrPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BrPrice");

            entity.HasIndex(e => new { e.ItemId, e.BrId }, "IX_BrPrice").IsUnique();

            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.BrPrice1).HasColumnName("BrPrice");
        });

        modelBuilder.Entity<BranchTb>(entity =>
        {
            entity.HasKey(e => e.BranchId);

            entity.ToTable("BranchTb");

            entity.Property(e => e.BranchId).HasMaxLength(10);
            entity.Property(e => e.Baddr1)
                .HasMaxLength(200)
                .HasColumnName("BAddr1");
            entity.Property(e => e.Baddr2)
                .HasMaxLength(60)
                .HasColumnName("BAddr2");
            entity.Property(e => e.Baddr3)
                .HasMaxLength(60)
                .HasColumnName("BAddr3");
            entity.Property(e => e.BrFc)
                .HasMaxLength(5)
                .HasColumnName("BrFC");
            entity.Property(e => e.BrPayableAcc).HasColumnName("brPayableAcc");
            entity.Property(e => e.BranchDb).HasMaxLength(50);
            entity.Property(e => e.BranchName).HasMaxLength(100);
            entity.Property(e => e.BranchServer).HasMaxLength(50);
            entity.Property(e => e.Btel1)
                .HasMaxLength(50)
                .HasColumnName("BTel1");
            entity.Property(e => e.Btel2)
                .HasMaxLength(50)
                .HasColumnName("BTel2");
            entity.Property(e => e.CntrznType).HasDefaultValue((byte)0);
            entity.Property(e => e.DtLstBrUpdtd).HasColumnType("datetime");
            entity.Property(e => e.Img)
                .HasColumnType("image")
                .HasColumnName("img");
            entity.Property(e => e.ShortName).HasMaxLength(50);
        });

        modelBuilder.Entity<BrfrshStatus>(entity =>
        {
            entity.HasKey(e => e.SysName);

            entity.ToTable("BRfrshStatus");

            entity.Property(e => e.SysName).HasMaxLength(50);
            entity.Property(e => e.ExitRefreshTm).HasColumnType("datetime");
            entity.Property(e => e.RefreshTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BudjetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BudjetTb");

            entity.Property(e => e.Bapr).HasColumnName("BApr");
            entity.Property(e => e.Baug).HasColumnName("BAug");
            entity.Property(e => e.Bdec).HasColumnName("BDec");
            entity.Property(e => e.Bfeb).HasColumnName("BFeb");
            entity.Property(e => e.Bjan).HasColumnName("BJan");
            entity.Property(e => e.Bjul).HasColumnName("BJul");
            entity.Property(e => e.Bjun).HasColumnName("BJun");
            entity.Property(e => e.Bmar).HasColumnName("BMar");
            entity.Property(e => e.Bmay).HasColumnName("BMay");
            entity.Property(e => e.Bnov).HasColumnName("BNov");
            entity.Property(e => e.Boct).HasColumnName("BOct");
            entity.Property(e => e.Bsep).HasColumnName("BSep");
            entity.Property(e => e.Byear).HasColumnName("BYear");
        });

        modelBuilder.Entity<ChqBookTb>(entity =>
        {
            entity.HasKey(e => e.ChqBookId);

            entity.ToTable("ChqBookTb");

            entity.Property(e => e.ChqBookId).ValueGeneratedNever();
            entity.Property(e => e.BankCode).HasMaxLength(50);
            entity.Property(e => e.ChqBookDate).HasColumnType("datetime");
            entity.Property(e => e.ChqBookLotId).HasMaxLength(20);
            entity.Property(e => e.CrtdBy).HasMaxLength(10);
            entity.Property(e => e.CrtdDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModiBy).HasMaxLength(10);
            entity.Property(e => e.ModiDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ChqLeaf>(entity =>
        {
            entity.HasKey(e => e.ChqLeaveId);

            entity.Property(e => e.ChqLeaveId).ValueGeneratedNever();
            entity.Property(e => e.ChqAmount).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.ChqDate).HasColumnType("datetime");
            entity.Property(e => e.ClearedDt).HasColumnType("datetime");
            entity.Property(e => e.CrtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.ModiBy).HasMaxLength(10);
            entity.Property(e => e.ModiTm).HasColumnType("datetime");
            entity.Property(e => e.PayeeName).HasMaxLength(200);
            entity.Property(e => e.UserId).HasMaxLength(50);
        });

        modelBuilder.Entity<ChqPrintTb>(entity =>
        {
            entity.ToTable("ChqPrintTb");

            entity.Property(e => e.ChqDate).HasColumnType("datetime");
            entity.Property(e => e.ChqNo)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.Descr).HasMaxLength(100);
            entity.Property(e => e.Payee).HasMaxLength(150);
        });

        modelBuilder.Entity<CmnVrTypeTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CmnVrTypeTb");

            entity.HasIndex(e => e.VrType, "IX_CmnVrTypeTb").IsUnique();

            entity.Property(e => e.AccTrType).HasMaxLength(15);
            entity.Property(e => e.STrType)
                .HasMaxLength(15)
                .HasColumnName("sTrType");
            entity.Property(e => e.TypeOrd).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.VrType).HasMaxLength(3);
            entity.Property(e => e.VrTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<CntrInvProd>(entity =>
        {
            entity.HasKey(e => e.BaseId);

            entity.ToTable("CntrInvProd");

            entity.Property(e => e.BaseId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ColPopup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ColPopup");

            entity.Property(e => e.ColFld).HasMaxLength(50);
            entity.Property(e => e.SelectItem).HasMaxLength(75);
        });

        modelBuilder.Entity<ColProperty>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ColProperty");

            entity.Property(e => e.ColCaption).HasMaxLength(50);
            entity.Property(e => e.ColFld).HasMaxLength(50);
            entity.Property(e => e.FldAlign).HasDefaultValue((short)1);
            entity.Property(e => e.FldSize).HasDefaultValue((short)50);
            entity.Property(e => e.ModuleId)
                .HasDefaultValue((short)0)
                .HasColumnName("ModuleID");
        });

        modelBuilder.Entity<ComponentTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ComponentTb");

            entity.HasIndex(e => new { e.MitemId, e.CompItemId }, "IX_CompnentTb").IsUnique();

            entity.Property(e => e.MitemId).HasColumnName("MItemId");
        });

        modelBuilder.Entity<ContrRcptTb>(entity =>
        {
            entity.HasKey(e => new { e.ContSeqNo, e.SlNo });

            entity.ToTable("ContrRcptTb");

            entity.Property(e => e.DelDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descr).HasMaxLength(50);
            entity.Property(e => e.RcptAmt).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.RcptDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ContractDetTb>(entity =>
        {
            entity.HasKey(e => e.SeqCntNo);

            entity.ToTable("ContractDetTb");

            entity.Property(e => e.CntrAmt).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.CntrFrom).HasColumnType("datetime");
            entity.Property(e => e.CntrTo).HasColumnType("datetime");
            entity.Property(e => e.CrtdBy).HasMaxLength(10);
            entity.Property(e => e.CrtdTm).HasColumnType("datetime");
            entity.Property(e => e.DiscAmt).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Status).HasDefaultValue((byte)0);
        });

        modelBuilder.Entity<ContractTb>(entity =>
        {
            entity.HasKey(e => e.ContractNo);

            entity.ToTable("ContractTb");

            entity.Property(e => e.ContractNo).ValueGeneratedNever();
            entity.Property(e => e.CrtdDt).HasColumnType("datetime");
            entity.Property(e => e.DocDt).HasColumnType("datetime");
            entity.Property(e => e.ModiBy).HasMaxLength(10);
            entity.Property(e => e.ModiTm).HasColumnType("datetime");
            entity.Property(e => e.Ref).HasMaxLength(30);
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<CounterStatus>(entity =>
        {
            entity.HasKey(e => e.CounterNo);

            entity.ToTable("CounterStatus");

            entity.Property(e => e.CounterNo).ValueGeneratedNever();
            entity.Property(e => e.OnlineDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CounterTb>(entity =>
        {
            entity.HasKey(e => e.CounterNo);

            entity.ToTable("CounterTb");

            entity.HasIndex(e => e.CounterCode, "IX_CounterTb").IsUnique();

            entity.HasIndex(e => e.CounterCode, "IX_CounterTb_1").IsUnique();

            entity.Property(e => e.CounterNo).ValueGeneratedNever();
            entity.Property(e => e.CareaCode)
                .HasMaxLength(10)
                .HasColumnName("CAreaCode");
            entity.Property(e => e.CbranchId)
                .HasMaxLength(4)
                .HasColumnName("CBranchId");
            entity.Property(e => e.ClocationId)
                .HasMaxLength(4)
                .HasColumnName("CLocationId");
            entity.Property(e => e.CounterCode).HasMaxLength(10);
            entity.Property(e => e.CounterFlName).HasMaxLength(20);
        });

        modelBuilder.Entity<CountryTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CountryTb");

            entity.HasIndex(e => e.CountryCode, "PK_CountryTb")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CountryName).HasMaxLength(30);
        });

        modelBuilder.Entity<CshHdocTb>(entity =>
        {
            entity.HasKey(e => e.ChdocId);

            entity.ToTable("CshHDocTb");

            entity.Property(e => e.ChdocId)
                .ValueGeneratedNever()
                .HasColumnName("CHDocId");
            entity.Property(e => e.ChdocName)
                .HasMaxLength(50)
                .HasColumnName("CHDocName");
        });

        modelBuilder.Entity<CshHopn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CshHOpn");

            entity.HasIndex(e => new { e.UserId, e.DocId }, "IX_CshHOpn").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<CstmAccLst>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CstmAccLst");

            entity.HasIndex(e => new { e.CgrpId, e.AccNo }, "IX_CstmAccLst").IsUnique();

            entity.Property(e => e.CgrpId).HasColumnName("CGrpId");
        });

        modelBuilder.Entity<CstmEnqCmn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CstmEnqCmn");

            entity.HasIndex(e => new { e.EnqId, e.UserId }, "IX_CstmEnqCmn").IsUnique();

            entity.Property(e => e.Pcname)
                .HasMaxLength(50)
                .HasColumnName("PCName");
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<CstmEnquiry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CstmEnquiry");

            entity.Property(e => e.Align).HasDefaultValue((byte)1);
            entity.Property(e => e.Cwidth).HasColumnName("CWidth");
            entity.Property(e => e.FldName).HasMaxLength(25);
            entity.Property(e => e.Fmt)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<CstmdAccGrp>(entity =>
        {
            entity.HasKey(e => e.CgrpId);

            entity.ToTable("CstmdAccGrp");

            entity.HasIndex(e => e.CgrpId, "IX_CstmdAccGrp").IsUnique();

            entity.HasIndex(e => e.CgrpName, "IX_CstmdAccGrp_1").IsUnique();

            entity.Property(e => e.CgrpId)
                .ValueGeneratedNever()
                .HasColumnName("CGrpId");
            entity.Property(e => e.CgrpCode)
                .HasMaxLength(10)
                .HasColumnName("CGrpCode");
            entity.Property(e => e.CgrpName)
                .HasMaxLength(60)
                .HasColumnName("CGrpName");
        });

        modelBuilder.Entity<CuponTb>(entity =>
        {
            entity.HasKey(e => e.CuponId);

            entity.ToTable("CuponTb");

            entity.Property(e => e.CuponId).ValueGeneratedNever();
            entity.Property(e => e.CuponName).HasMaxLength(100);
            entity.Property(e => e.MaxAppAmt).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Mult).HasDefaultValue(1.0);
        });

        modelBuilder.Entity<CurrencyTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CurrencyTb");

            entity.Property(e => e.CurrencyCode).HasMaxLength(5);
            entity.Property(e => e.DecimalPlaces).HasColumnName("Decimal Places");
            entity.Property(e => e.Description).HasMaxLength(30);
            entity.Property(e => e.FractionCode)
                .HasMaxLength(5)
                .HasColumnName("Fraction Code");
        });

        modelBuilder.Entity<CustGrpAssgnTb>(entity =>
        {
            entity.HasKey(e => e.CustNo).HasName("PK_CustAssgnTb");

            entity.ToTable("CustGrpAssgnTb");

            entity.Property(e => e.CustNo).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustPrdAssgnTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CustPrdAssgnTb");

            entity.HasIndex(e => new { e.CprodNo, e.ItemNo }, "IX_CustPrdAssgnTb").IsUnique();

            entity.Property(e => e.CprodNo).HasColumnName("CProdNo");
        });

        modelBuilder.Entity<CustProdCtb>(entity =>
        {
            entity.HasKey(e => e.PrdGrpNo);

            entity.ToTable("CustProdCTb");

            entity.Property(e => e.PrdGrpNo).ValueGeneratedNever();
            entity.Property(e => e.Descr).HasMaxLength(100);
            entity.Property(e => e.GrpCode).HasMaxLength(30);
        });

        modelBuilder.Entity<CustProdTb>(entity =>
        {
            entity.HasKey(e => e.CustPno);

            entity.ToTable("CustProdTb");

            entity.HasIndex(e => new { e.PrdGrpNo, e.CustPid }, "IX_CustProdTb_1").IsUnique();

            entity.Property(e => e.CustPno)
                .ValueGeneratedNever()
                .HasColumnName("CustPNo");
            entity.Property(e => e.CrtdBy).HasMaxLength(50);
            entity.Property(e => e.CrtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustPbc)
                .HasMaxLength(30)
                .HasColumnName("CustPBC");
            entity.Property(e => e.CustPid)
                .HasMaxLength(30)
                .HasColumnName("CustPId");
            entity.Property(e => e.Descr).HasMaxLength(200);
            entity.Property(e => e.ModiBy).HasMaxLength(50);
            entity.Property(e => e.ModiTm).HasColumnType("datetime");
            entity.Property(e => e.Para1).HasMaxLength(50);
            entity.Property(e => e.Para2).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(12, 3)");
            entity.Property(e => e.Punit)
                .HasMaxLength(10)
                .HasColumnName("PUnit");
        });

        modelBuilder.Entity<CustShortCutDet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CustShortCutDet");

            entity.Property(e => e.ItemName).HasMaxLength(80);
            entity.Property(e => e.SysIconKey).HasMaxLength(20);
        });

        modelBuilder.Entity<CustShortcutCmn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CustShortcutCmn");

            entity.Property(e => e.SystemName).HasMaxLength(30);
        });

        modelBuilder.Entity<CustmVr>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("CustmVr");

            entity.Property(e => e.TypeId).HasMaxLength(3);
            entity.Property(e => e.PreFix).HasMaxLength(5);
            entity.Property(e => e.TypeName)
                .HasMaxLength(40)
                .HasColumnName("Type Name");
        });

        modelBuilder.Entity<DayLeaveRegTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DayLeaveRegTb");

            entity.Property(e => e.DayDt).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(50);
        });

        modelBuilder.Entity<DayPettyTr>(entity =>
        {
            entity.HasKey(e => e.TrId).HasName("PK_DayCounterTr");

            entity.ToTable("DayPettyTr");

            entity.Property(e => e.TrId).ValueGeneratedNever();
            entity.Property(e => e.ChdocId)
                .HasDefaultValue(1)
                .HasColumnName("CHDocId");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.Dt).HasColumnType("datetime");
            entity.Property(e => e.Party).HasMaxLength(60);
            entity.Property(e => e.Remark).HasMaxLength(100);
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<DefPayrollAcGrp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DefPayrollAcGrp");
        });

        modelBuilder.Entity<DepartmentTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DepartmentTb");

            entity.HasIndex(e => e.DeptId, "PK_DepartmentTb")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.DeptDescr).HasMaxLength(30);
            entity.Property(e => e.DeptId).HasMaxLength(10);
        });

        modelBuilder.Entity<DesignationTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DesignationTb");

            entity.Property(e => e.DesgId)
                .HasMaxLength(10)
                .HasColumnName("DesgID");
            entity.Property(e => e.DesignationName).HasMaxLength(50);
        });

        modelBuilder.Entity<DiscCardTb>(entity =>
        {
            entity.HasKey(e => e.CardDt);

            entity.ToTable("DiscCardTb");

            entity.HasIndex(e => e.SlNo, "IX_DiscCardTb").IsUnique();

            entity.HasIndex(e => e.AccNo, "IX_DiscCardTb_1").IsUnique();

            entity.Property(e => e.CardDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Authority).HasMaxLength(50);
            entity.Property(e => e.CardName).HasMaxLength(60);
            entity.Property(e => e.CompName).HasMaxLength(100);
            entity.Property(e => e.ContactNo).HasMaxLength(30);
            entity.Property(e => e.DispMob).HasMaxLength(30);
            entity.Property(e => e.Eid)
                .HasMaxLength(30)
                .HasColumnName("EID");
            entity.Property(e => e.HouseNo).HasMaxLength(30);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.PinDt).HasColumnType("datetime");
            entity.Property(e => e.PlotNo).HasMaxLength(30);
            entity.Property(e => e.Profession).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.TradeLicence).HasMaxLength(20);
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<DocAdnlFldTb>(entity =>
        {
            entity.HasKey(e => e.TrId);

            entity.ToTable("DocAdnlFldTb");

            entity.Property(e => e.TrId).ValueGeneratedNever();
            entity.Property(e => e.Fld1).HasMaxLength(50);
            entity.Property(e => e.Fld2).HasMaxLength(50);
            entity.Property(e => e.Fld3).HasMaxLength(50);
            entity.Property(e => e.Fld4).HasMaxLength(50);
            entity.Property(e => e.Fld5).HasMaxLength(50);
            entity.Property(e => e.Fld6).HasMaxLength(50);
            entity.Property(e => e.Fld7).HasMaxLength(50);
            entity.Property(e => e.Fld8).HasMaxLength(50);
        });

        modelBuilder.Entity<DocAssgnTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DocAssgnTb");

            entity.Property(e => e.TrMpqty).HasColumnName("TrMPQty");
            entity.Property(e => e.TrQtyFoc).HasColumnName("TrQtyFOC");
        });

        modelBuilder.Entity<DocCmnTb>(entity =>
        {
            entity.HasKey(e => e.DocId);

            entity.ToTable("DocCmnTb");

            entity.HasIndex(e => new { e.DocType, e.Dno }, "IX_DocCmnTb").IsUnique();

            entity.HasIndex(e => e.DocId, "IX_DocCmnTb_1");

            entity.Property(e => e.DocId).ValueGeneratedNever();
            entity.Property(e => e.ApprvdBy).HasMaxLength(10);
            entity.Property(e => e.ApprvdTime).HasColumnType("datetime");
            entity.Property(e => e.Attn).HasMaxLength(150);
            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.CancelBy).HasMaxLength(10);
            entity.Property(e => e.CancelTime).HasColumnType("datetime");
            entity.Property(e => e.Comment).HasMaxLength(250);
            entity.Property(e => e.CrtDt).HasColumnType("datetime");
            entity.Property(e => e.Cscode).HasColumnName("CSCode");
            entity.Property(e => e.Ddate)
                .HasColumnType("datetime")
                .HasColumnName("DDate");
            entity.Property(e => e.DelvDt).HasColumnType("datetime");
            entity.Property(e => e.DeptId).HasMaxLength(10);
            entity.Property(e => e.Dno).HasColumnName("DNo");
            entity.Property(e => e.DocDefLoc).HasMaxLength(10);
            entity.Property(e => e.DocType).HasMaxLength(3);
            entity.Property(e => e.JobCode)
                .HasMaxLength(10)
                .HasColumnName("Job Code");
            entity.Property(e => e.LstModiUsrId).HasMaxLength(10);
            entity.Property(e => e.ModiDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NoVatinv).HasColumnName("NoVATInv");
            entity.Property(e => e.NoVatreasonId).HasColumnName("NoVATReasonId");
            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.Otp).HasColumnName("OTP");
            entity.Property(e => e.Pmail)
                .HasMaxLength(50)
                .HasColumnName("PMail");
            entity.Property(e => e.Reference).HasMaxLength(20);
            entity.Property(e => e.SlManId).HasMaxLength(10);
            entity.Property(e => e.Subject).HasMaxLength(150);
            entity.Property(e => e.TermsId).HasMaxLength(15);
            entity.Property(e => e.TmpDocId).HasColumnName("tmpDocId");
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<DocImgTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DocImgTb");

            entity.Property(e => e.DocImg).HasMaxLength(50);
            entity.Property(e => e.DocName).HasMaxLength(50);
            entity.Property(e => e.ExpDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<DocInfTb>(entity =>
        {
            entity.HasKey(e => e.DocCode);

            entity.ToTable("DocInfTb");

            entity.Property(e => e.DocCode).HasMaxLength(20);
            entity.Property(e => e.DocDate).HasColumnType("datetime");
            entity.Property(e => e.DocName).HasMaxLength(50);
            entity.Property(e => e.ExpDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DocTranTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DocTranTb");

            entity.HasIndex(e => e.BaseId, "IX_DocTranTb_BaseId");

            entity.HasIndex(e => e.DocId, "IX_DocTranTb_DocId");

            entity.Property(e => e.Anum).HasColumnName("ANum");
            entity.Property(e => e.CostPunit).HasColumnName("CostPUnit");
            entity.Property(e => e.ExpDt).HasColumnType("datetime");
            entity.Property(e => e.Focdescr)
                .HasMaxLength(50)
                .HasColumnName("FOCDescr");
            entity.Property(e => e.Focmapping)
                .HasMaxLength(50)
                .HasColumnName("FOCMapping");
            entity.Property(e => e.IsLnDisc)
                .HasDefaultValue(true)
                .HasColumnName("IsLnDisc%");
            entity.Property(e => e.LmsgNo).HasColumnName("LMsgNo");
            entity.Property(e => e.LnDisc1).HasColumnName("LnDisc%");
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.MtrPqty).HasColumnName("MTrPQty");
            entity.Property(e => e.Pack).HasMaxLength(50);
            entity.Property(e => e.Pfraction)
                .HasDefaultValue(1f)
                .HasColumnName("PFraction");
            entity.Property(e => e.ProssdQtyFoc).HasColumnName("ProssdQtyFOC");
            entity.Property(e => e.QtyFoc).HasColumnName("QtyFOC");
            entity.Property(e => e.TaxPer).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TrDetail).HasMaxLength(250);
            entity.Property(e => e.Unit).HasMaxLength(10);
            entity.Property(e => e.UnitFraCount).HasDefaultValue((byte)2);
        });

        modelBuilder.Entity<DocUsrLstTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DocUsrLstTb");

            entity.Property(e => e.DocCode).HasMaxLength(20);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocCode);

            entity.ToTable("Document");

            entity.Property(e => e.DocCode).HasMaxLength(50);
            entity.Property(e => e.Building).HasMaxLength(10);
            entity.Property(e => e.DocName).HasMaxLength(60);
        });

        modelBuilder.Entity<DsubClassTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DSubClassTb");

            entity.Property(e => e.Pfraction).HasColumnName("PFraction");
            entity.Property(e => e.SubCls).HasMaxLength(10);
            entity.Property(e => e.TrType).HasMaxLength(3);
        });

        modelBuilder.Entity<EmpDet>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("EmpDet");

            entity.HasIndex(e => e.EmpNo, "IX_EmpDet").IsUnique();

            entity.Property(e => e.EmpId).HasMaxLength(10);
            entity.Property(e => e.Addr1).HasMaxLength(40);
            entity.Property(e => e.Addr2).HasMaxLength(40);
            entity.Property(e => e.Addr3).HasMaxLength(40);
            entity.Property(e => e.AirTaltmnt).HasColumnName("AirTAltmnt");
            entity.Property(e => e.AltdMleave).HasColumnName("AltdMLeave");
            entity.Property(e => e.BankAccountNo).HasMaxLength(30);
            entity.Property(e => e.BankCode).HasMaxLength(10);
            entity.Property(e => e.BranchId).HasMaxLength(10);
            entity.Property(e => e.CardExpiry).HasColumnType("datetime");
            entity.Property(e => e.Company).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(5);
            entity.Property(e => e.DeptId).HasMaxLength(10);
            entity.Property(e => e.DesgnId)
                .HasMaxLength(10)
                .HasColumnName("DesgnID");
            entity.Property(e => e.Designation).HasMaxLength(40);
            entity.Property(e => e.DrvLexpDt)
                .HasColumnType("datetime")
                .HasColumnName("DrvLExpDt");
            entity.Property(e => e.DrvLicenNo).HasMaxLength(20);
            entity.Property(e => e.DrvLissdDt)
                .HasColumnType("datetime")
                .HasColumnName("DrvLIssdDt");
            entity.Property(e => e.DtOfBirth).HasColumnType("datetime");
            entity.Property(e => e.EidDtExpd)
                .HasColumnType("datetime")
                .HasColumnName("EIdDtExpd");
            entity.Property(e => e.EidDtIssd)
                .HasColumnType("datetime")
                .HasColumnName("EIdDtIssd");
            entity.Property(e => e.EmiratesIdNo).HasMaxLength(30);
            entity.Property(e => e.EmpName).HasMaxLength(50);
            entity.Property(e => e.EmpNameArb).HasMaxLength(100);
            entity.Property(e => e.EndedDt).HasColumnType("datetime");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .HasColumnName("Father Name");
            entity.Property(e => e.HcdtExpd)
                .HasColumnType("datetime")
                .HasColumnName("HCDtExpd");
            entity.Property(e => e.HcdtIssd)
                .HasColumnType("datetime")
                .HasColumnName("HCDtIssd");
            entity.Property(e => e.Hcinform)
                .HasMaxLength(30)
                .HasColumnName("HCInform");
            entity.Property(e => e.Hcno)
                .HasMaxLength(20)
                .HasColumnName("HCNo");
            entity.Property(e => e.HistLastAirTissdDt)
                .HasColumnType("datetime")
                .HasColumnName("HistLastAirTIssdDt");
            entity.Property(e => e.HistReJoinDt).HasColumnType("datetime");
            entity.Property(e => e.Hra).HasColumnName("HRA");
            entity.Property(e => e.JoinDt).HasColumnType("datetime");
            entity.Property(e => e.LabCardNo).HasMaxLength(20);
            entity.Property(e => e.LabDtExpd).HasColumnType("datetime");
            entity.Property(e => e.LabDtIssd).HasColumnType("datetime");
            entity.Property(e => e.LastAirTissdDt)
                .HasColumnType("datetime")
                .HasColumnName("LastAirTIssdDt");
            entity.Property(e => e.LeaveInf)
                .HasMaxLength(50)
                .HasColumnName("Leave Inf");
            entity.Property(e => e.LeavePmonth).HasColumnName("LeavePMonth");
            entity.Property(e => e.LsaddAllw1).HasColumnName("LSAddAllw1");
            entity.Property(e => e.LsaddAllw2).HasColumnName("LSAddAllw2");
            entity.Property(e => e.LsaddAllw3).HasColumnName("LSAddAllw3");
            entity.Property(e => e.LsaddAllw4).HasColumnName("LSAddAllw4");
            entity.Property(e => e.LsaddAllw5).HasColumnName("LSAddAllw5");
            entity.Property(e => e.LsaddHra).HasColumnName("LSAddHRA");
            entity.Property(e => e.LsaddTpt).HasColumnName("LSAddTpt");
            entity.Property(e => e.LvApplDt).HasColumnType("datetime");
            entity.Property(e => e.NWHrs).HasColumnName("N W Hrs");
            entity.Property(e => e.Nationality).HasMaxLength(20);
            entity.Property(e => e.OtRate).HasColumnName("OT Rate");
            entity.Property(e => e.OthId)
                .HasMaxLength(20)
                .HasColumnName("OthID");
            entity.Property(e => e.OthRate).HasColumnName("OTH Rate");
            entity.Property(e => e.Otwage).HasColumnName("OTWage");
            entity.Property(e => e.OtwageCmthd)
                .HasDefaultValue((byte)1)
                .HasColumnName("OTWageCMthd");
            entity.Property(e => e.PassportNo).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Photo).HasMaxLength(30);
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(30)
                .HasColumnName("Place of Birth");
            entity.Property(e => e.ProfId)
                .HasMaxLength(50)
                .HasColumnName("ProfID");
            entity.Property(e => e.PssDtExpd).HasColumnType("datetime");
            entity.Property(e => e.PssDtIssd).HasColumnType("datetime");
            entity.Property(e => e.PssPlaceIssd).HasMaxLength(30);
            entity.Property(e => e.ReJoinDt).HasColumnType("datetime");
            entity.Property(e => e.Remark).HasMaxLength(200);
            entity.Property(e => e.SalStatus).HasDefaultValue((byte)3);
            entity.Property(e => e.SiteAlloc).HasMaxLength(10);
            entity.Property(e => e.Sponsor).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TtlLoanOs).HasColumnName("TtlLoanOS");
            entity.Property(e => e.TtlSecuOs).HasColumnName("TtlSecuOS");
            entity.Property(e => e.VehPlateNo).HasMaxLength(25);
            entity.Property(e => e.VehRegCardNo).HasMaxLength(25);
            entity.Property(e => e.Vehicle).HasMaxLength(25);
            entity.Property(e => e.VisaNo).HasMaxLength(20);
            entity.Property(e => e.VsDesignation).HasMaxLength(40);
            entity.Property(e => e.VsDtExpd).HasColumnType("datetime");
            entity.Property(e => e.VsDtIssd).HasColumnType("datetime");
            entity.Property(e => e.VsRnew)
                .HasColumnType("datetime")
                .HasColumnName("VsRNew");
            entity.Property(e => e.WageCmthd)
                .HasDefaultValue((byte)1)
                .HasColumnName("WageCMthd");
            entity.Property(e => e.WageEmode)
                .HasDefaultValue((byte)0)
                .HasColumnName("WageEMode");
            entity.Property(e => e.WageHr).HasColumnName("Wage/Hr");
            entity.Property(e => e.WcfullAllw1).HasColumnName("WCFullAllw1");
            entity.Property(e => e.WcfullAllw2).HasColumnName("WCFullAllw2");
            entity.Property(e => e.WcfullAllw3).HasColumnName("WCFullAllw3");
            entity.Property(e => e.WcfullAllw4).HasColumnName("WCFullAllw4");
            entity.Property(e => e.WcfullAllw5).HasColumnName("WCFullAllw5");
            entity.Property(e => e.WcfullHra).HasColumnName("WCFullHRA");
            entity.Property(e => e.WcfullTpt).HasColumnName("WCFullTpt");
        });

        modelBuilder.Entity<EmpFldCapTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmpFldCapTb");

            entity.Property(e => e.AllowanceCap1).HasMaxLength(20);
            entity.Property(e => e.AllowanceCap2).HasMaxLength(20);
            entity.Property(e => e.AllowanceCap3).HasMaxLength(20);
            entity.Property(e => e.AllowanceCap4).HasMaxLength(20);
            entity.Property(e => e.AllowanceCap5).HasMaxLength(20);
            entity.Property(e => e.PayDeduCap1).HasMaxLength(20);
            entity.Property(e => e.PayDeduCap2).HasMaxLength(20);
            entity.Property(e => e.PayDeduCap3).HasMaxLength(20);
        });

        modelBuilder.Entity<EmpItemsTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmpItemsTb");

            entity.Property(e => e.ItemName).HasMaxLength(100);
        });

        modelBuilder.Entity<EmpNotesTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EmpNotesTb");

            entity.Property(e => e.Notes).HasMaxLength(100);
        });

        modelBuilder.Entity<ExpAdjustTb>(entity =>
        {
            entity.HasKey(e => e.AdjMonth);

            entity.ToTable("ExpAdjustTb");

            entity.Property(e => e.AdjMonth).HasColumnType("datetime");
        });

        modelBuilder.Entity<ExpFlUnq>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ExpFlUnq");

            entity.HasIndex(e => new { e.BranchId, e.ExpFlDt }, "IX_ExpFl").IsUnique();

            entity.Property(e => e.BranchId).HasMaxLength(10);
            entity.Property(e => e.ExpFlDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<FixedVr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FixedVrs");

            entity.Property(e => e.AccTrType)
                .HasMaxLength(15)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Jvtype)
                .HasMaxLength(3)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("JVType");
            entity.Property(e => e.TypeOrd).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.VrName)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<FldCaptionTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FldCaptionTb");

            entity.HasIndex(e => new { e.CapId, e.IsIn }, "IX_FldCaptionTb").IsUnique();

            entity.Property(e => e.CapId)
                .HasMaxLength(25)
                .HasColumnName("CapID");
            entity.Property(e => e.CapName).HasMaxLength(25);
        });

        modelBuilder.Entity<ForSttntWhere>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("forSttntWhere");

            entity.Property(e => e.AccountId)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("Account ID");
            entity.Property(e => e.AccountName)
                .HasMaxLength(60)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("Account Name");
            entity.Property(e => e.AreaCode)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.BranchId)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Category)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.DeptId)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("Group Name");
            entity.Property(e => e.Heading)
                .HasMaxLength(60)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.MaccId).HasColumnName("MAccId");
            entity.Property(e => e.Nature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.S1accId).HasColumnName("S1AccId");
            entity.Property(e => e.SlsmanId)
                .HasMaxLength(10)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<GlAcc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GlAcc");

            entity.Property(e => e.Cogs).HasColumnName("COGS");
            entity.Property(e => e.Glbank).HasColumnName("GLBank");
            entity.Property(e => e.Glcash).HasColumnName("GLCash");
            entity.Property(e => e.Glwsale).HasColumnName("GLWSale");
            entity.Property(e => e.Pdcissued).HasColumnName("PDCIssued");
            entity.Property(e => e.Pdcrcvd).HasColumnName("PDCRcvd");
            entity.Property(e => e.SrtnAcc).HasColumnName("SRtnAcc");
        });

        modelBuilder.Entity<GratProvTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GratProvTb");

            entity.Property(e => e.DtMonth)
                .HasColumnType("datetime")
                .HasColumnName("dtMonth");
        });

        modelBuilder.Entity<GratuityTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GratuityTb");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrpItmTb>(entity =>
        {
            entity.HasKey(e => e.UnqGrpId);

            entity.ToTable("GrpItmTb");

            entity.HasIndex(e => new { e.GrpItmCode, e.Lcode }, "IX_GrpItmTb").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.GrpItmCode).HasMaxLength(15);
            entity.Property(e => e.Lcode).HasColumnName("LCode");
            entity.Property(e => e.ParentId).HasDefaultValue(0);
            entity.Property(e => e.Pid)
                .HasMaxLength(15)
                .HasColumnName("PId");
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<HeadFoot>(entity =>
        {
            entity.ToTable("Head/Foot");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.HdFt).HasColumnName("Hd/Ft");
        });

        modelBuilder.Entity<Hsntb>(entity =>
        {
            entity.HasKey(e => e.Hsnno);

            entity.ToTable("HSNTb");

            entity.Property(e => e.Hsnno).HasColumnName("HSNNo");
            entity.Property(e => e.Hsncode)
                .HasMaxLength(30)
                .HasColumnName("HSNCode");
            entity.Property(e => e.Hsndescr)
                .HasMaxLength(150)
                .HasColumnName("HSNDescr");
            entity.Property(e => e.TaxgrpNo).HasColumnName("TAXGrpNo");
        });

        modelBuilder.Entity<InvItm>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("InvItm");

            entity.HasIndex(e => e.ItemCode, "IX_InvItm").IsUnique();

            entity.HasIndex(e => e.Description, "IX_InvItm_BarCode");

            entity.HasIndex(e => e.Model, "IX_InvItm_Descr");

            entity.Property(e => e.AqtyPrint).HasColumnName("AQtyPrint");
            entity.Property(e => e.ArbDescription).HasMaxLength(100);
            entity.Property(e => e.BarCode).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(10);
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelId).HasDefaultValue(false);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Dim1).HasDefaultValue(1f);
            entity.Property(e => e.Dim1Caption).HasMaxLength(10);
            entity.Property(e => e.Dim2).HasDefaultValue(1f);
            entity.Property(e => e.Dim2Caption).HasMaxLength(10);
            entity.Property(e => e.Dim3).HasDefaultValue(1f);
            entity.Property(e => e.Dim3Caption).HasMaxLength(10);
            entity.Property(e => e.ExpDays).HasDefaultValue((short)15);
            entity.Property(e => e.IsPcs).HasColumnName("IsPCS");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(30)
                .HasColumnName("Item Code");
            entity.Property(e => e.ItmBrId).HasMaxLength(10);
            entity.Property(e => e.Model).HasMaxLength(60);
            entity.Property(e => e.ModiDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Mrp).HasColumnName("MRP");
            entity.Property(e => e.OfferDescr).HasMaxLength(50);
            entity.Property(e => e.Pmult)
                .HasDefaultValue(1f)
                .HasColumnName("PMult");
            entity.Property(e => e.Posdescription)
                .HasMaxLength(50)
                .HasColumnName("POSDescription");
            entity.Property(e => e.SdiscOn).HasColumnName("SDiscOn");
            entity.Property(e => e.Size).HasMaxLength(30);
            entity.Property(e => e.Tmp)
                .HasDefaultValue((short)0)
                .HasColumnName("tmp");
            entity.Property(e => e.Unit).HasMaxLength(10);
            entity.Property(e => e.UnitPriceWs).HasColumnName("UnitPriceWS");
            entity.Property(e => e.Vdown)
                .HasDefaultValue(1)
                .HasColumnName("VDown");
            entity.Property(e => e.Vup)
                .HasDefaultValue(1)
                .HasColumnName("VUp");
            entity.Property(e => e.Weight).HasMaxLength(50);
            entity.Property(e => e.WgCodeLength).HasDefaultValue((byte)7);
        });

        modelBuilder.Entity<InvNo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ApNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("AP No");
            entity.Property(e => e.AsmbNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ASMB No");
            entity.Property(e => e.AtrNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ATR No");
            entity.Property(e => e.AvNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("AV No");
            entity.Property(e => e.BkgRv)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("BKG RV");
            entity.Property(e => e.BtrNo)
                .HasMaxLength(23)
                .HasDefaultValue("     000001")
                .HasColumnName("BTR No");
            entity.Property(e => e.CbNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("CB No");
            entity.Property(e => e.CnNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("CN No");
            entity.Property(e => e.ContRv)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("CONT RV");
            entity.Property(e => e.CrNo)
                .HasMaxLength(23)
                .HasDefaultValue("     000001")
                .HasColumnName("CR No");
            entity.Property(e => e.CriNo)
                .HasMaxLength(23)
                .HasDefaultValue("     1")
                .HasColumnName("CRI No");
            entity.Property(e => e.DbNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("DB No");
            entity.Property(e => e.DnNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("DN No");
            entity.Property(e => e.DocNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("DOC No");
            entity.Property(e => e.DosNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("DOS No");
            entity.Property(e => e.GinNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("GIN No");
            entity.Property(e => e.GrcNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("GRC No");
            entity.Property(e => e.GrnNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("GRN No");
            entity.Property(e => e.GrsNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("GRS No");
            entity.Property(e => e.IpNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("IP No");
            entity.Property(e => e.IsNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("IS No");
            entity.Property(e => e.JvNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("JV No");
            entity.Property(e => e.LtrNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("LTR No");
            entity.Property(e => e.OrdNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ORD No");
            entity.Property(e => e.PhiNo)
                .HasMaxLength(23)
                .HasDefaultValue("     000001")
                .HasColumnName("PHI No");
            entity.Property(e => e.PhoNo)
                .HasMaxLength(23)
                .HasDefaultValue("     000001")
                .HasColumnName("PHO No");
            entity.Property(e => e.PhsNo)
                .HasMaxLength(23)
                .HasDefaultValue("     1")
                .HasColumnName("PHS No");
            entity.Property(e => e.PhyNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PHY No");
            entity.Property(e => e.PiNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PI No");
            entity.Property(e => e.PoNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PO No");
            entity.Property(e => e.PrNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PR No");
            entity.Property(e => e.PrdctnNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.PsrvNo)
                .HasMaxLength(23)
                .HasDefaultValue("     1")
                .HasColumnName("PSRV No");
            entity.Property(e => e.PvNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("PV No");
            entity.Property(e => e.QtiNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("QTI No");
            entity.Property(e => e.QtrNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("QTR No");
            entity.Property(e => e.RvNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("RV No");
            entity.Property(e => e.SiNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("SI No");
            entity.Property(e => e.SoNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("SO No");
            entity.Property(e => e.SrNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("SR No");
            entity.Property(e => e.TgtNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("TGT No");
            entity.Property(e => e.TiNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("TI No");
            entity.Property(e => e.ToNo)
                .HasMaxLength(23)
                .HasDefaultValueSql("((1))")
                .HasColumnName("TO No");
        });

        modelBuilder.Entity<InvNoImgTb>(entity =>
        {
            entity.ToTable("InvNoImgTb");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InvNoImg).HasColumnType("image");
        });

        modelBuilder.Entity<IsapprovalAfterAgd>(entity =>
        {
            entity.HasKey(e => e.PermitNo);

            entity.ToTable("ISApprovalAfterAgd");

            entity.Property(e => e.PermitNo).ValueGeneratedNever();
            entity.Property(e => e.PermitBy).HasMaxLength(10);
            entity.Property(e => e.PermitTm).HasColumnType("datetime");
        });

        modelBuilder.Entity<ItemMastLevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ItemMastLevel");

            entity.HasIndex(e => new { e.ItemId, e.Lcode }, "IX_ItemMastLevel").IsUnique();

            entity.Property(e => e.Lcode).HasColumnName("LCode");
        });

        modelBuilder.Entity<ItmInvCmnTb>(entity =>
        {
            entity.HasKey(e => e.TrId);

            entity.ToTable("ItmInvCmnTb");

            entity.HasIndex(e => new { e.TrType, e.PreFix, e.InvNo }, "IX_ItmInvCmnTb").IsUnique();

            entity.Property(e => e.ApprvdBy)
                .HasMaxLength(10)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.ApprvdTime).HasColumnType("datetime");
            entity.Property(e => e.AreaCode).HasMaxLength(10);
            entity.Property(e => e.Asp).HasColumnName("ASP");
            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.CalcTax).HasColumnName("CalcTAX");
            entity.Property(e => e.Cessamt).HasColumnName("CESSAmt");
            entity.Property(e => e.Charge2).HasDefaultValue(0.0);
            entity.Property(e => e.ChargesOnPl).HasColumnName("ChargesOnPL");
            entity.Property(e => e.Counter).HasMaxLength(10);
            entity.Property(e => e.CrtDt).HasColumnType("datetime");
            entity.Property(e => e.Cscode).HasColumnName("CSCode");
            entity.Property(e => e.DefStkOutBr).HasMaxLength(50);
            entity.Property(e => e.DelDate).HasColumnType("datetime");
            entity.Property(e => e.DestBr)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.DoRfrshTaxMnl).HasColumnName("doRfrshTaxMnl");
            entity.Property(e => e.DocDate).HasColumnType("datetime");
            entity.Property(e => e.DocDefLoc).HasMaxLength(20);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.ElnBr).HasColumnName("ELnBr");
            entity.Property(e => e.Fc)
                .HasMaxLength(5)
                .HasColumnName("FC");
            entity.Property(e => e.Fcrate).HasColumnName("FCRate");
            entity.Property(e => e.InvTypeNo).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.IsFc).HasColumnName("IsFC");
            entity.Property(e => e.IsPos).HasColumnName("IsPOS");
            entity.Property(e => e.IsPostrCompleted).HasColumnName("IsPOSTrCompleted");
            entity.Property(e => e.JobCode)
                .HasMaxLength(10)
                .HasColumnName("Job Code");
            entity.Property(e => e.Lpo).HasColumnName("LPO");
            entity.Property(e => e.LstModiUsrId).HasMaxLength(10);
            entity.Property(e => e.ModiDt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("datetime");
            entity.Property(e => e.MtrId).HasColumnName("MTrId");
            entity.Property(e => e.Nfraction).HasColumnName("NFraction");
            entity.Property(e => e.NoVatinv).HasColumnName("NoVATInv");
            entity.Property(e => e.NoVatreasonId).HasColumnName("NoVATReasonId");
            entity.Property(e => e.OptId).HasColumnName("optID");
            entity.Property(e => e.OthInf).HasMaxLength(60);
            entity.Property(e => e.PreFix)
                .HasMaxLength(15)
                .HasDefaultValue("");
            entity.Property(e => e.Psacc).HasColumnName("PSAcc");
            entity.Property(e => e.RetInvIds).HasMaxLength(30);
            entity.Property(e => e.RndFra).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.SlsManId).HasMaxLength(10);
            entity.Property(e => e.SourceBr).HasMaxLength(10);
            entity.Property(e => e.SuppInvDate).HasColumnType("datetime");
            entity.Property(e => e.TCessper).HasColumnName("tCESSPer");
            entity.Property(e => e.TaxtoNo).HasColumnName("TAXToNo");
            entity.Property(e => e.TermsId).HasMaxLength(15);
            entity.Property(e => e.TrDate).HasColumnType("datetime");
            entity.Property(e => e.TrDescription).HasMaxLength(150);
            entity.Property(e => e.TrRefNo).HasMaxLength(30);
            entity.Property(e => e.TrType).HasMaxLength(3);
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<ItmInvTrTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ItmInvTrTb");

            entity.HasIndex(e => e.BaseId, "IX_ItmInvTrTb_BaseId");

            entity.HasIndex(e => new { e.BaseId, e.Location, e.TrTypeNo }, "IX_ItmInvTrTb_BaseIdTrTypeNoLoc");

            entity.HasIndex(e => e.TrId, "IX_ItmInvTrTb_TrId");

            entity.Property(e => e.Aloc)
                .HasMaxLength(20)
                .HasColumnName("ALoc");
            entity.Property(e => e.C)
                .HasDefaultValue((byte)1)
                .HasColumnName("c");
            entity.Property(e => e.Cessper)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CESSper");
            entity.Property(e => e.Dmethod).HasColumnName("DMethod");
            entity.Property(e => e.ExpiryDt).HasColumnType("datetime");
            entity.Property(e => e.FoccostMpg).HasColumnName("FOCCostMpg");
            entity.Property(e => e.Focdescr)
                .HasMaxLength(50)
                .HasColumnName("FOCDescr");
            entity.Property(e => e.Focmapping)
                .HasMaxLength(50)
                .HasColumnName("FOCMapping");
            entity.Property(e => e.Idescription)
                .HasMaxLength(150)
                .HasColumnName("IDescription");
            entity.Property(e => e.Ino).HasColumnName("INo");
            entity.Property(e => e.IsLineDisc)
                .HasDefaultValue(true)
                .HasColumnName("IsLineDisc%");
            entity.Property(e => e.LastDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LineDisc).HasColumnName("LineDisc%");
            entity.Property(e => e.LmsgNo).HasColumnName("LMsgNo");
            entity.Property(e => e.LnJobCode).HasMaxLength(10);
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.MtrPqty).HasColumnName("MTrPQty");
            entity.Property(e => e.OutLoc).HasMaxLength(20);
            entity.Property(e => e.PSlNo).HasColumnName("pSlNo");
            entity.Property(e => e.Pack).HasMaxLength(50);
            entity.Property(e => e.Pfraction)
                .HasDefaultValue(1f)
                .HasColumnName("PFraction");
            entity.Property(e => e.QtyFoc).HasColumnName("QtyFOC");
            entity.Property(e => e.TaxPer).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Taxmpg)
                .HasMaxLength(25)
                .HasColumnName("TAXMpg");
            entity.Property(e => e.TrTypeNo).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Unit).HasMaxLength(10);
            entity.Property(e => e.UnitFraCount).HasDefaultValue((byte)2);
        });

        modelBuilder.Entity<JobColPopup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("JobColPopup");

            entity.Property(e => e.ColFld).HasMaxLength(50);
            entity.Property(e => e.SelectItem).HasMaxLength(75);
        });

        modelBuilder.Entity<JobColProperty>(entity =>
        {
            entity.HasKey(e => e.ColFld);

            entity.ToTable("JobColProperty");

            entity.Property(e => e.ColFld).HasMaxLength(50);
            entity.Property(e => e.ColCaption).HasMaxLength(50);
            entity.Property(e => e.FldAlign).HasDefaultValue((short)1);
            entity.Property(e => e.FldSize).HasDefaultValue((short)50);
        });

        modelBuilder.Entity<JobDetTbA>(entity =>
        {
            entity.HasKey(e => e.JobCode);

            entity.ToTable("JobDetTbA");

            entity.Property(e => e.JobCode)
                .HasMaxLength(10)
                .HasColumnName("Job Code");
            entity.Property(e => e.CreatedBy).HasMaxLength(10);
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End Date");
            entity.Property(e => e.EstimateAmt).HasColumnName("Estimate Amt");
            entity.Property(e => e.JobComplete).HasColumnName("Job Complete");
            entity.Property(e => e.JobName)
                .HasMaxLength(50)
                .HasColumnName("Job Name");
            entity.Property(e => e.JobNature)
                .HasMaxLength(200)
                .HasColumnName("Job Nature");
            entity.Property(e => e.ModiDt).HasColumnType("datetime");
            entity.Property(e => e.OpnCost).HasColumnName("Opn Cost");
            entity.Property(e => e.OpnIncome).HasColumnName("Opn Income");
            entity.Property(e => e.RfrshDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SalesMan).HasMaxLength(10);
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start Date");
        });

        modelBuilder.Entity<JobEstimateTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("JobEstimateTb");

            entity.HasIndex(e => new { e.JobId, e.SlNo }, "IX_JobEstimateTb");

            entity.Property(e => e.EstDescription).HasMaxLength(150);
        });

        modelBuilder.Entity<JobInfTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("JobInfTb");
        });

        modelBuilder.Entity<JobPriorYrTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("JobPriorYrTb");

            entity.Property(e => e.JobCode).HasMaxLength(10);
        });

        modelBuilder.Entity<LanguageTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LanguageTb");

            entity.Property(e => e.Language).HasMaxLength(25);
        });

        modelBuilder.Entity<LastDocNoTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LastDocNoTb");

            entity.Property(e => e.ApplDoc).HasDefaultValue(1000L);
            entity.Property(e => e.ContrDoc).HasDefaultValue(1000L);
        });

        modelBuilder.Entity<LastJobDid>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LastJobDid");

            entity.Property(e => e.LstJobCode).HasMaxLength(10);
        });

        modelBuilder.Entity<LastPsinfTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LastPSInfTb");

            entity.HasIndex(e => new { e.ItemId, e.PartyNo }, "IX_LastPSInfTb");

            entity.Property(e => e.LastDescr).HasMaxLength(150);
            entity.Property(e => e.LastDt).HasColumnType("datetime");
            entity.Property(e => e.Pfraction).HasColumnName("PFraction");
        });

        modelBuilder.Entity<LevelTb>(entity =>
        {
            entity.HasKey(e => e.Lcode);

            entity.ToTable("LevelTb");

            entity.HasIndex(e => e.Lorder, "IX_LevelTb");

            entity.Property(e => e.Lcode).HasColumnName("LCode");
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .HasColumnName("LName");
            entity.Property(e => e.Lorder).HasColumnName("LOrder");
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<LmsgTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LMsgTb");

            entity.HasIndex(e => e.Id, "IX_LMsgTb").IsUnique();

            entity.Property(e => e.HdFt)
                .HasMaxLength(255)
                .HasColumnName("Hd/Ft");
        });

        modelBuilder.Entity<LoanDetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LoanDetTb");

            entity.Property(e => e.InsMonth).HasColumnType("datetime");
            entity.Property(e => e.Pamount).HasColumnName("PAmount");
        });

        modelBuilder.Entity<LoanTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LoanTb");

            entity.Property(e => e.LoanDt).HasColumnType("datetime");
            entity.Property(e => e.LoanEdt)
                .HasColumnType("datetime")
                .HasColumnName("LoanEDt");
            entity.Property(e => e.LoanIssdDt).HasColumnType("datetime");
            entity.Property(e => e.LoanName).HasMaxLength(30);
        });

        modelBuilder.Entity<LocTrCmn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LocTrCmn");

            entity.HasIndex(e => new { e.TrType, e.InvNo }, "IX_LocTrCmn").IsUnique();

            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.Cscode).HasColumnName("CSCode");
            entity.Property(e => e.DefLocFrom).HasMaxLength(20);
            entity.Property(e => e.DefLocTo).HasMaxLength(20);
            entity.Property(e => e.JobCode)
                .HasMaxLength(10)
                .HasColumnName("Job Code");
            entity.Property(e => e.LstModiUsrId).HasMaxLength(10);
            entity.Property(e => e.SlsManId).HasMaxLength(10);
            entity.Property(e => e.TrDate).HasColumnType("datetime");
            entity.Property(e => e.TrDescription).HasMaxLength(150);
            entity.Property(e => e.TrRefNo).HasMaxLength(20);
            entity.Property(e => e.TrType).HasMaxLength(3);
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<LocTrDet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LocTrDet");

            entity.HasIndex(e => e.BaseId, "IX_LocTrDet_BaseId");

            entity.HasIndex(e => e.TrId, "IX_LocTrDet_TrId");

            entity.Property(e => e.Idescription)
                .HasMaxLength(150)
                .HasColumnName("IDescription");
            entity.Property(e => e.InLoc).HasMaxLength(20);
            entity.Property(e => e.LmsgNo).HasColumnName("LMsgNo");
            entity.Property(e => e.OutLoc).HasMaxLength(20);
            entity.Property(e => e.TrTypeNo).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Unit).HasMaxLength(10);
        });

        modelBuilder.Entity<LocationTb>(entity =>
        {
            entity.HasKey(e => e.LocationId);

            entity.ToTable("LocationTb");

            entity.HasIndex(e => e.LocNo, "IX_LocationTb").IsUnique();

            entity.Property(e => e.LocationId).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(30);
            entity.Property(e => e.LocNo).ValueGeneratedOnAdd();
            entity.Property(e => e.Whno).HasColumnName("WHNo");
        });

        modelBuilder.Entity<LoginStatusTb>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("LoginStatusTb");

            entity.Property(e => e.BrefreshTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("BRefreshTm");
            entity.Property(e => e.LoginTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RefreshTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<LvSalProvTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LvSalProvTb");

            entity.Property(e => e.DtMonth)
                .HasColumnType("datetime")
                .HasColumnName("dtMonth");
        });

        modelBuilder.Entity<MaccHd>(entity =>
        {
            entity.HasKey(e => e.MaccId);

            entity.ToTable("MAccHd");

            entity.Property(e => e.MaccId)
                .ValueGeneratedNever()
                .HasColumnName("MAccId");
            entity.Property(e => e.Descr).HasMaxLength(60);
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<MenuTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MenuTb");

            entity.HasIndex(e => e.ModuleCode, "IX_MenuTb").IsClustered();

            entity.Property(e => e.IconKey).HasMaxLength(40);
            entity.Property(e => e.KeyStr).HasMaxLength(15);
            entity.Property(e => e.LangArabic)
                .HasMaxLength(80)
                .HasColumnName("langArabic");
            entity.Property(e => e.LangEnglish)
                .HasMaxLength(80)
                .HasColumnName("langEnglish");
            entity.Property(e => e.ModuleCode).HasMaxLength(15);
        });

        modelBuilder.Entity<ModuEnaTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ModuEnaTb");

            entity.Property(e => e.ProcessCode).HasMaxLength(15);
        });

        modelBuilder.Entity<ModuleColourTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ModuleColourTb");

            entity.HasIndex(e => new { e.UserId, e.ModuleNo }, "IX_ModuleColourTb").IsUnique();
        });

        modelBuilder.Entity<ModuleCustomTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ModuleCustomTb");

            entity.Property(e => e.AllowanceCap1).HasMaxLength(25);
            entity.Property(e => e.AllowanceCap2).HasMaxLength(25);
            entity.Property(e => e.AllowanceCap3).HasMaxLength(25);
            entity.Property(e => e.AllowanceCap4).HasMaxLength(25);
            entity.Property(e => e.AllowanceCap5).HasMaxLength(25);
            entity.Property(e => e.ChargeCap1).HasMaxLength(25);
            entity.Property(e => e.ChargeCap2).HasMaxLength(25);
            entity.Property(e => e.ChargeCap3).HasMaxLength(25);
            entity.Property(e => e.ChargeCap4).HasMaxLength(25);
            entity.Property(e => e.ChargeCap5).HasMaxLength(25);
            entity.Property(e => e.Class1)
                .HasMaxLength(25)
                .HasColumnName("Class 1");
            entity.Property(e => e.Class2)
                .HasMaxLength(25)
                .HasColumnName("Class 2");
            entity.Property(e => e.Class3)
                .HasMaxLength(25)
                .HasColumnName("Class 3");
            entity.Property(e => e.PayDeduCap1).HasMaxLength(25);
            entity.Property(e => e.PayDeduCap2).HasMaxLength(25);
            entity.Property(e => e.PayDeduCap3).HasMaxLength(25);
            entity.Property(e => e.PayDeduCap4).HasMaxLength(25);
        });

        modelBuilder.Entity<NarationTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NarationTb");

            entity.HasIndex(e => e.ItemId, "IX_NarationTb");

            entity.Property(e => e.Naration).HasMaxLength(100);
        });

        modelBuilder.Entity<NizBalAnalysis>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nizBalAnalysis");

            entity.HasIndex(e => new { e.SrvrMdulId, e.DueDt, e.AccNo }, "IX_nizBalAnalysis");

            entity.Property(e => e.DueDt).HasColumnType("datetime");
            entity.Property(e => e.GrvAmt).HasColumnName("GRV Amt");
            entity.Property(e => e.LddDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(30);
            entity.Property(e => e.SrvrMdulId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupInvDt).HasColumnType("datetime");
            entity.Property(e => e.VrDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<NizBalAnalysisR>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nizBalAnalysisR");

            entity.HasIndex(e => new { e.SrvrMdulId, e.DueDt, e.AccNo }, "IX_nizBalAnalysis");

            entity.Property(e => e.DueDt).HasColumnType("datetime");
            entity.Property(e => e.LddDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(30);
            entity.Property(e => e.SrAmt).HasColumnName("SR Amt");
            entity.Property(e => e.SrvrMdulId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VrDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<NizCashFlowTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nizCashFlowTb");

            entity.HasIndex(e => e.Jvdate, "IX_nizCashFlowTb");

            entity.Property(e => e.Category).HasMaxLength(10);
            entity.Property(e => e.Jvdate)
                .HasColumnType("datetime")
                .HasColumnName("JVDate");
            entity.Property(e => e.Obamt).HasColumnName("OBAmt");
            entity.Property(e => e.Server).HasMaxLength(20);
        });

        modelBuilder.Entity<NizPrdOpnClVal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nizPrdOpnClVal");

            entity.Property(e => e.LddDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SrvrMdulId)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NizPvlpoassgnmnt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nizPVLPOAssgnmnt");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Po).HasColumnName("PO");
            entity.Property(e => e.Reference).HasMaxLength(20);
            entity.Property(e => e.Server).HasMaxLength(20);
        });

        modelBuilder.Entity<NizRfrhT>(entity =>
        {
            entity.ToTable("nizRfrhT");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.GrpId).HasColumnName("GrpID");
            entity.Property(e => e.Vatper)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("VATPer");
        });

        modelBuilder.Entity<NizRfrhTacc>(entity =>
        {
            entity.HasKey(e => new { e.Lid, e.AccNo, e.ApplyFor });

            entity.ToTable("nizRfrhTAcc");

            entity.Property(e => e.Lid).HasColumnName("LId");
            entity.Property(e => e.TaxPer).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<NizRfrshDoing>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nizRfrshDoing");

            entity.HasIndex(e => new { e.DocType, e.DoingDocNo }, "IX_tmpRfrshDoing").IsUnique();

            entity.Property(e => e.ReqDtTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ServerDb).HasMaxLength(60);
        });

        modelBuilder.Entity<NizRfrshPending>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nizRfrshPending");

            entity.HasIndex(e => new { e.DocType, e.ReqDtTm, e.PendingDocNo }, "IX_tmpRfrshPending");

            entity.Property(e => e.ActionDt).HasColumnType("datetime");
            entity.Property(e => e.ActionNo).HasComment("0 - Normal (based on last blockdt) 1 - Including Last Block ranage, 2 - All, 3 -  After given date");
            entity.Property(e => e.ReqDtTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TmDelay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<NoTaxtypeTb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NoTAXType");

            entity.ToTable("NoTAXTypeTb");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoTaxtype)
                .HasMaxLength(20)
                .HasColumnName("NoTAXType");
        });

        modelBuilder.Entity<NprdCode>(entity =>
        {
            entity.HasKey(e => e.Pfix);

            entity.ToTable("NPrdCode");

            entity.Property(e => e.Pfix)
                .HasMaxLength(25)
                .HasDefaultValue("")
                .HasColumnName("PFix");
            entity.Property(e => e.Ncount)
                .HasDefaultValue((byte)3)
                .HasColumnName("NCount");
            entity.Property(e => e.Num).HasDefaultValue(1.0);
        });

        modelBuilder.Entity<NprdUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NPrdUser");

            entity.HasIndex(e => e.UsrNo, "IX_NPrdUser").IsUnique();

            entity.Property(e => e.DoneTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Pfix)
                .HasMaxLength(25)
                .HasColumnName("PFix");
        });

        modelBuilder.Entity<NsinvPurchAcc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NSInvPurchAcc");

            entity.HasIndex(e => e.AccNo, "IX_NSInvPurchAcc").IsUnique();

            entity.Property(e => e.Obamt).HasColumnName("OBAmt");
        });

        modelBuilder.Entity<NsmnthlyExp>(entity =>
        {
            entity.HasKey(e => e.DtMonth);

            entity.ToTable("NSMnthlyExp");

            entity.Property(e => e.DtMonth)
                .HasColumnType("datetime")
                .HasColumnName("dtMonth");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<OfferBgftp>(entity =>
        {
            entity.HasKey(e => e.Bgfid);

            entity.ToTable("OfferBGFTp");

            entity.Property(e => e.Bgfid).HasColumnName("BGFId");
            entity.Property(e => e.Bgfcode)
                .HasMaxLength(15)
                .HasColumnName("BGFCode");
            entity.Property(e => e.Bgfname)
                .HasMaxLength(50)
                .HasColumnName("BGFName");
            entity.Property(e => e.BuyQty).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.GetQty).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<OfferBgodtp>(entity =>
        {
            entity.HasKey(e => e.Bgodid);

            entity.ToTable("OfferBGODTp");

            entity.Property(e => e.Bgodid).HasColumnName("BGODId");
            entity.Property(e => e.Bgodcode)
                .HasMaxLength(15)
                .HasColumnName("BGODCode");
            entity.Property(e => e.Bgodname)
                .HasMaxLength(50)
                .HasColumnName("BGODName");
            entity.Property(e => e.BuyQty).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DiscPer).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.GetQty).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<OfferBoatp>(entity =>
        {
            entity.HasKey(e => e.Boaid);

            entity.ToTable("OfferBOATp");

            entity.Property(e => e.Boaid).HasColumnName("BOAId");
            entity.Property(e => e.Boacode)
                .HasMaxLength(15)
                .HasColumnName("BOACode");
            entity.Property(e => e.Boaname)
                .HasMaxLength(50)
                .HasColumnName("BOAName");
            entity.Property(e => e.DiscPer).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LimitAmt).HasColumnType("decimal(10, 3)");
        });

        modelBuilder.Entity<OfferSession>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OfferSession");

            entity.HasIndex(e => e.SessionId, "IX_OfferSession").IsUnique();

            entity.Property(e => e.Bgfid).HasColumnName("BGFId");
            entity.Property(e => e.Bgodid).HasColumnName("BGODId");
            entity.Property(e => e.Boaid).HasColumnName("BOAId");
            entity.Property(e => e.OfferDescr).HasMaxLength(50);
            entity.Property(e => e.PrdFrom).HasColumnType("datetime");
            entity.Property(e => e.PrdTo).HasColumnType("datetime");
        });

        modelBuilder.Entity<PassCardTb>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("PassCardTb");

            entity.HasIndex(e => new { e.Id, e.UsrRef }, "IX_PassCardTb").IsUnique();

            entity.Property(e => e.Key).ValueGeneratedNever();
            entity.Property(e => e.CardData).HasMaxLength(150);
            entity.Property(e => e.UsrRef).HasMaxLength(50);
        });

        modelBuilder.Entity<PassFngrTb>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.FngrNo });

            entity.ToTable("PassFngrTb");
        });

        modelBuilder.Entity<PassId>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("PassId");

            entity.HasIndex(e => e.Id, "IX_PassId").IsUnique();

            entity.Property(e => e.UserId).HasMaxLength(10);
            entity.Property(e => e.DefLoc).HasMaxLength(10);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LstOpnBr).HasMaxLength(10);
            entity.Property(e => e.MasterYn).HasColumnName("MasterYN");
            entity.Property(e => e.Password).HasMaxLength(15);
            entity.Property(e => e.Ph).HasColumnType("image");
            entity.Property(e => e.StripData).HasMaxLength(150);
        });

        modelBuilder.Entity<PassSuperCardTb>(entity =>
        {
            entity.ToTable("PassSuperCardTb");

            entity.HasIndex(e => e.CardData, "IX_PassSuperCardTb").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CardData).HasMaxLength(150);
        });

        modelBuilder.Entity<PdabcprtReq>(entity =>
        {
            entity.HasKey(e => e.ReqTm);

            entity.ToTable("PDABCPrtReq");

            entity.Property(e => e.ReqTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BarObject).HasMaxLength(50);
            entity.Property(e => e.Condition).HasMaxLength(255);
            entity.Property(e => e.DeleDt).HasColumnType("datetime");
            entity.Property(e => e.FmtName).HasMaxLength(100);
            entity.Property(e => e.ObjType).HasComment("0 - Product, 1 - ");
            entity.Property(e => e.Pdaid)
                .HasMaxLength(50)
                .HasColumnName("PDAId");
            entity.Property(e => e.RptName).HasMaxLength(255);
        });

        modelBuilder.Entity<Pdalist>(entity =>
        {
            entity.HasKey(e => e.Pdacode);

            entity.ToTable("PDAList");

            entity.Property(e => e.Pdacode)
                .HasMaxLength(15)
                .HasColumnName("PDACode");
            entity.Property(e => e.Holder).HasMaxLength(50);
        });

        modelBuilder.Entity<PdanewProdReq>(entity =>
        {
            entity.ToTable("PDANewProdReq");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Bc)
                .HasMaxLength(50)
                .HasColumnName("BC");
            entity.Property(e => e.GrpCode).HasMaxLength(15);
            entity.Property(e => e.Ic)
                .HasMaxLength(30)
                .HasColumnName("IC");
            entity.Property(e => e.Idescr)
                .HasMaxLength(100)
                .HasColumnName("IDescr");
            entity.Property(e => e.NUnit)
                .HasMaxLength(10)
                .HasColumnName("nUnit");
            entity.Property(e => e.Pic)
                .HasMaxLength(30)
                .HasColumnName("PIC");
            entity.Property(e => e.Vdown)
                .HasDefaultValue(1)
                .HasColumnName("VDown");
            entity.Property(e => e.Vup)
                .HasDefaultValue(1)
                .HasColumnName("VUp");
        });

        modelBuilder.Entity<PdaprdChgReqCmn>(entity =>
        {
            entity.HasKey(e => e.ReqNo);

            entity.ToTable("PDAPrdChgReqCmn");

            entity.Property(e => e.ReqNo).ValueGeneratedNever();
            entity.Property(e => e.ReqBy).HasMaxLength(50);
            entity.Property(e => e.ReqDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PdaprdChgReqDet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PDAPrdChgReqDet");

            entity.HasIndex(e => e.ItemId, "IX_PDAPrdChgReqDet").IsUnique();

            entity.Property(e => e.Dval)
                .HasDefaultValue(1)
                .HasColumnName("DVal");
            entity.Property(e => e.IsBase).HasDefaultValue(false);
            entity.Property(e => e.NewBase).HasDefaultValue(false);
            entity.Property(e => e.Nunit)
                .HasMaxLength(50)
                .HasColumnName("NUnit");
            entity.Property(e => e.Uval)
                .HasDefaultValue(1)
                .HasColumnName("UVal");
        });

        modelBuilder.Entity<PdaprodList>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("PDAProdList");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
            entity.Property(e => e.DelDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<PdatrCmn>(entity =>
        {
            entity.HasKey(e => e.TrNo);

            entity.ToTable("PDATrCmn");

            entity.Property(e => e.CrtdTm).HasColumnType("datetime");
            entity.Property(e => e.InvNo).HasMaxLength(20);
            entity.Property(e => e.IsPer).HasDefaultValue(true);
            entity.Property(e => e.JobCode).HasMaxLength(10);
            entity.Property(e => e.Pdacode)
                .HasMaxLength(20)
                .HasColumnName("PDACode");
            entity.Property(e => e.Reference).HasMaxLength(30);
            entity.Property(e => e.UserId).HasMaxLength(50);
        });

        modelBuilder.Entity<PdatrDet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PDATrDet");

            entity.Property(e => e.Bc)
                .HasMaxLength(50)
                .HasColumnName("BC");
            entity.Property(e => e.Focmpg)
                .HasMaxLength(150)
                .HasColumnName("FOCMpg");
            entity.Property(e => e.Ic)
                .HasMaxLength(30)
                .HasColumnName("IC");
            entity.Property(e => e.Iname)
                .HasMaxLength(80)
                .HasColumnName("IName");
            entity.Property(e => e.IsFoc).HasColumnName("IsFOC");
            entity.Property(e => e.IsPer).HasDefaultValue(true);
            entity.Property(e => e.LocId).HasMaxLength(20);
            entity.Property(e => e.Unit).HasMaxLength(10);
        });

        modelBuilder.Entity<PdtdataTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PDTDataTb");

            entity.Property(e => e.BId).HasColumnName("bId");
            entity.Property(e => e.BarCode).HasMaxLength(30);
            entity.Property(e => e.DoDel).HasColumnName("doDel");
            entity.Property(e => e.ExpDt).HasColumnType("datetime");
            entity.Property(e => e.FlName).HasMaxLength(50);
            entity.Property(e => e.IDescription)
                .HasMaxLength(100)
                .HasColumnName("iDescription");
            entity.Property(e => e.IUnit)
                .HasMaxLength(10)
                .HasColumnName("iUnit");
            entity.Property(e => e.Iid).HasColumnName("IId");
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.PdtbarCode)
                .HasMaxLength(30)
                .HasColumnName("PDTBarCode");
            entity.Property(e => e.Pfraction)
                .HasDefaultValue(1f)
                .HasColumnName("PFraction");
            entity.Property(e => e.SExpDt)
                .HasMaxLength(50)
                .HasColumnName("sExpDt");
            entity.Property(e => e.SPrice).HasColumnName("sPrice");
            entity.Property(e => e.ScanTm).HasColumnType("datetime");
            entity.Property(e => e.SysBranch)
                .HasMaxLength(10)
                .HasColumnName("sysBranch");
            entity.Property(e => e.SysLocation)
                .HasMaxLength(10)
                .HasColumnName("sysLocation");
        });

        modelBuilder.Entity<PeriodClosingTb>(entity =>
        {
            entity.HasKey(e => e.CloseNo);

            entity.ToTable("PeriodClosingTb");

            entity.HasIndex(e => e.ClosedUpTo, "IX_PeriodClosingTb").IsUnique();

            entity.Property(e => e.ClosedUpTo).HasColumnType("datetime");
            entity.Property(e => e.ClosingStock).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CrtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DirectExp).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DirectIncome).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.IndExp).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.IndIncome).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ModiTm).HasColumnType("datetime");
            entity.Property(e => e.OpngStock).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<PettyDescrTb>(entity =>
        {
            entity.HasKey(e => e.PettyDescr).HasName("PK_PettyDescr");

            entity.ToTable("PettyDescrTb");

            entity.HasIndex(e => e.PettyId, "IX_PettyDescrTb");

            entity.Property(e => e.PettyDescr).HasMaxLength(80);
        });

        modelBuilder.Entity<Pgassgn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PGAssgn");

            entity.HasIndex(e => new { e.SourceCat, e.PgrpId, e.SourceVal }, "IX_PGAssgn").IsUnique();

            entity.Property(e => e.DeleteDt).HasColumnType("datetime");
            entity.Property(e => e.PgrpId).HasColumnName("PGrpId");
            entity.Property(e => e.SourceCat).HasComment("0 - Record related to Product, 1 - Related to First Level Group");
        });

        modelBuilder.Entity<PhyCmnTb>(entity =>
        {
            entity.HasKey(e => e.PhyNo);

            entity.ToTable("PhyCmnTb");

            entity.Property(e => e.PhyNo).ValueGeneratedNever();
            entity.Property(e => e.CmnDescription).HasMaxLength(150);
            entity.Property(e => e.LstModiUsrId).HasMaxLength(10);
            entity.Property(e => e.Phino).HasColumnName("PHINo");
            entity.Property(e => e.Phono).HasColumnName("PHONo");
            entity.Property(e => e.PhyDate).HasColumnType("datetime");
            entity.Property(e => e.QihisZeroForRemain).HasColumnName("QIHIsZeroForRemain");
            entity.Property(e => e.TrRefNo).HasMaxLength(20);
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(10);
        });

        modelBuilder.Entity<PhyDetTb>(entity =>
        {
            entity.HasKey(e => e.RecNo);

            entity.ToTable("PhyDetTb");

            entity.HasIndex(e => e.PhyNo, "IX_PhyDetTb");

            entity.HasIndex(e => e.RecNo, "IX_PhyDetTb_1").IsUnique();

            entity.Property(e => e.RecNo).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(30);
            entity.Property(e => e.ExpDt).HasColumnType("datetime");
            entity.Property(e => e.FlName).HasMaxLength(50);
            entity.Property(e => e.ItmC).HasMaxLength(30);
            entity.Property(e => e.ItmN).HasMaxLength(80);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.ModiDt).HasColumnType("datetime");
            entity.Property(e => e.Pfraction).HasColumnName("PFraction");
            entity.Property(e => e.SExpDt)
                .HasMaxLength(50)
                .HasColumnName("sExpDt");
            entity.Property(e => e.ScanTm).HasColumnType("datetime");
            entity.Property(e => e.StkTakenDt)
                .HasColumnType("datetime")
                .HasColumnName("stkTakenDt");
            entity.Property(e => e.StkTakenQty).HasColumnName("stkTakenQty");
            entity.Property(e => e.SysBranch)
                .HasMaxLength(10)
                .HasColumnName("sysBranch");
            entity.Property(e => e.SysLocation)
                .HasMaxLength(20)
                .HasColumnName("sysLocation");
            entity.Property(e => e.TrDate).HasColumnType("datetime");
            entity.Property(e => e.Unit).HasMaxLength(10);
        });

        modelBuilder.Entity<PhyDoingTb>(entity =>
        {
            entity.HasKey(e => e.PhyNo);

            entity.ToTable("PhyDoingTb");
        });

        modelBuilder.Entity<PhySmmTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PhySmmTb");

            entity.HasIndex(e => new { e.PhyNo, e.Iid }, "IX_PhySmmTb");

            entity.Property(e => e.Iid).HasColumnName("IId");
            entity.Property(e => e.Pqty).HasColumnName("PQty");
            entity.Property(e => e.Qih).HasColumnName("QIH");
            entity.Property(e => e.SysBranch)
                .HasMaxLength(10)
                .HasColumnName("sysBranch");
        });

        modelBuilder.Entity<PkPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PkPrice");

            entity.Property(e => e.Ic)
                .HasMaxLength(30)
                .HasColumnName("IC");
            entity.Property(e => e.Unit).HasMaxLength(15);
        });

        modelBuilder.Entity<PoscrNoteTb>(entity =>
        {
            entity.HasKey(e => e.VchrNo);

            entity.ToTable("POSCrNoteTb");

            entity.Property(e => e.VchrNo).ValueGeneratedNever();
            entity.Property(e => e.Amt).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.CrtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsPos).HasColumnName("IsPOS");
            entity.Property(e => e.IssdBy).HasMaxLength(50);
            entity.Property(e => e.IssdCounter).HasMaxLength(50);
            entity.Property(e => e.IssdPosdt)
                .HasColumnType("datetime")
                .HasColumnName("IssdPOSDt");
            entity.Property(e => e.MsysDateTime)
                .HasColumnType("datetime")
                .HasColumnName("MSysDateTime");
            entity.Property(e => e.TrId).HasDefaultValue(0);
            entity.Property(e => e.UsedLsysDateTime)
                .HasColumnType("datetime")
                .HasColumnName("UsedLSysDateTime");
        });

        modelBuilder.Entity<PostatusTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("POStatusTb");

            entity.Property(e => e.Jvnum).HasColumnName("JVNum");
            entity.Property(e => e.Jvtype)
                .HasMaxLength(3)
                .HasColumnName("JVType");
            entity.Property(e => e.Po).HasColumnName("PO");
            entity.Property(e => e.PreFix).HasMaxLength(5);
            entity.Property(e => e.Reference).HasMaxLength(30);
        });

        modelBuilder.Entity<PrdGrpCmnTb>(entity =>
        {
            entity.HasKey(e => e.ProdGrpCode);

            entity.ToTable("PrdGrpCmnTb");

            entity.Property(e => e.ProdGrpCode).HasMaxLength(10);
            entity.Property(e => e.ProdGrpName).HasMaxLength(50);
        });

        modelBuilder.Entity<PrdGrpDetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PrdGrpDetTb");

            entity.HasIndex(e => new { e.GrpId, e.ItemId }, "IX_PrdGrpDetTb");

            entity.Property(e => e.DelIdDt).HasColumnType("datetime");
            entity.Property(e => e.Descr).HasMaxLength(50);
            entity.Property(e => e.Img).HasColumnType("image");
        });

        modelBuilder.Entity<PrdSrlNoTrTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PrdSrlNoTrTb");

            entity.HasIndex(e => new { e.TrId, e.SlNo, e.SslNo }, "IX_PrdSrlNoTrTb");

            entity.Property(e => e.BranchId).HasMaxLength(10);
            entity.Property(e => e.SrlNo).HasMaxLength(50);
            entity.Property(e => e.SslNo).HasColumnName("SSlNo");
            entity.Property(e => e.TrTpNo).HasColumnType("decimal(6, 2)");
        });

        modelBuilder.Entity<PreFixTb>(entity =>
        {
            entity.ToTable("PreFixTb");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ano).HasColumnName("ANo");
            entity.Property(e => e.Ano2).HasColumnName("ANo2");
            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.Img).HasColumnType("image");
            entity.Property(e => e.PreFix).HasMaxLength(15);
            entity.Property(e => e.VoucherName)
                .HasMaxLength(50)
                .HasColumnName("Voucher Name");
        });

        modelBuilder.Entity<PriceChgLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PriceChgLog");

            entity.Property(e => e.BrId)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.ChgBy).HasMaxLength(10);
            entity.Property(e => e.PriceChgDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PriceGrpTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PriceGrpTb");

            entity.HasIndex(e => e.Pgcode, "IX_PriceGrpTb_PGCode").IsUnique();

            entity.HasIndex(e => e.Pgid, "IX_PriceGrpTb_PGId").IsUnique();

            entity.Property(e => e.FisAdd).HasColumnName("FIsAdd");
            entity.Property(e => e.FisPer).HasColumnName("FIsPer");
            entity.Property(e => e.Fpgid).HasColumnName("FPGId");
            entity.Property(e => e.Fvalue).HasColumnName("FValue");
            entity.Property(e => e.Pgcode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PGCode");
            entity.Property(e => e.Pgid).HasColumnName("PGId");
            entity.Property(e => e.Pgname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PGName");
            entity.Property(e => e.RndFra).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<PriorYearInfTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PriorYearInfTb");

            entity.HasIndex(e => e.DtFrom, "IX_PriorYearInfTb");

            entity.Property(e => e.DbName).HasMaxLength(50);
            entity.Property(e => e.DtFrom).HasColumnType("datetime");
            entity.Property(e => e.DtTo).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProdImgTb>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("ProdImgTb");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
            entity.Property(e => e.Img).HasColumnType("image");
        });

        modelBuilder.Entity<ProdPadTb>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.Code }).HasName("PK_ProdPadTb1");

            entity.ToTable("ProdPadTb");

            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .HasDefaultValue("");
            entity.Property(e => e.DelIdDt).HasColumnType("datetime");
            entity.Property(e => e.Descr).HasMaxLength(50);
            entity.Property(e => e.Img).HasColumnType("image");
            entity.Property(e => e.WithCode).HasColumnName("withCode");
        });

        modelBuilder.Entity<ProdServiceTb>(entity =>
        {
            entity.HasKey(e => e.SrvLink);

            entity.ToTable("ProdServiceTb");

            entity.HasIndex(e => e.DocNo, "IX_ProdServiceTb").IsUnique();

            entity.HasIndex(e => e.SrlNo, "IX_ProdServiceTb_1");

            entity.Property(e => e.SrvLink)
                .ValueGeneratedNever()
                .HasColumnName("srvLink");
            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.CrtdBy).HasMaxLength(10);
            entity.Property(e => e.CrtdTm).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMail");
            entity.Property(e => e.MobNo)
                .HasMaxLength(50)
                .HasColumnName("mobNo");
            entity.Property(e => e.ModiBy).HasMaxLength(50);
            entity.Property(e => e.SrlNo).HasMaxLength(50);
            entity.Property(e => e.SrvBranch)
                .HasMaxLength(10)
                .HasColumnName("srvBranch");
            entity.Property(e => e.SrvDescr)
                .HasMaxLength(150)
                .HasColumnName("srvDescr");
            entity.Property(e => e.SrvDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProvinceTb>(entity =>
        {
            entity.HasKey(e => e.ProvinceId);

            entity.ToTable("ProvinceTb");

            entity.HasIndex(e => e.ProvinceName, "IX_ProvinceTb").IsUnique();

            entity.Property(e => e.ProvinceId).ValueGeneratedNever();
            entity.Property(e => e.ProvinceName).HasMaxLength(50);
        });

        modelBuilder.Entity<ProvisionCmnTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProvisionCmnTb");

            entity.Property(e => e.Jvnum).HasColumnName("JVNum");
            entity.Property(e => e.PreFix).HasMaxLength(50);
            entity.Property(e => e.ProvisionDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProvisionDetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProvisionDetTb");
        });

        modelBuilder.Entity<PrvlgSrvrInfTb>(entity =>
        {
            entity.ToTable("PrvlgSrvrInfTb");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Db)
                .HasMaxLength(50)
                .HasColumnName("db");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PrvlgSrver).HasMaxLength(100);
            entity.Property(e => e.SvrUsr).HasMaxLength(30);
        });

        modelBuilder.Entity<PurchRegTb>(entity =>
        {
            entity.HasKey(e => e.RegNo);

            entity.ToTable("PurchRegTb");

            entity.HasIndex(e => new { e.SuppNo, e.Reference }, "IX_PurchRegTb").IsUnique();

            entity.Property(e => e.Amount).HasColumnType("decimal(12, 3)");
            entity.Property(e => e.InvDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Reference)
                .HasMaxLength(30)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<RechargeTrTb>(entity =>
        {
            entity.HasKey(e => e.WbTrId);

            entity.ToTable("RechargeTrTb");

            entity.Property(e => e.WbTrId).ValueGeneratedNever();
            entity.Property(e => e.Reference).HasMaxLength(15);
            entity.Property(e => e.SalesManCode).HasMaxLength(15);
            entity.Property(e => e.TrDate).HasColumnType("datetime");
            entity.Property(e => e.TrTime).HasColumnType("datetime");
            entity.Property(e => e.TransferAmt).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<RecoveredTab2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RecoveredTab#_2");

            entity.HasIndex(e => new { e.Status, e.ConversationGroupId, e.ConversationHandle, e.QueuingOrder }, "queue_clustered_index")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.Status, e.Priority, e.QueuingOrder, e.ConversationGroupId, e.ConversationHandle, e.ServiceId }, "queue_secondary_index").IsUnique();

            entity.Property(e => e.BinaryMessageBody).HasColumnName("binary_message_body");
            entity.Property(e => e.ConversationGroupId).HasColumnName("conversation_group_id");
            entity.Property(e => e.ConversationHandle).HasColumnName("conversation_handle");
            entity.Property(e => e.FragmentBitmap).HasColumnName("fragment_bitmap");
            entity.Property(e => e.FragmentSize).HasColumnName("fragment_size");
            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.MessageSequenceNumber).HasColumnName("message_sequence_number");
            entity.Property(e => e.MessageTypeId).HasColumnName("message_type_id");
            entity.Property(e => e.NextFragment).HasColumnName("next_fragment");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.QueuingOrder).HasColumnName("queuing_order");
            entity.Property(e => e.ServiceContractId).HasColumnName("service_contract_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Validation)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("validation");
        });

        modelBuilder.Entity<RemoteRegTb>(entity =>
        {
            entity.HasKey(e => e.StationPc);

            entity.ToTable("RemoteRegTb");

            entity.Property(e => e.StationPc)
                .HasMaxLength(50)
                .HasColumnName("StationPC");
            entity.Property(e => e.RfrshTm).HasColumnType("datetime");
            entity.Property(e => e.StartTm).HasColumnType("datetime");
            entity.Property(e => e.StationDescr).HasMaxLength(100);
        });

        modelBuilder.Entity<RemoteReqTb>(entity =>
        {
            entity.HasKey(e => new { e.RequestPc, e.StationPc });

            entity.ToTable("RemoteReqTb");

            entity.Property(e => e.RequestPc)
                .HasMaxLength(50)
                .HasColumnName("RequestPC");
            entity.Property(e => e.StationPc)
                .HasMaxLength(50)
                .HasColumnName("StationPC");
            entity.Property(e => e.ApprUser).HasMaxLength(10);
            entity.Property(e => e.ApprvdTm).HasColumnType("datetime");
            entity.Property(e => e.Clerk).HasMaxLength(10);
            entity.Property(e => e.Counter).HasMaxLength(10);
            entity.Property(e => e.CounterRfrshTm).HasColumnType("datetime");
            entity.Property(e => e.DoBell).HasColumnName("doBell");
            entity.Property(e => e.Msg).HasMaxLength(100);
            entity.Property(e => e.ProcessId).HasMaxLength(15);
            entity.Property(e => e.ProcessName).HasMaxLength(50);
            entity.Property(e => e.RequestDt).HasColumnType("datetime");
            entity.Property(e => e.Scrn).HasColumnType("image");
        });

        modelBuilder.Entity<RentedAccTb>(entity =>
        {
            entity.HasKey(e => e.PgrpId);

            entity.ToTable("RentedAccTb");

            entity.Property(e => e.PgrpId)
                .ValueGeneratedNever()
                .HasColumnName("PGrpId");
            entity.Property(e => e.IaccNo).HasColumnName("IAccNo");
            entity.Property(e => e.LaccNo).HasColumnName("LAccNo");
        });

        modelBuilder.Entity<RfrshRequestTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RfrshRequestTb");

            entity.HasIndex(e => e.StartDttm, "IX_RfrshRequestTb");

            entity.Property(e => e.ActionDt).HasColumnType("datetime");
            entity.Property(e => e.ActionNo).HasComment("0 - Normal (based on last blockdt) 1 - Including Last Block ranage, 2 - All, 3 -  After given date");
            entity.Property(e => e.DoInvOrBoth).HasColumnName("doInvOrBoth");
            entity.Property(e => e.Server).HasMaxLength(50);
            entity.Property(e => e.StartDttm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("StartDTTm");
        });

        modelBuilder.Entity<Right>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.IsMenus, e.ProcessCode }, "IX_Rights").IsClustered();

            entity.Property(e => e.ProcessCode).HasMaxLength(15);
            entity.Property(e => e.RightYn).HasColumnName("RightYN");
        });

        modelBuilder.Entity<RightNode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RightNode");

            entity.HasIndex(e => e.ProcessCode, "IX_RightNode");

            entity.Property(e => e.DefRight).HasColumnName("defRight");
            entity.Property(e => e.Description).HasMaxLength(80);
            entity.Property(e => e.IsTag).HasColumnName("isTag");
            entity.Property(e => e.ProcessCode).HasMaxLength(15);
        });

        modelBuilder.Entity<RptBranchTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RptBranchTb");

            entity.Property(e => e.BrId).HasMaxLength(10);
            entity.Property(e => e.CompuName).HasMaxLength(30);
            entity.Property(e => e.RptTp).HasMaxLength(10);
        });

        modelBuilder.Entity<RptCmnTb>(entity =>
        {
            entity.HasKey(e => e.RptType);

            entity.ToTable("RptCmnTb");

            entity.Property(e => e.RptType).HasMaxLength(10);
            entity.Property(e => e.DefCustRptName).HasMaxLength(30);
            entity.Property(e => e.IsCustom).HasDefaultValue(false);
            entity.Property(e => e.RptTypeName).HasMaxLength(80);
        });

        modelBuilder.Entity<RptCmnXltb>(entity =>
        {
            entity.HasKey(e => e.XlrptNo);

            entity.ToTable("RptCmnXLTb");

            entity.Property(e => e.XlrptNo)
                .ValueGeneratedNever()
                .HasColumnName("XLRptNo");
            entity.Property(e => e.IsPublic).HasDefaultValue(true);
            entity.Property(e => e.XlrptName)
                .HasMaxLength(80)
                .HasColumnName("XLRptName");
            entity.Property(e => e.XlrptTp)
                .HasMaxLength(50)
                .HasColumnName("XLRptTp");
        });

        modelBuilder.Entity<RptCustTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RptCustTb");

            entity.HasIndex(e => new { e.CustRptName, e.CustRptType, e.CustPath }, "IX_RptCustTb").IsUnique();

            entity.Property(e => e.BranchId).HasMaxLength(10);
            entity.Property(e => e.CustPath).HasMaxLength(250);
            entity.Property(e => e.CustRptCaption).HasMaxLength(80);
            entity.Property(e => e.CustRptName).HasMaxLength(30);
            entity.Property(e => e.CustRptType).HasMaxLength(10);
            entity.Property(e => e.IsAtSharePath).HasDefaultValue(true);
            entity.Property(e => e.RptFileMtm)
                .HasColumnType("datetime")
                .HasColumnName("RptFileMTm");
            entity.Property(e => e.UpdtdTm).HasColumnType("datetime");
        });

        modelBuilder.Entity<RptDetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RptDetTb");

            entity.HasIndex(e => e.RptNo, "IX_RptDetTb");

            entity.Property(e => e.RptCaption).HasMaxLength(80);
            entity.Property(e => e.RptName).HasMaxLength(30);
            entity.Property(e => e.RptType).HasMaxLength(10);
        });

        modelBuilder.Entity<RptListTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RptListTb");

            entity.HasIndex(e => new { e.RptCode, e.ModuleCode, e.UserId }, "IX_RptListTb").IsUnique();

            entity.Property(e => e.ModuleCode).HasMaxLength(30);
            entity.Property(e => e.RptCode).HasMaxLength(10);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("UserID");
            entity.Property(e => e.Visible).HasDefaultValue(true);
        });

        modelBuilder.Entity<RptLocalDef>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RptLocalDef");

            entity.HasIndex(e => new { e.CompuName, e.RptType }, "IX_RptLocalDef")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.CompuName).HasMaxLength(30);
            entity.Property(e => e.DefCustRptName).HasMaxLength(30);
            entity.Property(e => e.RptType).HasMaxLength(10);
        });

        modelBuilder.Entity<RptUnqXltb>(entity =>
        {
            entity.HasKey(e => e.XlunqNo).HasName("PK_RptDetXLTb");

            entity.ToTable("RptUnqXLTb");

            entity.Property(e => e.XlunqNo)
                .ValueGeneratedNever()
                .HasColumnName("XLUnqNo");
            entity.Property(e => e.ConStr).HasMaxLength(200);
            entity.Property(e => e.Xldescription)
                .HasMaxLength(100)
                .HasColumnName("XLDescription");
            entity.Property(e => e.XlfileObj).HasColumnName("XLFileObj");
            entity.Property(e => e.Xlname)
                .HasMaxLength(100)
                .HasColumnName("XLName");
            entity.Property(e => e.XlrptNo).HasColumnName("XLRptNo");
        });

        modelBuilder.Entity<S1accHd>(entity =>
        {
            entity.HasKey(e => e.S1accId);

            entity.ToTable("S1AccHd");

            entity.Property(e => e.S1accId)
                .ValueGeneratedNever()
                .HasColumnName("S1AccId");
            entity.Property(e => e.ContractGrpId).HasMaxLength(10);
            entity.Property(e => e.Descr).HasMaxLength(50);
            entity.Property(e => e.GrpSetOn).HasMaxLength(10);
            entity.Property(e => e.IsContractGrp).HasColumnName("isContractGrp");
            entity.Property(e => e.MaccId).HasColumnName("MAccId");
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SalInfTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SalInfTb");

            entity.Property(e => e.DesgnId)
                .HasMaxLength(10)
                .HasColumnName("DesgnID");
            entity.Property(e => e.Designation).HasMaxLength(40);
            entity.Property(e => e.Hra).HasColumnName("HRA");
            entity.Property(e => e.SalDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<SalesmanTb>(entity =>
        {
            entity.HasKey(e => e.SmanCode);

            entity.ToTable("SalesmanTb");

            entity.Property(e => e.SmanCode)
                .HasMaxLength(10)
                .HasColumnName("SManCode");
            entity.Property(e => e.Address1).HasMaxLength(30);
            entity.Property(e => e.Address2).HasMaxLength(30);
            entity.Property(e => e.DoHide).HasColumnName("doHide");
            entity.Property(e => e.SmanName)
                .HasMaxLength(30)
                .HasColumnName("SManName");
            entity.Property(e => e.Tel).HasMaxLength(30);
        });

        modelBuilder.Entity<ScaleSttgTb>(entity =>
        {
            entity.HasKey(e => e.UnqNo);

            entity.ToTable("ScaleSttgTb");

            entity.Property(e => e.Bctype).HasColumnName("BCType");
            entity.Property(e => e.BcwithQty).HasColumnName("BCWithQty");
            entity.Property(e => e.CodeLen).HasDefaultValue((byte)7);
            entity.Property(e => e.TtlCodeLen).HasDefaultValue((byte)13);
        });

        modelBuilder.Entity<ScanProdTb>(entity =>
        {
            entity.HasKey(e => new { e.RecNo, e.Device });

            entity.ToTable("ScanProdTb");

            entity.Property(e => e.Device)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Bc)
                .HasMaxLength(50)
                .HasColumnName("BC");
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.ScanTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.User).HasMaxLength(50);
        });

        modelBuilder.Entity<SdepoDetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SDepoDetTb");

            entity.Property(e => e.InsMonth).HasColumnType("datetime");
            entity.Property(e => e.Pamount).HasColumnName("PAmount");
        });

        modelBuilder.Entity<SdepoTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SDepoTb");

            entity.Property(e => e.SecRemark).HasMaxLength(30);
            entity.Property(e => e.SecuDt).HasColumnType("datetime");
            entity.Property(e => e.SecuEdt)
                .HasColumnType("datetime")
                .HasColumnName("SecuEDt");
        });

        modelBuilder.Entity<SessnItem>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<ShareSrvrInfTb>(entity =>
        {
            entity.ToTable("ShareSrvrInfTb");

            entity.Property(e => e.Db)
                .HasMaxLength(50)
                .HasColumnName("db");
            entity.Property(e => e.LocalDb).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.ShareSrver).HasMaxLength(100);
            entity.Property(e => e.SvrUsr).HasMaxLength(30);
            entity.Property(e => e.TbPreFix).HasMaxLength(10);
        });

        modelBuilder.Entity<Sheet1>(entity =>
        {
            entity.ToTable("Sheet1$");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AccId).HasMaxLength(255);
            entity.Property(e => e.DocDate).HasColumnType("datetime");
            entity.Property(e => e.DocNo).HasMaxLength(255);
            entity.Property(e => e.Narration).HasMaxLength(255);
            entity.Property(e => e.PdcAmt).HasColumnName("Pdc#Amt");
            entity.Property(e => e.Reference).HasMaxLength(255);
        });

        modelBuilder.Entity<ShpgGrpTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ShpgGrpTb");

            entity.HasIndex(e => e.ShpgGrpCode, "IX_Table_GrpCode").IsUnique();

            entity.HasIndex(e => e.ShpgGrpId, "IX_Table_GrpId").IsUnique();

            entity.Property(e => e.CreatedBy).HasMaxLength(10);
            entity.Property(e => e.CreatedDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShpgGrpCode).HasMaxLength(20);
            entity.Property(e => e.ShpgGrpDt).HasColumnType("datetime");
            entity.Property(e => e.ShpgGrpName).HasMaxLength(50);
        });

        modelBuilder.Entity<ShpgItm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ShpgItm");

            entity.Property(e => e.Code).HasMaxLength(30);
            entity.Property(e => e.Pname)
                .HasMaxLength(80)
                .HasColumnName("PName");
            entity.Property(e => e.Ucost).HasColumnName("UCost");
            entity.Property(e => e.Udisc).HasColumnName("UDisc");
            entity.Property(e => e.Unit).HasMaxLength(10);
            entity.Property(e => e.Uocost).HasColumnName("UOCost");
        });

        modelBuilder.Entity<ShpgTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ShpgTb");

            entity.HasIndex(e => new { e.ShpgGrpId, e.ConsgnId }, "IX_ShpgTb").IsUnique();

            entity.Property(e => e.Blno)
                .HasMaxLength(30)
                .HasColumnName("BLNo");
            entity.Property(e => e.ConsgnId)
                .HasMaxLength(30)
                .HasColumnName("ConsgnID");
            entity.Property(e => e.InvNo).HasMaxLength(30);
            entity.Property(e => e.PortOfDischarge).HasMaxLength(30);
            entity.Property(e => e.PortOfLdg).HasMaxLength(30);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("New");
            entity.Property(e => e.Supplier).HasMaxLength(80);
        });

        modelBuilder.Entity<SpTaxtb>(entity =>
        {
            entity.HasKey(e => e.SpTaxno);

            entity.ToTable("SpTAXTb");

            entity.Property(e => e.SpTaxno).HasColumnName("SpTAXNo");
            entity.Property(e => e.Descr).HasMaxLength(80);
            entity.Property(e => e.Per).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SpTaxcalcMthd).HasColumnName("SpTAXCalcMthd");
            entity.Property(e => e.SpTaxfrom)
                .HasColumnType("datetime")
                .HasColumnName("SpTAXFrom");
            entity.Property(e => e.SpTaxid)
                .HasMaxLength(10)
                .HasColumnName("SpTAXId");
            entity.Property(e => e.SpTaxto)
                .HasColumnType("datetime")
                .HasColumnName("SpTAXTo");
        });

        modelBuilder.Entity<SuppPrdTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SuppPrdTb");

            entity.HasIndex(e => new { e.SupplierNo, e.ItemId }, "IX_SuppPrdTb").IsUnique();

            entity.Property(e => e.Ic)
                .HasMaxLength(30)
                .HasColumnName("IC");
        });

        modelBuilder.Entity<SysPara>(entity =>
        {
            entity.HasKey(e => e.ProcessCode);

            entity.ToTable("SysPara");

            entity.Property(e => e.ProcessCode).HasMaxLength(15);
            entity.Property(e => e.DefValue).HasColumnName("defValue");
            entity.Property(e => e.Description).HasMaxLength(80);
        });

        modelBuilder.Entity<SysParaOpt>(entity =>
        {
            entity.HasKey(e => e.ModuleId);

            entity.ToTable("SysParaOpt");

            entity.Property(e => e.ModuleId).HasMaxLength(15);
            entity.Property(e => e.OptValue).HasColumnName("optValue");
        });

        modelBuilder.Entity<SysTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SysTb");

            entity.Property(e => e.AccPeriodFrm).HasColumnType("datetime");
            entity.Property(e => e.AccPeriodTo).HasColumnType("datetime");
            entity.Property(e => e.ActiveBranch).HasMaxLength(10);
            entity.Property(e => e.Addr1).HasMaxLength(60);
            entity.Property(e => e.Addr2).HasMaxLength(60);
            entity.Property(e => e.Addr3).HasMaxLength(60);
            entity.Property(e => e.BasicCurrencyId).HasMaxLength(5);
            entity.Property(e => e.CompName).HasMaxLength(100);
            entity.Property(e => e.CounterDb).HasMaxLength(50);
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CrLmtId).HasColumnName("CrLmtID");
            entity.Property(e => e.CustKey).HasMaxLength(50);
            entity.Property(e => e.DProvinceNo).HasColumnName("dProvinceNo");
            entity.Property(e => e.Dccrtble).HasColumnName("DCCrtble");
            entity.Property(e => e.DefIc)
                .HasMaxLength(30)
                .HasDefaultValueSql("((1000))")
                .HasColumnName("DefIC");
            entity.Property(e => e.DefLoc).HasMaxLength(10);
            entity.Property(e => e.DefLocName).HasMaxLength(30);
            entity.Property(e => e.DtLstBrUpdtd).HasColumnType("datetime");
            entity.Property(e => e.EanstartWith)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("EANStartWith");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.EmailDb)
                .HasMaxLength(50)
                .HasDefaultValue("EMailDb")
                .HasColumnName("EMailDb");
            entity.Property(e => e.EquityGrpOfBS).HasColumnName("EquityGrpOfB&S");
            entity.Property(e => e.EquityGrpOfBSdescr)
                .HasMaxLength(50)
                .HasColumnName("EquityGrpOfB&SDescr");
            entity.Property(e => e.FixStockValuesPl).HasColumnName("FixStockValues@PL");
            entity.Property(e => e.ImgLogo)
                .HasColumnType("image")
                .HasColumnName("imgLogo");
            entity.Property(e => e.IsHo)
                .HasDefaultValue(true)
                .HasColumnName("IsHO");
            entity.Property(e => e.IsLinkedPos).HasColumnName("IsLinkedPOS");
            entity.Property(e => e.LnkdPosbrDb)
                .HasMaxLength(50)
                .HasColumnName("LnkdPOSBrDb");
            entity.Property(e => e.LnkdPosbrServer)
                .HasMaxLength(50)
                .HasColumnName("LnkdPOSBrServer");
            entity.Property(e => e.LogDbName).HasMaxLength(50);
            entity.Property(e => e.LsaddAllw1).HasColumnName("LSAddAllw1");
            entity.Property(e => e.LsaddAllw2).HasColumnName("LSAddAllw2");
            entity.Property(e => e.LsaddAllw3).HasColumnName("LSAddAllw3");
            entity.Property(e => e.LsaddAllw4).HasColumnName("LSAddAllw4");
            entity.Property(e => e.LsaddAllw5).HasColumnName("LSAddAllw5");
            entity.Property(e => e.LsaddHra).HasColumnName("LSAddHRA");
            entity.Property(e => e.LsaddTpt).HasColumnName("LSAddTpt");
            entity.Property(e => e.LvSwithHra).HasColumnName("LvSWithHRA");
            entity.Property(e => e.MaxPerPrvlgIi).HasColumnName("MaxPerPrvlgII");
            entity.Property(e => e.MaxRvdisc).HasColumnName("MaxRVDisc");
            entity.Property(e => e.Msg)
                .HasMaxLength(60)
                .HasDefaultValue("EMailDb");
            entity.Property(e => e.NstkEnd).HasColumnName("NStkEND");
            entity.Property(e => e.NstkOpn).HasColumnName("NStkOPN");
            entity.Property(e => e.OtonlyBp).HasColumnName("OTOnlyBP");
            entity.Property(e => e.PdalstUsdDt)
                .HasColumnType("datetime")
                .HasColumnName("PDALstUsdDt");
            entity.Property(e => e.Pdbno).HasColumnName("PDBNo");
            entity.Property(e => e.PoschgDtTm)
                .HasDefaultValue(new DateTime(1900, 1, 1, 2, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime")
                .HasColumnName("POSChgDtTm");
            entity.Property(e => e.Posdate)
                .HasColumnType("datetime")
                .HasColumnName("POSDate");
            entity.Property(e => e.Prnno)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("PRNNo");
            entity.Property(e => e.ProdctnDt).HasColumnType("datetime");
            entity.Property(e => e.ProtectUntil).HasColumnType("datetime");
            entity.Property(e => e.PurRndFra)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("purRndFra");
            entity.Property(e => e.PurRndIndex).HasColumnName("purRndIndex");
            entity.Property(e => e.Qsmsactvate).HasColumnName("QSMSActvate");
            entity.Property(e => e.Qsmsmsg).HasColumnName("QSMSMsg");
            entity.Property(e => e.Qsmspass)
                .HasMaxLength(15)
                .HasColumnName("QSMSPass");
            entity.Property(e => e.Qsmsurl)
                .HasMaxLength(150)
                .HasColumnName("QSMSURL");
            entity.Property(e => e.SlsRndFra)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("slsRndFra");
            entity.Property(e => e.SlsRndIndex).HasColumnName("slsRndIndex");
            entity.Property(e => e.StkEnd).HasColumnName("StkEND");
            entity.Property(e => e.StkOpn).HasColumnName("StkOPN");
            entity.Property(e => e.TaxStDt)
                .HasDefaultValue(new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime");
            entity.Property(e => e.Taxlvl).HasColumnName("TAXLvl");
            entity.Property(e => e.Tel1).HasMaxLength(50);
            entity.Property(e => e.Tel2).HasMaxLength(50);
            entity.Property(e => e.TestMsg1).HasMaxLength(50);
            entity.Property(e => e.TregNo).HasColumnName("TRegNo");
            entity.Property(e => e.Trnno)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("TRNNo");
            entity.Property(e => e.WarnPdc).HasColumnName("WarnPDC");
            entity.Property(e => e.WcfullAllw1).HasColumnName("WCFullAllw1");
            entity.Property(e => e.WcfullAllw2).HasColumnName("WCFullAllw2");
            entity.Property(e => e.WcfullAllw3).HasColumnName("WCFullAllw3");
            entity.Property(e => e.WcfullAllw4).HasColumnName("WCFullAllw4");
            entity.Property(e => e.WcfullAllw5).HasColumnName("WCFullAllw5");
            entity.Property(e => e.WcfullHra).HasColumnName("WCFullHRA");
            entity.Property(e => e.WcfullTpt).HasColumnName("WCFullTpt");
            entity.Property(e => e.Www)
                .HasMaxLength(50)
                .HasColumnName("WWW");
        });

        modelBuilder.Entity<TargetDocDtb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TargetDocDTb");

            entity.Property(e => e.ApplyMonth).HasColumnType("datetime");
            entity.Property(e => e.DelDt).HasColumnType("datetime");
            entity.Property(e => e.Smcode)
                .HasMaxLength(50)
                .HasColumnName("SMCode");
            entity.Property(e => e.TargetAmt).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<TargetDocTb>(entity =>
        {
            entity.HasKey(e => e.DocNo);

            entity.ToTable("TargetDocTb");

            entity.Property(e => e.DocNo).ValueGeneratedNever();
            entity.Property(e => e.CrtdBy).HasMaxLength(10);
            entity.Property(e => e.CrtdTm).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.DocDt).HasColumnType("datetime");
            entity.Property(e => e.ModiBy).HasMaxLength(10);
            entity.Property(e => e.ModiTm).HasColumnType("datetime");
            entity.Property(e => e.OrdDate).HasColumnType("datetime");
            entity.Property(e => e.OrdRef).HasMaxLength(30);
        });

        modelBuilder.Entity<TaxsttlDetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TAXSttlDetTb");
        });

        modelBuilder.Entity<TaxtpTb>(entity =>
        {
            entity.HasKey(e => e.TaxtypeNo);

            entity.ToTable("TAXTpTb");

            entity.HasIndex(e => e.TaxtypeCode, "IX_TAXTpTb").IsUnique();

            entity.Property(e => e.TaxtypeNo)
                .ValueGeneratedNever()
                .HasColumnName("TAXTypeNo");
            entity.Property(e => e.IsTaxonTax).HasColumnName("isTAXonTAX");
            entity.Property(e => e.TaxtypeCode)
                .HasMaxLength(10)
                .HasColumnName("TAXTypeCode");
        });

        modelBuilder.Entity<TempTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TempTb");

            entity.Property(e => e.ConfCode).HasMaxLength(50);
            entity.Property(e => e.DtFrm).HasColumnType("datetime");
            entity.Property(e => e.DtSpRestr).HasColumnType("datetime");
        });

        modelBuilder.Entity<TermsTb>(entity =>
        {
            entity.HasKey(e => e.TermsId);

            entity.ToTable("TermsTb");

            entity.Property(e => e.TermsId).HasMaxLength(15);
            entity.Property(e => e.Ndays).HasColumnName("NDays");
            entity.Property(e => e.Nmonths).HasColumnName("NMonths");
            entity.Property(e => e.TermsDescr).HasMaxLength(50);
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TmmCountryTb>(entity =>
        {
            entity.ToTable("tmmCountryTb");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(10)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .HasColumnName("currency");
            entity.Property(e => e.CurrencyAbbreviation)
                .HasMaxLength(10)
                .HasColumnName("currencyAbbreviation");
            entity.Property(e => e.Extension).HasColumnName("extension");
            entity.Property(e => e.ImageName)
                .HasMaxLength(150)
                .HasColumnName("imageName");
            entity.Property(e => e.IsFavourite).HasColumnName("isFavourite");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NumberLength).HasColumnName("numberLength");
        });

        modelBuilder.Entity<TmmPlanTb>(entity =>
        {
            entity.HasKey(e => e.PlanId);

            entity.ToTable("TmmPlanTb");

            entity.Property(e => e.PlanId).ValueGeneratedNever();
            entity.Property(e => e.Commission).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.CrtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModiTm).HasColumnType("datetime");
            entity.Property(e => e.Mrp).HasColumnName("MRP");
            entity.Property(e => e.Pname)
                .HasMaxLength(100)
                .HasColumnName("PName");
            entity.Property(e => e.SscId).HasColumnName("sscId");
            entity.Property(e => e.TmmPrdCode).HasMaxLength(50);
            entity.Property(e => e.VcprsProdNo).HasColumnName("VCPrsProdNo");
        });

        modelBuilder.Entity<TmmPrdSaleCmn>(entity =>
        {
            entity.HasKey(e => e.UnqNo);

            entity.ToTable("TmmPrdSaleCmn");

            entity.Property(e => e.Amt).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BeneficiaryNo).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CrtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Fc)
                .HasMaxLength(10)
                .HasColumnName("FC");
            entity.Property(e => e.Fcamt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("FCAmt");
            entity.Property(e => e.Lc)
                .HasMaxLength(10)
                .HasColumnName("LC");
            entity.Property(e => e.Operator).HasMaxLength(50);
            entity.Property(e => e.Package).HasMaxLength(30);
            entity.Property(e => e.Qty).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SysDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(50);
        });

        modelBuilder.Entity<TmmProdGrpTb>(entity =>
        {
            entity.HasKey(e => e.SscId).HasName("PK_TmmProdTb");

            entity.ToTable("TmmProdGrpTb");

            entity.Property(e => e.SscId)
                .ValueGeneratedNever()
                .HasColumnName("sscId");
            entity.Property(e => e.AKey)
                .ValueGeneratedOnAdd()
                .HasColumnName("aKey");
            entity.Property(e => e.CrtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FlDtBttn).HasColumnType("datetime");
            entity.Property(e => e.FlDtPrn).HasColumnType("datetime");
            entity.Property(e => e.IdBttnImgPath).HasMaxLength(200);
            entity.Property(e => e.IdPrnImgPath).HasMaxLength(200);
            entity.Property(e => e.ModiTm).HasColumnType("datetime");
            entity.Property(e => e.RcprsProdNo).HasColumnName("RCPrsProdNo");
            entity.Property(e => e.ServiceCategory)
                .HasMaxLength(50)
                .HasColumnName("service_category");
            entity.Property(e => e.ServiceSubCategory)
                .HasMaxLength(50)
                .HasColumnName("service_sub_category");
            entity.Property(e => e.ServiceSubType)
                .HasMaxLength(50)
                .HasColumnName("service_sub_type");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(15)
                .HasColumnName("service_type");
        });

        modelBuilder.Entity<TmmStng>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DeviceId).HasMaxLength(50);
            entity.Property(e => e.DeviceKey)
                .HasMaxLength(30)
                .HasColumnName("deviceKey");
            entity.Property(e => e.EmailId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("emailId");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("lastName");
            entity.Property(e => e.M2Mid)
                .HasMaxLength(30)
                .HasColumnName("m2MId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ParentContact)
                .HasMaxLength(30)
                .HasColumnName("parentContact");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneLandline)
                .HasMaxLength(30)
                .HasColumnName("phoneLandline");
            entity.Property(e => e.PhoneMobile)
                .HasMaxLength(30)
                .HasColumnName("phoneMobile");
            entity.Property(e => e.PrintTitle)
                .HasMaxLength(100)
                .HasColumnName("printTitle");
            entity.Property(e => e.ShopAddress)
                .HasMaxLength(100)
                .HasColumnName("shopAddress");
            entity.Property(e => e.ShopName)
                .HasMaxLength(100)
                .HasColumnName("shopName");
            entity.Property(e => e.Token).HasMaxLength(500);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserType)
                .HasMaxLength(30)
                .HasColumnName("userType");
        });

        modelBuilder.Entity<TmpAccImg>(entity =>
        {
            entity.HasKey(e => e.AccountNo);

            entity.ToTable("tmpAccImg");

            entity.Property(e => e.AccountNo).ValueGeneratedNever();
            entity.Property(e => e.AccBar).HasColumnType("image");
            entity.Property(e => e.AccId).HasMaxLength(10);
        });

        modelBuilder.Entity<TmpAssCompnt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpAssCompnt");

            entity.HasIndex(e => new { e.Dt, e.PSlNo, e.SlNo }, "IX_tmpAssCompnt").IsUnique();

            entity.Property(e => e.Dt).HasColumnType("datetime");
            entity.Property(e => e.ItemClass)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.PSlNo).HasColumnName("pSlNo");
            entity.Property(e => e.Pfraction).HasColumnName("PFraction");
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        modelBuilder.Entity<TmpDayActRptTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpDayActRptTb");

            entity.Property(e => e.CrDescr).HasMaxLength(80);
            entity.Property(e => e.CrEdescr)
                .HasMaxLength(250)
                .HasColumnName("CrEDescr");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.CrtdTm).HasColumnType("datetime");
            entity.Property(e => e.DrDescr).HasMaxLength(80);
            entity.Property(e => e.DrEdescr)
                .HasMaxLength(250)
                .HasColumnName("DrEDescr");
            entity.Property(e => e.Ob).HasColumnName("OB");
            entity.Property(e => e.TypeName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TmpDayTrTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpDayTrTb");

            entity.Property(e => e.CrtdTm).HasColumnType("datetime");
            entity.Property(e => e.EntryRef).HasMaxLength(250);
            entity.Property(e => e.Jvdate)
                .HasColumnType("datetime")
                .HasColumnName("JVDate");
            entity.Property(e => e.Jvnum).HasColumnName("JVNum");
            entity.Property(e => e.Jvtype)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("JVType");
            entity.Property(e => e.PreFix)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TmpPhyDetTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpPhyDetTb");

            entity.HasIndex(e => e.PhyNo, "IX_tmpPhyDetTb");

            entity.HasIndex(e => e.TRecNo, "IX_tmpPhyDetTb_1").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(30);
            entity.Property(e => e.ExpDt).HasColumnType("datetime");
            entity.Property(e => e.FlName).HasMaxLength(50);
            entity.Property(e => e.ItmC).HasMaxLength(30);
            entity.Property(e => e.ItmN).HasMaxLength(80);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.Pcname)
                .HasMaxLength(50)
                .HasColumnName("PCName");
            entity.Property(e => e.Pfraction).HasColumnName("PFraction");
            entity.Property(e => e.SExpDt)
                .HasMaxLength(50)
                .HasColumnName("sExpDt");
            entity.Property(e => e.ScanTm).HasColumnType("datetime");
            entity.Property(e => e.StkTakenDt)
                .HasColumnType("datetime")
                .HasColumnName("stkTakenDt");
            entity.Property(e => e.StkTakenQty).HasColumnName("stkTakenQty");
            entity.Property(e => e.SysBranch)
                .HasMaxLength(10)
                .HasColumnName("sysBranch");
            entity.Property(e => e.SysLocation)
                .HasMaxLength(20)
                .HasColumnName("sysLocation");
            entity.Property(e => e.TRecNo).HasColumnName("tRecNo");
            entity.Property(e => e.Unit).HasMaxLength(10);
        });

        modelBuilder.Entity<TmpPhySmmTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpPhySmmTb");

            entity.HasIndex(e => new { e.PhyNo, e.BaseId, e.Pcname, e.SysBranch }, "IX_tmpPhySmmTb").IsUnique();

            entity.Property(e => e.Pcname)
                .HasMaxLength(50)
                .HasColumnName("PCName");
            entity.Property(e => e.Pqty).HasColumnName("PQty");
            entity.Property(e => e.Qih).HasColumnName("QIH");
            entity.Property(e => e.SysBranch)
                .HasMaxLength(10)
                .HasColumnName("sysBranch");
        });

        modelBuilder.Entity<TmpPmr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpPMR");

            entity.Property(e => e.CalcIpper)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CalcIPPer");
            entity.Property(e => e.FistrId).HasColumnName("FISTrId");
            entity.Property(e => e.Ipqty)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("IPQty");
            entity.Property(e => e.IptrId).HasColumnName("IPTrId");
            entity.Property(e => e.ListrId).HasColumnName("LISTrId");
            entity.Property(e => e.NDays).HasColumnName("nDays");
            entity.Property(e => e.Pmr)
                .HasColumnType("decimal(10, 5)")
                .HasColumnName("PMR");
            entity.Property(e => e.Qih)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("QIH");
            entity.Property(e => e.Qihdt)
                .HasColumnType("datetime")
                .HasColumnName("QIHDt");
            entity.Property(e => e.SoldOutProjection).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SoldQty).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.UnqDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<TmpQuickSldgr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpQuickSLdgr");

            entity.Property(e => e.CrtdDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dbname)
                .HasMaxLength(50)
                .HasColumnName("DBName");
            entity.Property(e => e.Dt).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(30);
            entity.Property(e => e.Rno).HasColumnName("RNo");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Unit).HasMaxLength(10);
            entity.Property(e => e.VrNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vr No");
        });

        modelBuilder.Entity<TmpQuickStmnt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpQuickStmnt");

            entity.HasIndex(e => new { e.SlNo, e.LoginId }, "IX_tmpQuickStmnt");

            entity.Property(e => e.ChqDate).HasColumnType("datetime");
            entity.Property(e => e.CrtdDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dbname)
                .HasMaxLength(50)
                .HasColumnName("DBName");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Dt).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(30);
            entity.Property(e => e.Type)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.VrNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vr No");
            entity.Property(e => e.WalletTr).HasColumnType("decimal(12, 4)");
        });

        modelBuilder.Entity<TmpUnqDt>(entity =>
        {
            entity.HasKey(e => e.Dt);

            entity.ToTable("tmpUnqDt");

            entity.Property(e => e.Dt).HasColumnType("datetime");
            entity.Property(e => e.ChkUsingDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TmpXlimpInv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tmpXLImpInv");

            entity.HasIndex(e => e.XlprodCode, "IX_tmpXLImpInv");

            entity.Property(e => e.SysDoDelDt).HasColumnType("datetime");
            entity.Property(e => e.SysDtTm).HasColumnType("datetime");
            entity.Property(e => e.SysXlimportedId).HasColumnName("SysXLImportedId");
            entity.Property(e => e.Xlacost).HasColumnName("XLACost");
            entity.Property(e => e.Xlbcode)
                .HasMaxLength(50)
                .HasColumnName("XLBCode");
            entity.Property(e => e.Xldescription)
                .HasMaxLength(80)
                .HasColumnName("XLDescription");
            entity.Property(e => e.XlisNew).HasColumnName("XLIsNew");
            entity.Property(e => e.XllnDisc)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("XLLnDisc%");
            entity.Property(e => e.XllnDisc1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("XLLnDisc");
            entity.Property(e => e.XlprodCode)
                .HasMaxLength(30)
                .HasColumnName("XLProdCode");
            entity.Property(e => e.Xlqty).HasColumnName("XLQty");
            entity.Property(e => e.Xlunit)
                .HasMaxLength(10)
                .HasColumnName("XLUnit");
            entity.Property(e => e.XlunitVal).HasColumnName("XLUnitVal");
        });

        modelBuilder.Entity<TrEdtExcmptTb>(entity =>
        {
            entity.HasKey(e => e.ExcemptId);

            entity.ToTable("TrEdtExcmptTb");

            entity.Property(e => e.ExcemptTp).HasComment("0 - except specific doc, 1 - within a range for specific type,, 2 - within a range");
            entity.Property(e => e.PrdFrom)
                .HasColumnType("datetime")
                .HasColumnName("prdFrom");
            entity.Property(e => e.PrdTo)
                .HasColumnType("datetime")
                .HasColumnName("prdTo");
            entity.Property(e => e.SInvNo)
                .HasMaxLength(25)
                .HasColumnName("sInvNo");
            entity.Property(e => e.TrType).HasMaxLength(5);
        });

        modelBuilder.Entity<TrdgPospay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TrdgPOSPay");

            entity.HasIndex(e => e.TrId, "IX_TrdgPOSPay");

            entity.Property(e => e.CardName).HasMaxLength(40);
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsRv).HasColumnName("IsRV");
            entity.Property(e => e.PayType).HasMaxLength(50);
            entity.Property(e => e.Pfid).HasColumnName("PFId");
            entity.Property(e => e.SlNo).HasDefaultValue(0);
            entity.Property(e => e.SlsMan).HasMaxLength(10);
        });

        modelBuilder.Entity<UniqInvTb>(entity =>
        {
            entity.HasKey(e => e.UnqInvId);

            entity.ToTable("UniqInvTb");

            entity.Property(e => e.UnqInvId)
                .HasMaxLength(26)
                .HasDefaultValue("");
            entity.Property(e => e.Jvdate)
                .HasColumnType("datetime")
                .HasColumnName("JVDate");
        });

        modelBuilder.Entity<UniqInvTb1>(entity =>
        {
            entity.HasKey(e => e.UnqInvId);

            entity.ToTable("UniqInvTb1");

            entity.Property(e => e.UnqInvId)
                .HasMaxLength(16)
                .HasDefaultValue("");
            entity.Property(e => e.Jvdate)
                .HasColumnType("datetime")
                .HasColumnName("JVDate");
        });

        modelBuilder.Entity<UnitsTb>(entity =>
        {
            entity.HasKey(e => e.Units);

            entity.ToTable("UnitsTb");

            entity.Property(e => e.Units).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(30);
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<UnqOthDocTb>(entity =>
        {
            entity.HasKey(e => new { e.Tp, e.DocNo });

            entity.ToTable("UnqOthDocTb");

            entity.Property(e => e.Tp).HasMaxLength(10);
            entity.Property(e => e.DocDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<UpdtdStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UpdtdStatus");

            entity.Property(e => e.MasterNo).HasComment("0-Leavel & Group detail, 1 - Bank, 2- Unit");
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<UpdtdStatus4IndCntr>(entity =>
        {
            entity.HasKey(e => e.MasterStr);

            entity.ToTable("UpdtdStatus4IndCntr");

            entity.Property(e => e.MasterStr).HasMaxLength(20);
            entity.Property(e => e.UpdtdTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<UpdtdStatusDeleted>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UpdtdStatusDeleted");

            entity.Property(e => e.Code).HasMaxLength(30);
            entity.Property(e => e.DeltedTm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descr).HasMaxLength(80);
            entity.Property(e => e.ItemKey).HasMaxLength(10);
        });

        modelBuilder.Entity<UserPostb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserPOSTb");

            entity.Property(e => e.PostypeId).HasColumnName("POSTypeId");
        });

        modelBuilder.Entity<UsrBr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsrBr");

            entity.Property(e => e.BrId).HasMaxLength(10);
        });

        modelBuilder.Entity<UwaccsTb>(entity =>
        {
            entity.HasKey(e => e.AccountNo);

            entity.ToTable("UWAccsTb");

            entity.Property(e => e.AccountNo).ValueGeneratedNever();
            entity.Property(e => e.Remark).HasMaxLength(150);
        });

        modelBuilder.Entity<UwitemsTb>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("UWItemsTb");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
            entity.Property(e => e.Remark).HasMaxLength(150);
        });

        modelBuilder.Entity<ValidChildTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ValidChildTb");

            entity.Property(e => e.Lcode).HasColumnName("LCode");
        });

        modelBuilder.Entity<VrCmn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VrCmn");

            entity.Property(e => e.Column0)
                .HasMaxLength(50)
                .HasColumnName("Column 0");
            entity.Property(e => e.Column1)
                .HasMaxLength(50)
                .HasColumnName("Column 1");
            entity.Property(e => e.Column2)
                .HasMaxLength(50)
                .HasColumnName("Column 2");
            entity.Property(e => e.Column3)
                .HasMaxLength(50)
                .HasColumnName("Column 3");
            entity.Property(e => e.Column4)
                .HasMaxLength(50)
                .HasColumnName("Column 4");
        });

        modelBuilder.Entity<WebModi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WebModi");

            entity.Property(e => e.FldObjId)
                .HasMaxLength(30)
                .HasDefaultValue("")
                .HasColumnName("FldObjID");
            entity.Property(e => e.ModiDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Wecmmn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WECmmn");

            entity.Property(e => e.AccUpdtd).HasDefaultValue(false);
            entity.Property(e => e.AdminExp).HasDefaultValue(0.0);
            entity.Property(e => e.BankAccNo).HasMaxLength(30);
            entity.Property(e => e.BankCode).HasMaxLength(10);
            entity.Property(e => e.BranchId).HasMaxLength(10);
            entity.Property(e => e.Crate).HasColumnName("CRate");
            entity.Property(e => e.Deposit).HasDefaultValue(0.0);
            entity.Property(e => e.Designation).HasMaxLength(40);
            entity.Property(e => e.Hra).HasColumnName("HRA");
            entity.Property(e => e.LosonEffect).HasColumnName("LOSOnEffect");
            entity.Property(e => e.LosonIssd).HasColumnName("LOSOnIssd");
            entity.Property(e => e.NWHrs).HasColumnName("N W Hrs");
            entity.Property(e => e.OtRate).HasColumnName("OT Rate");
            entity.Property(e => e.OtcalSal).HasColumnName("OTCalSal");
            entity.Property(e => e.OthRate).HasColumnName("OTH Rate");
            entity.Property(e => e.OtonlyBp).HasColumnName("OTOnlyBP");
            entity.Property(e => e.OtwageCmthd).HasColumnName("OTWageCMthd");
            entity.Property(e => e.OtwageHr).HasColumnName("OTWage/Hr");
            entity.Property(e => e.PaidLeave).HasColumnName("Paid Leave");
            entity.Property(e => e.PayDeduCap1).HasMaxLength(25);
            entity.Property(e => e.PayDeduCap2).HasMaxLength(25);
            entity.Property(e => e.PayDeduCap3).HasMaxLength(25);
            entity.Property(e => e.PayUpdtd).HasDefaultValue(false);
            entity.Property(e => e.PaymentUpdtd).HasDefaultValue(false);
            entity.Property(e => e.SickLeave).HasColumnName("Sick Leave");
            entity.Property(e => e.SiteAlloc).HasMaxLength(10);
            entity.Property(e => e.SpAllowDescr).HasMaxLength(30);
            entity.Property(e => e.WageCmthd).HasColumnName("WageCMthd");
            entity.Property(e => e.WageHr).HasColumnName("Wage/Hr");
            entity.Property(e => e.Wcurrency)
                .HasMaxLength(5)
                .HasColumnName("WCurrency");
            entity.Property(e => e.WdeptId)
                .HasMaxLength(10)
                .HasColumnName("WDeptId");
            entity.Property(e => e.Weid).HasColumnName("WEId");
            entity.Property(e => e.Wemonth)
                .HasColumnType("datetime")
                .HasColumnName("WEMonth");
        });

        modelBuilder.Entity<Wedet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WEDet");

            entity.Property(e => e.BonusHrs).HasColumnName("Bonus Hrs");
            entity.Property(e => e.JobCode).HasMaxLength(10);
            entity.Property(e => e.Nhr).HasColumnName("NHr");
            entity.Property(e => e.OthrG).HasColumnName("OTHr_G");
            entity.Property(e => e.OthrH).HasColumnName("OTHr_H");
            entity.Property(e => e.OtwageHr).HasColumnName("OTWage/Hr");
            entity.Property(e => e.ProfessionCode).HasMaxLength(10);
            entity.Property(e => e.WageHr).HasColumnName("Wage/Hr");
            entity.Property(e => e.Weid).HasColumnName("WEId");
        });

        modelBuilder.Entity<Whtb>(entity =>
        {
            entity.HasKey(e => e.Whno);

            entity.ToTable("WHTb");

            entity.HasIndex(e => e.Whid, "IX_WHTb").IsUnique();

            entity.Property(e => e.Whno).HasColumnName("WHNo");
            entity.Property(e => e.Whid)
                .HasMaxLength(15)
                .HasColumnName("WHId");
            entity.Property(e => e.Whname)
                .HasMaxLength(100)
                .HasColumnName("WHName");
        });

        modelBuilder.Entity<XlimpCmnTb>(entity =>
        {
            entity.HasKey(e => e.XlimportedId);

            entity.ToTable("XLImpCmnTb");

            entity.Property(e => e.XlimportedId)
                .ValueGeneratedNever()
                .HasColumnName("XLImportedId");
            entity.Property(e => e.CrtdBy).HasMaxLength(10);
            entity.Property(e => e.CrtdDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndKeyStr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HdrKeyStr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModuleNo).HasDefaultValue((short)0);
            entity.Property(e => e.XlfileName)
                .HasMaxLength(150)
                .HasColumnName("XLFileName");
            entity.Property(e => e.XlimpDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("XLImpDescription");
        });

        modelBuilder.Entity<XlimpFmtDtb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("XLImpFmtDTb");

            entity.HasIndex(e => e.XlimportedId, "IX_XLImpFmtDTb");

            entity.Property(e => e.ColumName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FldDescr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FldName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsCompulsory).HasDefaultValue(false);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.XlimportedId).HasColumnName("XLImportedId");
        });

        modelBuilder.Entity<XlrptQrTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("XLRptQrTb");

            entity.Property(e => e.XlunqNo).HasColumnName("XLUnqNo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
