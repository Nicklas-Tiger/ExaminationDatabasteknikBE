using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        if (!await _customerRepository.ExistsAsync(customer => customer.Id == form.CustomerId))
            return false;
        if (form.StatusId < 1)
            return false;

        var projectEntity = ProjectFactory.Create(form);
        if (projectEntity == null)
            return false;

        projectEntity.StatusId = form.StatusId;

        bool result = await _projectRepository.AddAsync(projectEntity);
        return result;
    }
    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Create);
        return projects;
    }

    //public async Task<Project?> GetProjectAsync()
    //{
    //   //FIXA
    //}
    //public async Task<Project?> GetProjectAsync(int id)
    //{
    //    //FIXA
    //}
    //public async Task<bool> UpdateProjectAsync()
    //{
    //    //Fixa
    //}

}
