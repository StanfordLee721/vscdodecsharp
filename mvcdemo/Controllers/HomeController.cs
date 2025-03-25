using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcdemo.Filters;
using mvcdemo.Models;

namespace mvcdemo.Controllers;

[AuthorizationFilter]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [ActionFilter]
    public IActionResult Index()
    {
        return View();
    }

    [ActionFilter]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
