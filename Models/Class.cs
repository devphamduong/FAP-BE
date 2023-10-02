using System.Text.Json.Serialization;

namespace Project.Models;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<ClassEnroll> ClassEnrolls { get; set; } = new List<ClassEnroll>();
    [JsonIgnore]
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
