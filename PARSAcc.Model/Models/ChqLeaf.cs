using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class ChqLeaf
{
    public long ChqLeaveId { get; set; }

    public int? ChqBookId { get; set; }

    public int? VoucherId { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? ChqDate { get; set; }

    public string? PayeeName { get; set; }

    public int? PartyId { get; set; }

    public decimal? ChqAmount { get; set; }

    public bool? IsAccPay { get; set; }

    public string? Description { get; set; }

    public byte? Status { get; set; }

    public DateTime? ClearedDt { get; set; }

    public string? UserId { get; set; }

    public DateTime? CrtdTm { get; set; }

    public DateTime? ModiTm { get; set; }

    public long? ChqNo { get; set; }

    public string? ModiBy { get; set; }

    public int? PayeeId { get; set; }
}
