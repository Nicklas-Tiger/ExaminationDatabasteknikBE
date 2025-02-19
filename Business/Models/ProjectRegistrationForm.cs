namespace Business.Models;

public class ProjectRegistrationForm
{
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public string CustomerName { get; set; } = null!;
    public int StatusId { get; set; } 
}

