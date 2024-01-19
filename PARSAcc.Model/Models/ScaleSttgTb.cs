using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ScaleSttgTb
{
    public byte CodeLen { get; set; }

    public bool BcwithQty { get; set; }

    public byte Bctype { get; set; }

    public int UnqNo { get; set; }

    public byte TtlCodeLen { get; set; }
}
