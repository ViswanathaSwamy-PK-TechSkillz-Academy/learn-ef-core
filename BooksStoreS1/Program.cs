using HeaderFooter.Interfaces;
using HeaderFooter;
using Microsoft.Extensions.Configuration;

var _configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();


new Header().DisplayHeader('=', "Books Store");


new Footer().DisplayFooter('-');