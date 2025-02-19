using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusesController(IStatusCodeService statusCodeService) : ControllerBase
{
    private readonly IStatusCodeService _statusCodeService = statusCodeService;

    [HttpGet]
    public async Task<IActionResult> GetStatusesAsync()
    {
        var statuses = await _statusCodeService.GetStatusesAsync();
        return Ok(statuses);
    }
}
