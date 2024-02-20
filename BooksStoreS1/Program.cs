using HeaderFooter.Interfaces;
using HeaderFooter;
using Microsoft.Extensions.Configuration;
using BooksStoreS1.Persistence;
using Microsoft.EntityFrameworkCore;

var _configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();

DbContextOptions<BooksStoreDbContext> dbContextOptions = new DbContextOptionsBuilder<BooksStoreDbContext>()
    .UseSqlServer(_configuration.GetConnectionString("BooksStoreDbContext"))
    .Options;

BooksStoreDbContext _context = new(dbContextOptions);

new Header().DisplayHeader('=', "Books Store");

var books = await _context.Books.AsNoTracking().ToListAsync();

ForegroundColor = ConsoleColor.DarkCyan;

WriteLine("{0,10} {1,18} {2,30}\n", "Title", "Author", "Price");

foreach (var book in books)
{
    Console.WriteLine($"{book.Title, 10} {book.Author, 20} {book.Price, 30}");
}

new Footer().DisplayFooter('-');