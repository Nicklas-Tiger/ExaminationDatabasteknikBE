using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class EmployeeFactory
{
    public static Employee? Create(EmployeeRegistrationForm form) => form == null ? null : new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Role = form.Role
    };

    public static Employee? Create(EmployeeEntity entity)
    {
        if (entity == null)
            return null;
        var employee = new Employee()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Role = entity.Role
        };
        return employee;
    }
}
