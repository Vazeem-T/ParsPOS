using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class TaxtpTb
{
    public short TaxtypeNo { get; set; }

    public string? TaxtypeCode { get; set; }

    public bool IsTaxonTax { get; set; }
}
