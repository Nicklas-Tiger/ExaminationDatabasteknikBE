﻿using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectManagerService(IProjectManagerRepository projectManagerRepository) : IProjectManagerService
{
    private readonly IProjectManagerRepository _projectManagerRepository = projectManagerRepository;

    public async Task<IEnumerable<ProjectManager?>> GetProjectManagersAsync()
    {
        var entities = await _projectManagerRepository.GetAllAsync();
        var projectManager = entities.Select(ProjectManagerFactory.Create);
        return projectManager;
    }
}
