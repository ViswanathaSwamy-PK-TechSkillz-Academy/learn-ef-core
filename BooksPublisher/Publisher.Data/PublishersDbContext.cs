using Microsoft.EntityFrameworkCore;
using Publisher.Domain.Entities;

namespace Publisher.Data;

public class PublishersDbContext(DbContextOptions<PublishersDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Book> Books => Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // It is a BIG NO NO to hard code the connection string in the code
        // optionsBuilder.UseSqlServer("Your Local Db Connection String");
    }
}
