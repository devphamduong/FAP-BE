using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public bool? Gender { get; set; }

    public string? Address { get; set; }

    public DateTime? Dob { get; set; }

    public virtual ICollection<ClassEnroll> ClassEnrolls { get; set; } = new List<ClassEnroll>();

    public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; } = new List<CourseEnroll>();
}
