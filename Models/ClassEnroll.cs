using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class ClassEnroll
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int? UserId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual User? User { get; set; }
}
