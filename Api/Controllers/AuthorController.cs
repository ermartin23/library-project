using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.DataAccess;

namespace Api.Controllers;

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
    public async Task<IActionResult> GetAll()
    {
        var authors = await _context.Authors.ToListAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Author author)
    {
        if (id != author.Id) return BadRequest();
        _context.Entry(author).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return NotFound();
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}