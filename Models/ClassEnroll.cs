using System.Text.Json.Serialization;

namespace Project.Models;

public partial class ClassEnroll
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int StudentId { get; set; }
    [JsonIgnore]
    public virtual Class Class { get; set; } = null!;
    [JsonIgnore]
    public virtual Student Student { get; set; } = null!;
}
