namespace Data.Entities;

public class NoteEntity
{
    public int Id { get; set; }
    public ProjectEntity ProjectId { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string NoteText { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
