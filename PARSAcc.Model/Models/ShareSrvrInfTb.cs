using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ShareSrvrInfTb
{
    public string? ShareSrver { get; set; }

    public string? SvrUsr { get; set; }

    public string? Password { get; set; }

    public string? Db { get; set; }

    public bool IsActive { get; set; }

    public int Id { get; set; }

    public string? LocalDb { get; set; }

    public bool IsBothSame { get; set; }

    public string? TbPreFix { get; set; }
}
