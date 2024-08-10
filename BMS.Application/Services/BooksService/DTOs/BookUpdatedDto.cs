namespace BMS.Application.Services.BooksService.DTOs;

public class BookUpdatedDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int CategoryId { get; set; }
    public int PublisherId { get; set; }
}