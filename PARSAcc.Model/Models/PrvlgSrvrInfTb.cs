using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PrvlgSrvrInfTb
{
    public string? PrvlgSrver { get; set; }

    public string? SvrUsr { get; set; }

    public string? Password { get; set; }

    public string? Db { get; set; }

    public bool IsActive { get; set; }

    public string? Formula { get; set; }

    public int Id { get; set; }
}
