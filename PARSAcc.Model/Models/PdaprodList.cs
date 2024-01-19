using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PdaprodList
{
    public int ItemId { get; set; }

    public double Price { get; set; }

    public double Cost { get; set; }

    public DateTime? DelDt { get; set; }
}
