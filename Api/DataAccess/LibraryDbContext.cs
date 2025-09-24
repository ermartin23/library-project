using Microsoft.EntityFrameworkCore;

namespace Api.DataAccess;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Author>().ToTable("Authors");
        modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<Genre>().ToTable("Genres");
    }
}