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

        // GET all genres
        [HttpGet]
        public IActionResult GetAll()
        {
            var genres = _context.Genres
                .Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();

            return Ok(genres);
        }

        // GET genre by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _context.Genres
                .Where(g => g.Id == id)
                .Select(g => new GenreDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .FirstOrDefault();

            if (genre == null) return NotFound();
            return Ok(genre);
        }

        // POST create new genre
        [HttpPost]
        public IActionResult Create([FromBody] GenreCreateDto dto)
        {
            var genre = new Genre
            {
                Name = dto.Name
            };

            _context.Genres.Add(genre);
            _context.SaveChanges();

            var result = new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };

            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, result);
        }

        // PUT update genre
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GenreUpdateDto dto)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();

            genre.Name = dto.Name;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE genre
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
