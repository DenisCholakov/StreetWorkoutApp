using Microsoft.Extensions.Configuration;

namespace StreetWorkoutApp.Server.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConfiguration(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}
