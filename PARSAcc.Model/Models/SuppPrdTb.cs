using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class SuppPrdTb
{
    public int SupplierNo { get; set; }

    public int ItemId { get; set; }

    public string? Ic { get; set; }

    public int BaseId { get; set; }
}
