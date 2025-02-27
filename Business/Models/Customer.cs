using System.Text.Json.Serialization;

namespace Business.Models;

public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Email { get; set; } = null!;

    [JsonIgnore] //ChatGPT tipsade om detta när jag fortsatte få nestlade Kundobjekt i JSON.
    public IEnumerable<Project> Projects { get; set; } = [];
}

