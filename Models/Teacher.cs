﻿using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
