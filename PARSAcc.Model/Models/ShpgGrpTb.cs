using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ShpgGrpTb
{
    public int ShpgGrpId { get; set; }

    public string? ShpgGrpCode { get; set; }

    public string? ShpgGrpName { get; set; }

    public DateTime? ShpgGrpDt { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? CreatedBy { get; set; }
}
