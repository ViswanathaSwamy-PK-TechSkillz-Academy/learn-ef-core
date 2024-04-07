using HeaderFooter;
using Microsoft.Extensions.Configuration;
using Publisher.Data;
using PublisherApp.Configuration;
using PublisherApp.Data;

IConfigurationRoot configuration = new ConfigurationBuilder().GetConfigurationRoot();
using PublishersDbContext _context = configuration.GetPublishersDbContext();

ForegroundColor = ConsoleColor.DarkMagenta;
WriteLine("Database is being created...");
_context.Database.EnsureCreated();
WriteLine("Database is created.\n");

new Header().DisplayHeader('=', "Books Publisher");

ForegroundColor = ConsoleColor.DarkCyan;

new Footer().DisplayFooter('-');
