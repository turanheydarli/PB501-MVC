using BMS.Application.Services.AuthorsService.Abstractions;
using BMS.Application.Services.AuthorsService.DTOs;
using BMS.Application.Services.AuthorsService.Models;
using BMS.Data.Models;
using BMS.Data.Persistence.Contexts;
using BMS.Data.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BMS.Application.Services.AuthorsService;

public class AuthorService : IAuthorService
{
    private readonly IRepository<Author, MsSqlDbContext> _repository;

    public AuthorService(IRepository<Author, MsSqlDbContext> repository)
    {
        _repository = repository;
    }

    public AuthorListModel GetAuthorList()
    {
        var authors = _repository.GetList(include: a => { return a.Include(b => b.Contacts); });

        var authorsDto = authors.Select(b => new AuthorDto()
        {
            Id = b.Id,
            CreatedAt = b.CreatedAt,
            UpdatedAt = b.UpdatedAt,
            Name = b.Name,
            Contacts = b.Contacts
        });

        var authorListModel = new AuthorListModel()
        {
            Items = authorsDto.ToList()
        };

        return authorListModel;
    }

    public AuthorDto GetAuthorById(int authorId)
    {
        Author author = _repository.Get(b => b.Id == authorId);

        if (author == null)
        {
            throw new Exception();
        }

        return new AuthorDto()
        {
            Id = author.Id,
            Name = author.Name,
            UpdatedAt = author.UpdatedAt,
            Contacts = author.Contacts,
            CreatedAt = author.CreatedAt
        };
    }

    public AuthorCreatedDto CreateAuthor(Author author)
    {
        Author createdAuthor = _repository.Add(author);

        return new AuthorCreatedDto()
        {
            Id = createdAuthor.Id,
            Contacts = author.Contacts,
            CreatedAt = author.CreatedAt,
            UpdatedAt = author.UpdatedAt,
            Name = author.Name
        };
    }

    public AuthorUpdatedDto UpdateAuthor(Author author)
    {
        Author authorToUpdate = _repository.Get(b => b.Id == author.Id);

        authorToUpdate.Name = author.Name;
        authorToUpdate.Contacts = author.Contacts;
        authorToUpdate.UpdatedAt = DateTime.UtcNow;

        _repository.Update(authorToUpdate);

        return new AuthorUpdatedDto()
        {
            Id = author.Id,
            CreatedAt = author.CreatedAt,
            UpdatedAt = author.UpdatedAt,
            Name = author.Name,
            Contacts = author.Contacts,
        };
    }

    public void DeleteAuthor(Author author)
    {
        Author deletedAuthor = _repository.Get(b => b.Id == author.Id);

        _repository.Delete(deletedAuthor);
    }
}