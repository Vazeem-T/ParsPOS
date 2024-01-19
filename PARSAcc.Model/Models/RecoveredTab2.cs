using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class RecoveredTab2
{
    public byte Status { get; set; }

    public byte Priority { get; set; }

    public long QueuingOrder { get; set; }

    public Guid ConversationGroupId { get; set; }

    public Guid ConversationHandle { get; set; }

    public long MessageSequenceNumber { get; set; }

    public Guid MessageId { get; set; }

    public int MessageTypeId { get; set; }

    public int ServiceId { get; set; }

    public int ServiceContractId { get; set; }

    public string Validation { get; set; } = null!;

    public int NextFragment { get; set; }

    public int FragmentSize { get; set; }

    public long FragmentBitmap { get; set; }

    public byte[]? BinaryMessageBody { get; set; }
}
