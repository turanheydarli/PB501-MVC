using BMS.Application.Services.AuthorsService.Abstractions;
using BMS.Application.Services.AuthorsService.DTOs;
using BMS.Domain.Models;
using BMS.Infrastructure.Persistence.Contexts;
using BMS.Infrastructure.Persistence.Contexts.Abstraction;
using BMS.Infrastructure.Persistence.Repositories;

namespace BMS.Application.Services.AuthorsService;

public class AuthorService : IAuthorService
{
    private readonly IRepository<Author, MsSqlDbContext> _repository;

    public AuthorService(IRepository<Author, MsSqlDbContext> repository)
    {
        _repository = repository;
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
            Contact = author.Contact,
            CreatedAt = author.CreatedAt
        };
    }

    public AuthorCreatedDto CreateAuthor(Author author)
    {
        Author createdAuthor = _repository.Add(author);

        return new AuthorCreatedDto()
        {
            Id = createdAuthor.Id,
            Contact = author.Contact,
            CreatedAt = author.CreatedAt,
            UpdatedAt = author.UpdatedAt,
            Name = author.Name
        };
    }

    public AuthorUpdatedDto UpdateAuthor(Author author)
    {
        Author authorToUpdate = _repository.Get(b => b.Id == author.Id);

        authorToUpdate.Name = author.Name;
        authorToUpdate.Contact = author.Contact;
        authorToUpdate.UpdatedAt = DateTime.UtcNow;

        _repository.Update(authorToUpdate);

        return new AuthorUpdatedDto()
        {
            Id = author.Id,
            CreatedAt = author.CreatedAt,
            UpdatedAt = author.UpdatedAt,
            Name = author.Name,
            Contact = author.Contact,
        };
    }

    public void DeleteAuthor(Author author)
    {
        Author deletedAuthor = _repository.Get(b => b.Id == author.Id);

        _repository.Delete(deletedAuthor);
    }
}