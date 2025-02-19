namespace Business.Models;

public class EmployeeRegistrationForm
{

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!; // MÅSTE JAG HA FULL NAME HÄR?
    public string Role { get; set; } = null!;
}
