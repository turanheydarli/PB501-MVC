using BMS.Domain.Models;

namespace BMS.Application.Services.AuthorsService.DTOs;

public class AuthorUpdatedDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public AuthorContact Contact { get; set; }
}