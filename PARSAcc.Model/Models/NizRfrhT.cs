using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class NizRfrhT
{
    public int Id { get; set; }

    public byte? Tp { get; set; }

    public int? GrpId { get; set; }

    public int? BaseId { get; set; }

    public decimal Vatper { get; set; }
}
