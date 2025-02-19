namespace Data.Entities;

public class ProjectHistoryEntity
{
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;

    public int ChangedById { get; set; }
    public EmployeeEntity ChangedBy { get; set; } = null!;

    public string? ChangeDescription { get; set; }
    public DateTime ChangedAt { get; set; }
}
