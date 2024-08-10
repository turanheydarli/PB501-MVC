using System.Diagnostics;
using BMS.Application.Services.AuthorsService.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}