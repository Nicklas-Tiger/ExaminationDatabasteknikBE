using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class PostalCodeEntity
{
    [Key]
    public string PostalCodeId { get; set; } = null!;
    public string City { get; set; } = null!;
}
