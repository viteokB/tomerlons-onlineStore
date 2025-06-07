using Microsoft.Extensions.Configuration;

namespace OnlineStore.UI.DI;

public static class ConfigurationBuilder
{
    public static IConfiguration Build()
    {
        return new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
}