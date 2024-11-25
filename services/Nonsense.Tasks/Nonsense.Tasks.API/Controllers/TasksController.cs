using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nonsense.Tasks.API.Settings;

namespace Nonsense.Tasks.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IOptions<AppSettings> _appSettings;

    public TasksController(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings;
    }
    
    [HttpGet]
    public IActionResult GetList()
    {
        return Ok(_appSettings.Value.Database.ConnectionString);
    }
}