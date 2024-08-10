namespace BMS.Domain.Models;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public AuthorContact Contact { get; set; }
}