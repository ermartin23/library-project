// Api/DataAccess/DbInitializer.cs
using System;
using System.Linq;

namespace Api.DataAccess
{
    public static class DbInitializer
    {
        public static void Seed(LibraryDbContext context)
        {
            // Database creation 
            context.Database.EnsureCreated();

            // Avoid authors duplication
            if (context.Authors.Any())
                return;

            // Authors
            var authors = new[]
            {
                new Author { Name = "J.K. Rowling" },
                new Author { Name = "George Orwell" },
                new Author { Name = "Isabel Allende" }
            };
            context.Authors.AddRange(authors);

            
            var genres = new[]
            {
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Science Fiction" },
                new Genre { Name = "Drama" }
            };
            context.Genres.AddRange(genres);
            context.SaveChanges();

           
            var books = new[]
            {
                new Book { Title = "Harry Potter and the Philosopher's Stone", AuthorId = authors[0].Id, GenreId = genres[0].Id },
                new Book { Title = "1984", AuthorId = authors[1].Id, GenreId = genres[1].Id },
                new Book { Title = "La Casa de los Espiritus", AuthorId = authors[2].Id, GenreId = genres[2].Id }
            };
            context.Books.AddRange(books);

         
            context.SaveChanges();
        }
    }
}