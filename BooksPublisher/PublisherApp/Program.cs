using HeaderFooter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Publisher.Data;
using Publisher.Domain.Entities;
using Publisher.Domain.Interfaces;
using PublisherApp.Configuration;
using PublisherApp.Data;
using PublisherApp.Services;

IConfigurationRoot configuration = new ConfigurationBuilder().GetConfigurationRoot();
using PublishersDbContext _context = configuration.GetPublishersDbContext();

ForegroundColor = ConsoleColor.DarkMagenta;
WriteLine("Database is being created...");
_context.Database.EnsureCreated();
WriteLine("Database is created.\n");

IAuthorService authorService = new AuthorService(_context);

ForegroundColor = ConsoleColor.DarkGreen;
WriteLine("Adding author to the database...");
await authorService.AddAuthor(new Author { FirstName = "John", LastName = "Doe" });
WriteLine("Successfully added author to the database...");

new Header().DisplayHeader('=', "Books Publisher");

ForegroundColor = ConsoleColor.DarkCyan;

IReadOnlyCollection<Author> authors = await authorService.GetAuthors();
foreach (Author author in authors)
{
    WriteLine($"{author.Id} | {author.FirstName} | {author.LastName}");
}

new Footer().DisplayFooter('-');
