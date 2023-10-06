using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public partial class MyProjectDbContext : DbContext
{
    public MyProjectDbContext()
    {
    }

    public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassEnroll> ClassEnrolls { get; set; }

    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnroll> CourseEnrolls { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<SlotDuration> SlotDurations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3213E83F0725A29B");

            entity.ToTable("Class");

            entity.HasIndex(e => e.Name, "UQ__Class__72E12F1B82F1081E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<ClassEnroll>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassEnr__A1A6291D23706DBA");

            entity.ToTable("ClassEnroll");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("classId");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassEnrolls)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassEnro__class__6B24EA82");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassEnrolls)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassEnro__stude__6C190EBB");
        });

        modelBuilder.Entity<Code>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Code__3213E83FB20FAC14");

            entity.ToTable("Code");

            entity.HasIndex(e => e.Code1, "UQ__Code__357D4CF9CCED90B7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code1)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3213E83F8F7C06B4");

            entity.ToTable("Course");

            entity.HasIndex(e => e.Name, "UQ__Course__72E12F1BACDF9377").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HasEduNext).HasColumnName("hasEduNext");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CourseEnroll>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CourseEn__FE7952B28EE05B47");

            entity.ToTable("CourseEnroll");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.StudentId).HasColumnName("studentId");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseEnrolls)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__cours__5441852A");

            entity.HasOne(d => d.Student).WithMany(p => p.CourseEnrolls)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__stude__5535A963");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3213E83FE1FCE671");

            entity.ToTable("Schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("classId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DayType)
                .HasMaxLength(50)
                .HasColumnName("dayType");
            entity.Property(e => e.Room)
                .HasMaxLength(50)
                .HasColumnName("room");
            entity.Property(e => e.SlotType)
                .HasMaxLength(50)
                .HasColumnName("slotType");
            entity.Property(e => e.TeacherId).HasColumnName("teacherId");

            entity.HasOne(d => d.Class).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Schedule__classI__59063A47");

            entity.HasOne(d => d.Course).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Schedule__course__5812160E");

            entity.HasOne(d => d.DayTypeNavigation).WithMany(p => p.ScheduleDayTypeNavigations)
                .HasPrincipalKey(p => p.Code1)
                .HasForeignKey(d => d.DayType)
                .HasConstraintName("FK__Schedule__dayTyp__5AEE82B9");

            entity.HasOne(d => d.SlotTypeNavigation).WithMany(p => p.ScheduleSlotTypeNavigations)
                .HasPrincipalKey(p => p.Code1)
                .HasForeignKey(d => d.SlotType)
                .HasConstraintName("FK__Schedule__slotTy__5BE2A6F2");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Schedule__teache__59FA5E80");
        });

        modelBuilder.Entity<SlotDuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SlotDura__3213E83FF37B3065");

            entity.ToTable("SlotDuration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodeId)
                .HasMaxLength(50)
                .HasColumnName("codeId");
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .HasColumnName("duration");

            entity.HasOne(d => d.Code).WithMany(p => p.SlotDurations)
                .HasPrincipalKey(p => p.Code1)
                .HasForeignKey(d => d.CodeId)
                .HasConstraintName("FK__SlotDurat__codeI__02FC7413");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3213E83F940042DA");

            entity.ToTable("Student");

            entity.HasIndex(e => e.Code, "UQ__Student__357D4CF90234A893").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender).HasColumnName("gender");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3213E83FE81C2AA1");

            entity.ToTable("Teacher");

            entity.HasIndex(e => e.Code, "UQ__Teacher__357D4CF96FED0FCA").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
