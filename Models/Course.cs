using System.Text.Json.Serialization;

namespace Project.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; } = new List<CourseEnroll>();
    [JsonIgnore]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
