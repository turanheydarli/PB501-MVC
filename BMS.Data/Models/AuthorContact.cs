namespace BMS.Data.Models;

public class AuthorContact : BaseEntity
{
    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public string ContactNumber { get; set; }
    public string Address { get; set; }
}