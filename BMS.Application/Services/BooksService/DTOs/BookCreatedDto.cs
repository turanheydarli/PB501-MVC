namespace BMS.Application.Services.BooksService.DTOs;

public class BookCreatedDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CategoryId { get; set; }
    public int PublisherId { get; set; }
}