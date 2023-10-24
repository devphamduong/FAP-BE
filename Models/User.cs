namespace Project.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public bool? Gender { get; set; }

    public string? Address { get; set; }

    public DateTime? Dob { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<ClassEnroll> ClassEnrolls { get; set; } = new List<ClassEnroll>();

    public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; } = new List<CourseEnroll>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
