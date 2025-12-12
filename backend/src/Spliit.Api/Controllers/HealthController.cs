using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spliit.Infrastructure.Data;

namespace Spliit.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public HealthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("readiness")]
    [HttpGet("")]
    public async Task<IActionResult> Readiness()
    {
        try
        {
            await _context.Database.CanConnectAsync();
            return Ok(new { status = "Healthy", database = "Connected" });
        }
        catch
        {
            return StatusCode(503, new { status = "Unhealthy", database = "Disconnected" });
        }
    }

    [HttpGet("liveness")]
    public IActionResult Liveness()
    {
        return Ok(new { status = "Alive" });
    }
}
