using HeaderFooter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Publisher.Data;
using Publisher.Domain;
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
AddAuthor(new Author { FirstName = "John", LastName = "Doe" });
WriteLine("Successfully added author to the database...");

new Header().DisplayHeader('=', "Books Publisher");

ForegroundColor = ConsoleColor.DarkCyan;

GetAuthors();

new Footer().DisplayFooter('-');

void AddAuthor(Author author)
{
    _context.Authors.Add(author);

    _ = _context.SaveChanges();
}

void GetAuthors()
{
    var authors = _context.Authors.ToList();
    foreach (var author in authors)
    {
        WriteLine(author.FirstName + " " + author.LastName);
    }
}