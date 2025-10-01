using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public ActionResult<List<BookDto>> GetAll()
        {
            var books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    GenreId = b.GenreId,
                    AuthorName = b.Author.Name,
                    GenreName = b.Genre.Name
                })
                .ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetById(int id)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Where(b => b.Id == id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    GenreId = b.GenreId,
                    AuthorName = b.Author.Name,
                    GenreName = b.Genre.Name
                })
                .FirstOrDefault();

            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<BookDto> Create([FromBody] BookCreateDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId,
                GenreId = dto.GenreId
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            var result = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Where(b => b.Id == book.Id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    GenreId = b.GenreId,
                    AuthorName = b.Author.Name,
                    GenreName = b.Genre.Name
                })
                .First();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, result);
        }

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
