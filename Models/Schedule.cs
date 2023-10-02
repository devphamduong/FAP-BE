using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual Class? Class { get; set; }
    [JsonIgnore]
    public virtual Course? Course { get; set; }
    [JsonIgnore]
    public virtual Code? DayTypeNavigation { get; set; }
    [JsonIgnore]
    public virtual Code? SlotTypeNavigation { get; set; }
    [JsonIgnore]
    public virtual Teacher? Teacher { get; set; }
}
