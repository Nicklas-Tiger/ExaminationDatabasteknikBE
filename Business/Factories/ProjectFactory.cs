﻿using Business.Models;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? Map(ProjectRegistrationForm form) => form == null ? null : new ProjectEntity
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        CustomerId = form.CustomerId,
        StatusId = form.StatusId,
        ProjectManagerId = form.ProjectManagerId,
        ServiceId = form.ServiceId,
    };

    public static Project? Map(ProjectEntity entity) => entity == null ? null : new Project
    {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Status = StatusCodeFactory.Create(entity.Status),
        Customer = CustomerFactory.Create(entity.Customer),
        ProjectManager = ProjectManagerFactory.Create(entity.ProjectManager),
        Service = ServiceFactory.Create(entity.Service)

    };

    public static ProjectEntity Map(Project project)
    {
        try
        {

            ArgumentNullException.ThrowIfNull(project);

            var entity = new ProjectEntity
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                CustomerId = project.Customer?.Id ?? 0, 
                StatusId = project.Status?.Id ?? 0,     
                ProjectManagerId = project.ProjectManager?.Id ?? 0, 
                ServiceId = project.Service?.Id ?? 0    
            };
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}