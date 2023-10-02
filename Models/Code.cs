using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Code
{
    public int Id { get; set; }

    public string Code1 { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Schedule> ScheduleDayTypeNavigations { get; set; } = new List<Schedule>();

    public virtual ICollection<Schedule> ScheduleSlotTypeNavigations { get; set; } = new List<Schedule>();
}
