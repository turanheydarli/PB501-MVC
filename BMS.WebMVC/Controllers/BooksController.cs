using BMS.Application.Services.BooksService.Abstractions;
using BMS.Application.Services.PublishersService.Abstractions;
using BMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BMS.WebMVC.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _bookService;
    private readonly IPublisherService _publisherService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        var bookList = _bookService.GetBookList();

        return View(bookList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Book book)
    {
        
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }
}