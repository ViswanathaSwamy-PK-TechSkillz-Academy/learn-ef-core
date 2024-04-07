using HeaderFooter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Publisher.Data;
using Publisher.Domain.Entities;
using PublisherApp.Configuration;
using PublisherApp.Data;

IConfigurationRoot configuration = new ConfigurationBuilder().GetConfigurationRoot();
using PublishersDbContext _context = configuration.GetPublishersDbContext();

ForegroundColor = ConsoleColor.DarkMagenta;
WriteLine("Database is being created...");
_context.Database.EnsureCreated();
WriteLine("Database is created.\n");

ForegroundColor = ConsoleColor.DarkGreen;
WriteLine("Adding author to the database...");
await AddAuthor(new Author { FirstName = "John", LastName = "Doe" });
WriteLine("Successfully added author to the database...");

new Header().DisplayHeader('=', "Books Publisher");

ForegroundColor = ConsoleColor.DarkCyan;

await GetAuthors();

new Footer().DisplayFooter('-');

async Task AddAuthor(Author author)
{
    await _context.Authors.AddAsync(author);

    _ = await _context.SaveChangesAsync();
}

async Task GetAuthors()
{
    var authors = await _context.Authors.ToListAsync();
    foreach (var author in authors)
    {
        WriteLine(author.FirstName + " " + author.LastName);
    }
}