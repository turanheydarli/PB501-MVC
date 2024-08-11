using BMS.Application.Services.AuthorsService.Abstractions;
using BMS.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WebMVC.Controllers;

public class AuthorsController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public IActionResult Index()
    {
        var authorList = _authorService.GetAuthorList();

        return View(authorList);
    }

    public IActionResult Create()
    {
        return View(new Author());
    }

    [HttpPost]
    public IActionResult Create(Author author)
    {
        if (ModelState.IsValid)
        {
            _authorService.CreateAuthor(author);

            return RedirectToAction(nameof(Index));
        }

        return View();
    }
}