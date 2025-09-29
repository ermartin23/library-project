using Microsoft.AspNetCore.Mvc;
using Api.DataAccess;
using Api.Dtos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public GenreController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<GenreDto>> GetAll()
        {
            var genres = _context.Genres
                .Select(g => new GenreDto { Id = g.Id, Name = g.Name })
                .ToList();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public ActionResult<GenreDto> GetById(int id)
        {
            var genre = _context.Genres
                .Where(g => g.Id == id)
                .Select(g => new GenreDto { Id = g.Id, Name = g.Name })
                .FirstOrDefault();
            if (genre == null) return NotFound();
            return Ok(genre);
        }

        [HttpPost]
        public ActionResult<GenreDto> Create([FromBody] GenreCreateDto dto)
        {
            var genre = new Genre { Name = dto.Name };
            _context.Genres.Add(genre);
            _context.SaveChanges();
            var result = new GenreDto { Id = genre.Id, Name = genre.Name };
            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GenreUpdateDto dto)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();
            genre.Name = dto.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
