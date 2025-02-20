using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? null : new()
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        CustomerId = form.CustomerId,
        StatusId = form.StatusId
       
    };

    public static Project? Create(ProjectEntity entity)
    {
        if (entity == null)
            return null;

        var project = new Project
        {
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StatusId = entity.StatusId  // Lägg till detta!
        };

        if (entity.Customer != null)
        {
            project.Customer = new Customer
            {
                Id = entity.Customer.Id,
                CustomerName = entity.Customer.CustomerName,
                Email = entity.Customer.Email
            };
        }

        if (entity.Status != null)
        {
            project.StatusName = entity.Status.StatusName;  // Mappa StatusName här!
        }

        return project;
    }

}
