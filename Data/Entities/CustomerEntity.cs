using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Index(nameof(Email), IsUnique = true)]
public class CustomerEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public int CustomerTypeId { get; set; }
    public CustomerTypeEntity CustomerType { get; set; } = null!;
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}




