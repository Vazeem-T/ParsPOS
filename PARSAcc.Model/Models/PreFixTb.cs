using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class PreFixTb
{
    public int Id { get; set; }

    public int? VrTypeNo { get; set; }

    public string? VoucherName { get; set; }

    public string? PreFix { get; set; }

    public int? VrNo { get; set; }

    public bool Enable { get; set; }

    public int? Ano { get; set; }

    public int? Ano2 { get; set; }

    public string? BrId { get; set; }

    public byte? Ctgry { get; set; }

    public byte IconNo { get; set; }

    public bool DelId { get; set; }

    public byte[]? Img { get; set; }

    public short IsEstimate { get; set; }

    public bool DontShowBttn { get; set; }
}
