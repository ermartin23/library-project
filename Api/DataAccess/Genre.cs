namespace Api.DataAccess;

public partial class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    
    public ICollection<Book> Books { get; set; } = new List<Book>();
}