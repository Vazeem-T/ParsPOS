using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdaprdChgReqCmn
{
    public int ReqNo { get; set; }

    public DateTime ReqDt { get; set; }

    public string? ReqBy { get; set; }
}
