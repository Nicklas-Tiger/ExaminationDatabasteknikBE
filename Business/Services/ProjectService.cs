using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Create);
        return projects;
    }
    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        // Kontrollera om CustomerId och StatusId är giltiga
        if (!await _customerRepository.ExistsAsync(customer => customer.Id == form.CustomerId))
            return false;

        // Här kollar vi även om StatusId är giltigt
        if (form.StatusId < 1)
            return false;

        // Skapa ProjectEntity och mappa StatusId korrekt
        var projectEntity = ProjectFactory.Create(form);
        if (projectEntity == null)
            return false;

        projectEntity.StatusId = form.StatusId;  // Mappa StatusId här!

        bool result = await _projectRepository.AddAsync(projectEntity);
        return result;
    }

}
