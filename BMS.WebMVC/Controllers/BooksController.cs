using BMS.Application.Services.AuthorsService.Abstractions;
using BMS.Application.Services.AuthorsService.DTOs;
using BMS.Application.Services.BooksService.Abstractions;
using BMS.Application.Services.CategoryService.Abstractions;
using BMS.Application.Services.PublishersService.Abstractions;
using BMS.Data.Models;
using BMS.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WebMVC.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _bookService;
    private readonly IPublisherService _publisherService;
    private readonly ICategoryService _categoryService;
    private readonly IAuthorService _authorService;

    public BooksController(IBookService bookService, IPublisherService publisherService,
        ICategoryService categoryService, IAuthorService authorService)
    {
        _bookService = bookService;
        _publisherService = publisherService;
        _categoryService = categoryService;
        _authorService = authorService;
    }

    public IActionResult Index()
    {
        var bookList = _bookService.GetBookList();

        return View(bookList);
    }

    public IActionResult Create()
    {
        var categoryList = _categoryService.GetCategoryList();
        var publisherList = _publisherService.GetPublisherList();
        var authorList = _authorService.GetAuthorList();

        var model = new BookCreateViewModel()
        {
            Categories = categoryList.Items,
            Publishers = publisherList.Items,
            Authors = authorList.Items,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(BookCreateViewModel bookCreate)
    {
        bookCreate.Authors = new List<AuthorDto>();

        foreach (var authorId in bookCreate.AuthorIds)
        {
            var author = _authorService.GetAuthorById(authorId);

            bookCreate.Authors.Add(author);
        }

        _bookService.CreateBook(bookCreate.Book);

        return RedirectToAction(nameof(Index));

        return RedirectToAction(nameof(Index));
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