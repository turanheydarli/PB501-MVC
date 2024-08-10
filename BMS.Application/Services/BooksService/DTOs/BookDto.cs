using BMS.Domain.Models;

namespace BMS.Application.Services.BooksService.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CategoryId { get; set; }
    public int PublisherId { get; set; }
    
    public string PublisherName { get; set; }
    public string CategoryName { get; set; }
}