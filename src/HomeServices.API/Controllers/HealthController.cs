using Microsoft.AspNetCore.Mvc;

namespace HomeServices.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public HealthController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            ApplicationName = "Home Services Platform",
            Version = "1.0.0",
            CurrentEnvironment = _env.EnvironmentName,
            ServerTime = DateTime.UtcNow,
            Status = "Healthy"
        });
    }
}
