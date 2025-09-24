using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess;

namespace Api.Controllers;

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
    public async Task<IActionResult> GetAll()
    {
        var genres = await _context.Genres.ToListAsync();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre == null) return NotFound();
        return Ok(genre);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Genre genre)
    {
        if (id != genre.Id) return BadRequest();
        _context.Entry(genre).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre == null) return NotFound();
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}