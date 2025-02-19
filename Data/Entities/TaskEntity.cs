namespace Data.Entities;

public class TaskEntity
{
    public int Id { get; set; }
    public ProjectEntity? ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public EmployeeEntity? AssignedTo { get; set; }
    public DateTime DueDate { get; set; }
    public StatusEntity StatusId { get; set; } = null!;
}
