using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public DbSet<Entities.CustomerAddressEntity> CustomerAddresses { get; set; } = null!;
    public DbSet<Entities.CustomerContactEntity> CustomerContacts { get; set; } = null!;
    public DbSet<Entities.CustomerEntity> Customers { get; set; } = null!;
    public DbSet<Entities.CustomerTypeEntity> CustomerTypes { get; set; } = null!;
    public DbSet<Entities.DocumentEntity> Documents { get; set; } = null!;
    public DbSet<Entities.EmployeeEntity> Employees { get; set; } = null!;
    public DbSet<Entities.MeetingEntity> Meetings { get; set; } = null!;
    public DbSet<Entities.NoteEntity> Notes { get; set; } = null!;
    public DbSet<Entities.PostalCodeEntity> PostalCodes { get; set; } = null!;
    public DbSet<Entities.ProjectEntity> Projects { get; set; } = null!;
    public DbSet<Entities.ProjectHistoryEntity> ProjectHistories { get; set; } = null!;
    public DbSet<Entities.ProjectManagerEntity> ProjectManagers { get; set; } = null!;
    public DbSet<Entities.ServiceEntity> Services { get; set; } = null!;
    public DbSet<Entities.StatusEntity> Statuses { get; set; } = null!;
    public DbSet<Entities.TaskEntity> Tasks { get; set; } = null!;  

}
