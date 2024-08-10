using BMS.Application.Services.BooksService.DTOs;
using BMS.Application.Services.BooksService.Models;
using BMS.Domain.Models;

namespace BMS.Application.Services.BooksService.Abstractions;

public interface IBookService
{
    BookListModel GetBookList();
    BookDto GetBookById(int bookId);
    BookCreatedDto CreateBook(Book book);
    BookUpdatedDto UpdateBook(Book book);
    void DeleteBook(Book book);
}