using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
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
            return BadRequest();

        var result = await _projectService.CreateProjectAsync(form);
        if (result)
            return CreatedAtAction(nameof(GetAll), null);
        return StatusCode(500, "Fel när projektet skapades.");
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }

    //HÄR SKA OCKSÅ IN SEN
    //[HttpGet("{id}")]
    //public async Task<IActionResult> Get(int id)
    //{
    //    var project = await _projectService.GetProjectAsync(id);
    //    if (project == null)
    //        return NotFound();
    //    return Ok(project);
 }



