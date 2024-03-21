using HeaderFooter.Interfaces;
using HeaderFooter;
using Microsoft.Extensions.Configuration;
using BooksStoreS1.Persistence;
using Microsoft.EntityFrameworkCore;
using BooksStoreS1.Entities;

using BooksStoreDbContext _context = GetBooksStoreDbContext();

_context.Database.EnsureCreated();

new Header().DisplayHeader('=', "Books Store");

List<Book>? books = await _context.Books.AsNoTracking().ToListAsync();

ForegroundColor = ConsoleColor.DarkCyan;

WriteLine(string.Format("{0,10} | {1,-10} | {2,10}", "Title", " Author".PadRight(35), "Price"));

foreach (Book? book in books)
{
    WriteLine(string.Format("{0,10} | {1,-10} | {2,10}", book.Title, book.Author.PadRight(35), book.Price));
}

new Footer().DisplayFooter('-');

static BooksStoreDbContext GetBooksStoreDbContext()
{
    IConfigurationRoot _configuration = GetConfigurationRoot();

    DbContextOptions<BooksStoreDbContext> dbContextOptions = new DbContextOptionsBuilder<BooksStoreDbContext>()
    .UseSqlServer(_configuration.GetConnectionString("BooksStoreDbContext"))
    .Options;

    return new(dbContextOptions);
}

static IConfigurationRoot GetConfigurationRoot()
{
    return new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddUserSecrets<Program>()
        .Build();
}
