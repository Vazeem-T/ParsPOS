using System;
using System.Collections.Generic;

namespace PARSPOS.SaleModel;

public partial class BkPoscmnTb
{
    public DateTime SysDateTime { get; set; }

    public DateTime? TrDate { get; set; }

    public int? InvNo { get; set; }

    public int? Cscode { get; set; }

    public string TrDescription { get; set; }

    public string UserId { get; set; }

    public double? Discount { get; set; }

    public double? DiscountWithLnDisc { get; set; }

    public double? RetDiscount { get; set; }

    public string SlsManId { get; set; }

    public string AreaCode { get; set; }

    public bool IsFc { get; set; }

    public double? Fcrate { get; set; }

    public int? Nfraction { get; set; }

    public string Fc { get; set; }

    public string BrId { get; set; }

    public string Counter { get; set; }

    public string Location { get; set; }

    public double? Tendered { get; set; }

    public double? Balance { get; set; }

    public bool Updated { get; set; }

    public string InvKey { get; set; }

    public bool Srupdated { get; set; }

    public bool AccNotCreated { get; set; }

    public int CounterNo { get; set; }

    public bool Cancel { get; set; }

    public byte IsHomeDel { get; set; }

    public string EmpId { get; set; }

    public int? EmpNo { get; set; }

    public string Hdaddress { get; set; }

    public DateTime? CollectionTm { get; set; }

    public long LoginId { get; set; }

    public DateTime? CollectionPosdt { get; set; }

    public string CollectBy { get; set; }

    public int? CollcnCuntrNo { get; set; }

    public bool? IsPostCompleted { get; set; }

    public long? ColLoginId { get; set; }

    public float Disc { get; set; }

    public string DelCode { get; set; }

    public bool DoHide { get; set; }

    public double RoundVal { get; set; }

    public long PrvlgCardNo { get; set; }

    public bool IsPcardUpdtd { get; set; }

    public float TaxAmt { get; set; }

    public long LLoginId { get; set; }

    public DateTime? LSysDateTime { get; set; }
}
