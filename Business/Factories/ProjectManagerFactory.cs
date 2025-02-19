using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectManagerFactory
{
    public static ProjectManager? Create(ProjectManagerRegistrationForm form) => form == null ? null : new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName
    };
    public static ProjectManager? Create(ProjectManagerEntity entity)
    {
        if (entity == null)
            return null;

        var projectManager = new ProjectManager()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone
        };
        return projectManager;
    }
}
