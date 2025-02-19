using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project?>> GetProjectsAsync();
    }
}