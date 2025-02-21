using ApiProjects.Infrastructure.Configuration.Environment;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiProjects.Infrastructure.Configuration;

/// <summary>
/// Provides configuration and extension methods for setting up environment-dependent variables and configurations in the application.
/// </summary>
public static class EnvironmentSetup
{
    /// <summary>
    /// Configures environment variables for the application by binding a specific configuration section
    /// to the corresponding strongly-typed configuration object.
    /// </summary>
    /// <param name="serviceCollection">The collection of service descriptors for dependency injection.</param>
    /// <param name="configuration">The application's configuration properties.</param>
    public static void AddEnvironmentVariables(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<MySqlConfig>(configuration.GetSection(EnvironmentConstants.MySqlConfigName));
    }
}