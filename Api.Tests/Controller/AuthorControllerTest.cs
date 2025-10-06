using Api.Controllers;
using Api.DataAccess;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Api.Tests.Controllers
{
    public class AuthorControllerTests
    {
        private readonly LibraryDbContext _context;
        private readonly AuthorController _controller;

        public AuthorControllerTests()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new LibraryDbContext(options);
            _context.Authors.AddRange(
                new Author { Id = 1, Name = "Author 1" },
                new Author { Id = 2, Name = "Author 2" }
            );
            _context.SaveChanges();

            _controller = new AuthorController(_context);
        }

        [Fact]
        public void GetAll_ReturnsAllAuthors()
        {
            var result = _controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var authors = Assert.IsType<List<AuthorDto>>(okResult.Value);
            Assert.Equal(2, authors.Count);
        }

        [Fact]
        public void GetById_ReturnsSingleAuthor()
        {
            var result = _controller.GetById(1);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var author = Assert.IsType<AuthorDto>(okResult.Value);
            Assert.Equal("Author 1", author.Name);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenInvalidId()
        {
            var result = _controller.GetById(99);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_AddsNewAuthor()
        {
            var dto = new AuthorCreateDto { Name = "New Author" };
            var result = _controller.Create(dto);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var author = Assert.IsType<AuthorDto>(createdResult.Value);
            Assert.Equal("New Author", author.Name);
        }

        [Fact]
        public void Update_ChangesAuthorName()
        {
            var updateDto = new AuthorUpdateDto { Name = "Updated Author" };
            var result = _controller.Update(1, updateDto);
            Assert.IsType<NoContentResult>(result);
            var updated = _context.Authors.Find(1);
            Assert.Equal("Updated Author", updated.Name);
        }

        [Fact]
        public void Delete_RemovesAuthor()
        {
            var result = _controller.Delete(1);
            Assert.IsType<NoContentResult>(result);
            var author = _context.Authors.Find(1);
            Assert.Null(author);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenInvalidId()
        {
            var result = _controller.Delete(999);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
