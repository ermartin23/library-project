namespace Api.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreCreateDto
    {
        public string Name { get; set; }
    }

    public class GenreUpdateDto
    {
        public string Name { get; set; }
    }
}