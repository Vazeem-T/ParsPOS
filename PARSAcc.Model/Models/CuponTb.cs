using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class CuponTb
{
    public int CuponId { get; set; }

    public string? CuponName { get; set; }

    public decimal MaxAppAmt { get; set; }

    public string? AppProdQr { get; set; }

    public long? AccNo { get; set; }

    public double Mult { get; set; }
}
