using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        var entities = await _db
            .Include(x => x.Status)
            .Include(x => x.Customer)
            .Include(x => x.ProjectManager)
            .Include(x => x.Description)
            .ToListAsync();
        return entities;
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _db
            .Include(x => x.Status)
            .Include(x => x.Customer)
            .Include(x => x.ProjectManager)
            .Include(x => x.Description)
            .FirstOrDefaultAsync(expression);
        return entity;
    }

}

