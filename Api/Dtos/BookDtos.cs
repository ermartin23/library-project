namespace Api.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Use references instead of nested objects
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }

    public class BookCreateDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }

    public class BookUpdateDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}