using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {
        if (!ModelState.IsValid && form.CustomerId < 1)
            return BadRequest(ModelState);

        var result = await _projectService.CreateProjectAsync(form);
        if (result)
            return CreatedAtAction(nameof(GetAll), null);
        return StatusCode(500);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return project != null ? Ok(project) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject(Project project)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var updated = await _projectService.UpdateProjectAsync(project);
        return updated ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectService.GetProjectAsync(id);
        if (project == null)
            return NotFound();

        var deleted = await _projectService.DeleteProjectAsync(project);
        return deleted ? Ok() : BadRequest();
    }


}



