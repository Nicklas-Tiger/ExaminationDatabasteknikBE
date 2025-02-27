using Data.Entities;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public StatusCode? Status { get; set; }

    public Customer? Customer { get; set; }

    public ProjectManager? ProjectManager { get; set; }

    public Service? Service { get; set; } 
}