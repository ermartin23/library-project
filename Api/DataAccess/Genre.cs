namespace Api.DataAccess;

public class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Book> Books { get; set; } = new List<Book>();
}