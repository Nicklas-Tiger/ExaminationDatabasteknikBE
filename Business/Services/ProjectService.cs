using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form, nameof(form));

            if (!await _customerRepository.ExistsAsync(customer => customer.Id == form.CustomerId))
                return false;
            if (form.StatusId < 1)
                return false;

            var projectEntity = ProjectFactory.Map(form);
            if (projectEntity == null)
                return false;

            projectEntity.StatusId = form.StatusId;

            bool result = await _projectRepository.AddAsync(projectEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {

        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Map);
        return projects;
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        var entity = await _projectRepository.GetAsync(p => p.Id == id);
        if (entity == null)
            return null;    
        var project = ProjectFactory.Map(entity);    
        return project;
    }
    public async Task<bool> UpdateProjectAsync(ProjectUpdateForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var projectEntity = ProjectFactory.Map(form);

            if (projectEntity == null)
                return false;

            var result  = await _projectRepository.UpdateAsync(projectEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> DeleteProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var projectEntity = await _projectRepository.GetAsync(p => p.Id == project.Id);

            if (projectEntity == null)
            {
                Console.WriteLine($"Ingen projekt hittades med id: {project.Id}");
                return false;
            }

            var result = await _projectRepository.RemoveAsync(projectEntity);

            Console.WriteLine($"DELETE: {(result ? "Lyckades" : "Misslyckades")}");
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel vid radering: {ex.Message}");
            return false;
        }
    }



}
