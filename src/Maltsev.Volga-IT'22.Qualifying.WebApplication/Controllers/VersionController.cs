using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Maltsev.Volga_IT_22.Qualifying.WebApplication;

[Route("[controller]")]
public class VersionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion() =>
        new OkObjectResult(
            new
            {
                Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString()
            }
        );
}
