using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class StatusCodeService(IStatusRepository statusRepository) : IStatusCodeService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<IEnumerable<StatusCode?>> GetStatusesAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        var statuses = entities.Select(StatusCodeFactory.Create);
        return statuses;
    }
}
