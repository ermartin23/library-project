namespace Api.Dtos
{
    // For reading authors
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // For creating new author
    public class AuthorCreateDto
    {
        public string Name { get; set; }
    }

    // For updating author
    public class AuthorUpdateDto
    {
        public string Name { get; set; }
    }
}