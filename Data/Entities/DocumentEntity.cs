namespace Data.Entities;

public class DocumentEntity
{
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;

    public string Title { get; set; } = null!;
    public DateTime UploadedAt { get; set; }
}
