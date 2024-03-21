using HeaderFooter;
using Microsoft.Extensions.Configuration;

new Header().DisplayHeader('=', "Books Publisher");

new Footer().DisplayFooter('-');

static IConfigurationRoot GetConfigurationRoot()
{
    return new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddUserSecrets<Program>()
        .Build();
}
