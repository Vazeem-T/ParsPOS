using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class LoginStatusTb
{
    public long LoginId { get; set; }

    public long InstanceId { get; set; }

    public DateTime LoginTm { get; set; }

    public DateTime RefreshTm { get; set; }

    public bool IsLogedOff { get; set; }

    public string? UserId { get; set; }

    public DateTime BrefreshTm { get; set; }
}
