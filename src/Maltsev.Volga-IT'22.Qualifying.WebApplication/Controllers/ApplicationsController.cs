using Microsoft.AspNetCore.Mvc;

namespace Maltsev.Volga_IT_22.Qualifying.WebApplication.Controllers;

[Route("[controller]")]
public class ApplicationsController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }
}
