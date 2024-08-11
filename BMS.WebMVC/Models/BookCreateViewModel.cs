using BMS.Application.Services.AuthorsService.DTOs;
using BMS.Application.Services.CategoryService.DTOs;
using BMS.Application.Services.PublishersService.DTOs;
using BMS.Data.Models;

namespace BMS.WebMVC.Models;

public class BookCreateViewModel
{
    public Book Book { get; set; }
    public List<CategoryDto> Categories { get; set; }
    public List<PublisherDto> Publishers { get; set; }
    public List<AuthorDto> Authors { get; set; }
    public int[] AuthorIds { get; set; }
}