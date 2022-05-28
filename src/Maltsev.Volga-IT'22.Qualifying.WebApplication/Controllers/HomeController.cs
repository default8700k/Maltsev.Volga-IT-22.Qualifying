using Microsoft.AspNetCore.Mvc;

namespace Maltsev.Volga_IT_22.Qualifying.WebApplication.Controllers;

[Route("")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
