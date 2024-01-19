using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdaprdChgReqDet
{
    public int ReqNo { get; set; }

    public int? ItemId { get; set; }

    public bool? IsBase { get; set; }

    public bool? NewBase { get; set; }

    public int Uval { get; set; }

    public int Dval { get; set; }

    public string? Nunit { get; set; }
}
