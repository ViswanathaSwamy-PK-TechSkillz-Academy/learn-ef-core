using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Publisher.Data;

namespace PublisherApp.Data;

public static class DbContextExtensions
{
    public static PublishersDbContext GetPublishersDbContext(this IConfiguration configuration)
    {
        DbContextOptions<PublishersDbContext> dbContextOptions = new DbContextOptionsBuilder<PublishersDbContext>()
            .UseSqlServer(configuration.GetConnectionString("PublishersDbContext"))
            .Options;

        return new PublishersDbContext(dbContextOptions);
    }
}