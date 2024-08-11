namespace BMS.Data.Models;

public class Book : BaseEntity
{
    public string Title { get; set; }

    public int CategoryId { get; set; }
    public BookCategory Category { get; set; }

    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    public ICollection<Author> Authors { get; set; }
}