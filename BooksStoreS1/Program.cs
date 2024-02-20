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

foreach (var book in books)
{
    Console.WriteLine($"Title: {book.Title}");
    Console.WriteLine($"Author: {book.Author}");
    Console.WriteLine($"Price: {book.Price}");
    Console.WriteLine();
}


new Footer().DisplayFooter('-');