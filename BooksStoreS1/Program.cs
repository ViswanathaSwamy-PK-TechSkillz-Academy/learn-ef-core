using HeaderFooter.Interfaces;
using HeaderFooter;
using Microsoft.Extensions.Configuration;
using BooksStoreS1.Persistence;
using Microsoft.EntityFrameworkCore;
using BooksStoreS1.Entities;

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

WriteLine(string.Format("{0,10} | {1,-10} | {2,10}", "Title", " Author".PadRight(35), "Price"));

foreach (var book in books)
{
    WriteLine(string.Format("{0,10} | {1,-10} | {2,10}", book.Title, book.Author.PadRight(35), book.Price));
}

new Footer().DisplayFooter('-');