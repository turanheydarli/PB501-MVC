using BMS.Application.Services.BooksService.Abstractions;
using BMS.Application.Services.BooksService.DTOs;
using BMS.Application.Services.BooksService.Models;
using BMS.Domain.Models;
using BMS.Infrastructure.Persistence.Contexts;
using BMS.Infrastructure.Persistence.Contexts.Abstraction;
using BMS.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BMS.Application.Services.BooksService;

public class BookService : IBookService
{
    private readonly IRepository<Book, MsSqlDbContext> _repository;

    public BookService(IRepository<Book, MsSqlDbContext> repository)
    {
        _repository = repository;
    }


    public BookListModel GetBookList()
    {
        var books = _repository.GetList(include: books =>
        {
            return books.Include(b => b.Category)
                .Include(b => b.Publisher);
        });


        BookListModel bookListModel = new BookListModel
        {
            Items = new List<BookDto>()
        };

        foreach (var book in books)
        {
            bookListModel.Items.Add(new BookDto()
            {
                Id = book.Id,
                CreatedAt = book.CreatedAt,
                UpdatedAt = book.UpdatedAt,
                Title = book.Title,
                CategoryName = book.Category.Name,
                PublisherName = book.Publisher.Name
            });
        }

        return bookListModel;
    }

    public BookDto GetBookById(int bookId)
    {
        Book book = _repository.Get(b => b.Id == bookId);

        if (book == null)
        {
            // TODO: throw custom exception here

            throw new Exception();
        }

        return new BookDto
        {
            Id = book.Id,
            UpdatedAt = book.UpdatedAt,
            CreatedAt = book.CreatedAt,
            CategoryId = book.CategoryId,
            PublisherId = book.PublisherId,
            Title = book.Title
        };
    }

    public BookCreatedDto CreateBook(Book book)
    {
        Book createdBook = _repository.Add(book);

        return new BookCreatedDto()
        {
            Id = createdBook.Id,
            CreatedAt = createdBook.CreatedAt,
            CategoryId = createdBook.CategoryId,
            PublisherId = createdBook.PublisherId,
            Title = createdBook.Title
        };
    }

    public BookUpdatedDto UpdateBook(Book book)
    {
        Book bookToUpdate = _repository.Get(b => b.Id == book.Id);

        book.Title = book.Title;
        book.CategoryId = book.CategoryId;
        book.PublisherId = book.PublisherId;
        book.UpdatedAt = DateTime.UtcNow;

        _repository.Update(bookToUpdate);

        return new BookUpdatedDto()
        {
            Id = bookToUpdate.Id,
            CreatedAt = bookToUpdate.CreatedAt,
            CategoryId = bookToUpdate.CategoryId,
            PublisherId = bookToUpdate.PublisherId,
            Title = bookToUpdate.Title
        };
    }

    public void DeleteBook(Book book)
    {
        Book deletedBook = _repository.Get(b => b.Id == book.Id);

        _repository.Delete(deletedBook);
    }
}