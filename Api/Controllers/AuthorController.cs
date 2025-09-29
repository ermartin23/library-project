using Microsoft.AspNetCore.Mvc;
using Api.DataAccess;
using Api.Dtos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public AuthorController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<AuthorDto>> GetAll()
        {
            var authors = _context.Authors
                .Select(a => new AuthorDto { Id = a.Id, Name = a.Name })
                .ToList();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDto> GetById(int id)
        {
            var author = _context.Authors
                .Where(a => a.Id == id)
                .Select(a => new AuthorDto { Id = a.Id, Name = a.Name })
                .FirstOrDefault();
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public ActionResult<AuthorDto> Create([FromBody] AuthorCreateDto dto)
        {
            var author = new Author { Name = dto.Name };
            _context.Authors.Add(author);
            _context.SaveChanges();
            var result = new AuthorDto { Id = author.Id, Name = author.Name };
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AuthorUpdateDto dto)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return NotFound();
            author.Name = dto.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return NotFound();
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
