using BMS.Application.Services.AuthorsService.DTOs;
using BMS.Application.Services.AuthorsService.Models;
using BMS.Data.Models;

namespace BMS.Application.Services.AuthorsService.Abstractions;

public interface IAuthorService
{
    AuthorListModel GetAuthorList();
    AuthorDto GetAuthorById(int authorId);
    AuthorCreatedDto CreateAuthor(Author author);
    AuthorUpdatedDto UpdateAuthor(Author author);
    void DeleteAuthor(Author author);
}