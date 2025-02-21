using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectManagersController(IProjectManagerService projectManagerService) : ControllerBase
{
    private readonly IProjectManagerService _projectManagerService = projectManagerService;

    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var projectManagers = await _projectManagerService.GetProjectManagersAsync();
        return Ok(projectManagers);
    }
}
