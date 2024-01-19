using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PettyDescrTb
{
    public string PettyDescr { get; set; } = null!;

    public int? AccountNo { get; set; }

    public int PettyId { get; set; }
}
