using BMS.Application.Services.PublishersService.Abstractions;
using BMS.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WebMVC.Controllers;

public class PublishersController : Controller
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    public IActionResult Index()
    {
        var publisherList = _publisherService.GetPublisherList();
        
        return View(publisherList);
    }

    public IActionResult Create()
    {
        return View(new Publisher());
    }

    [HttpPost]
    public IActionResult Create(Publisher publisher)
    {
        if (ModelState.IsValid)
        {
            _publisherService.CreatePublisher(publisher);
            
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }
}