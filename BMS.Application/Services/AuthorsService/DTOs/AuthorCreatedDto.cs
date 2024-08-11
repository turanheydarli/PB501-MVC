
using BMS.Data.Models;

namespace BMS.Application.Services.AuthorsService.DTOs;

public class AuthorCreatedDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public IEnumerable<AuthorContact> Contacts { get; set; }
}