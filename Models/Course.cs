using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? HasEduNext { get; set; }

    public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; } = new List<CourseEnroll>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
