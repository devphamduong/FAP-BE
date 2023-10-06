using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ClassEnroll> ClassEnrolls { get; set; } = new List<ClassEnroll>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
