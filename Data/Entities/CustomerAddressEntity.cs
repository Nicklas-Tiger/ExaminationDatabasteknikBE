namespace Data.Entities;

public class CustomerAddressEntity
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;

    public string? PostalCodeId { get; set; }
    public PostalCodeEntity PostalCode { get; set; } = null!;
}
