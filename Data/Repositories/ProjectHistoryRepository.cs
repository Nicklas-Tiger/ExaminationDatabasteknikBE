using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectHistoryRepository(DataContext context) : BaseRepository<ProjectHistoryEntity>(context), IProjectHistoryRepository
{

}
