using HeaderFooter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Publisher.Data;


new Header().DisplayHeader('=', "Books Publisher");

using PublishersDbContext _context = GetPublishersDbContext();

ForegroundColor = ConsoleColor.DarkMagenta;
WriteLine("Database is being created...");
_context.Database.EnsureCreated();
WriteLine("Database is created.");

ForegroundColor = ConsoleColor.DarkCyan;

new Footer().DisplayFooter('-');

static PublishersDbContext GetPublishersDbContext()
{
    IConfigurationRoot _configuration = GetConfigurationRoot();

    DbContextOptions<PublishersDbContext> dbContextOptions = new DbContextOptionsBuilder<PublishersDbContext>()
    .UseSqlServer(_configuration.GetConnectionString("PublishersDbContext"))
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
