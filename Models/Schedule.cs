using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? CourseId { get; set; }

    public int? ClassId { get; set; }

    public int? TeacherId { get; set; }

    public string? DayType { get; set; }

    public string? SlotType { get; set; }

    public string? Room { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Code? DayTypeNavigation { get; set; }

    public virtual Code? SlotTypeNavigation { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
