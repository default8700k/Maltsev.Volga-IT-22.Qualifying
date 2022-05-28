using Microsoft.AspNetCore.Mvc;

namespace Maltsev.Volga_IT_22.Qualifying.WebApplication.Controllers;

[Route("[controller]")]
public class AccountController : Controller
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet("password")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}
