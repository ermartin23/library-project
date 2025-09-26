
using Api.DataAccess;
using Api.Dtos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET all books
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _context.Books
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    GenreId = b.GenreId
                })
                .ToList();

            return Ok(books);
        }

        // GET book by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books
                .Where(b => b.Id == id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    GenreId = b.GenreId
                })
                .FirstOrDefault();

            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST create new book
        [HttpPost]
        public IActionResult Create([FromBody] BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId,
                GenreId = dto.GenreId
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            var result = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId
            };

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, result);
        }

        // PUT update book
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookUpdateDto dto)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE book
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
