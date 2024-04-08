using Microsoft.Extensions.Configuration;

namespace PublisherApp.Configuration;

public static class ConfigurationExtensions
{
    public static IConfigurationRoot GetConfigurationRoot(this IConfigurationBuilder builder)
    {
        return builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .Build();
    }
}