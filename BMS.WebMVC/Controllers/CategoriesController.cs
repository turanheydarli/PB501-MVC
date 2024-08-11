using BMS.Application.Services.BooksService.Abstractions;
using BMS.Application.Services.CategoryService.Abstractions;
using BMS.Application.Services.PublishersService.Abstractions;
using BMS.Data.Models;
using BMS.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WebMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly IBookService _bookService;
    private readonly IPublisherService _publisherService;
    private readonly ICategoryService _categoryService;

    public CategoriesController(IBookService bookService, IPublisherService publisherService, ICategoryService categoryService)
    {
        _bookService = bookService;
        _publisherService = publisherService;
        _categoryService = categoryService;
    }


    public IActionResult Index()
    {
       var categoryList = _categoryService.GetCategoryList();
        
        return View(categoryList);
    }

    public IActionResult Create()
    {
        return View(new BookCategory());
    }

    [HttpPost]
    public IActionResult Create(BookCategory category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.CreateCategory(category);
            
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }
}