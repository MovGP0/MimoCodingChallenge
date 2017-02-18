using Microsoft.Extensions.Configuration;

namespace Mimo.Backend.Tests
{
    public abstract class AppSettingsTest
    {
        protected IConfiguration Configuration { get; } =
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
    }
}