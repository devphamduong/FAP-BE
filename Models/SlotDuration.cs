using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class SlotDuration
{
    public int Id { get; set; }

    public string? CodeId { get; set; }

    public string? Duration { get; set; }

    public virtual Code? Code { get; set; }
}
