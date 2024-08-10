using BMS.Application.Services.AuthorsService.DTOs;
using BMS.Domain.Models;

namespace BMS.Application.Services.AuthorsService.Abstractions;

public interface IAuthorService
{
    AuthorDto GetAuthorById(int authorId);
    AuthorCreatedDto CreateAuthor(Author author);
    AuthorUpdatedDto UpdateAuthor(Author author);
    void DeleteAuthor(Author author);
}