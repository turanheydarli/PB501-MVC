using BMS.Application.Services.BooksService.DTOs;

namespace BMS.Application.Services.BooksService.Models;

public class BookListModel
{
    public List<BookDto> Items { get; set; }
}