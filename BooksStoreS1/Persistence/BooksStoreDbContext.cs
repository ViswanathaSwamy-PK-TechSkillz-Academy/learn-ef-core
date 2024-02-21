using BooksStoreS1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreS1.Persistence;

public class BooksStoreDbContext(DbContextOptions<BooksStoreDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
}