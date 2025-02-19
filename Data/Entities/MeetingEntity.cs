namespace Data.Entities;

public class MeetingEntity
{
    public int Id { get; set; }

    public int? ProjectId { get; set; } // ❗ Ändrad till nullable (int?) pga ChatGpt hjälpte mig felsöka att det tidigare var multipla cascade paths... Avhjälpt med ChatGPT.
    public ProjectEntity? Project { get; set; }

    public int? CustomerId { get; set; } 
    public CustomerEntity? Customer { get; set; }

    public DateTime MeetingDate { get; set; }
    public string Notes { get; set; } = null!;
}
