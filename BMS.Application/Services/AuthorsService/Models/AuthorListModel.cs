using BMS.Application.Services.AuthorsService.DTOs;

namespace BMS.Application.Services.AuthorsService.Models;

public class AuthorListModel
{
    public List<AuthorDto> Items { get; set; }
}