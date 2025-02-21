using ApiProjects.Infrastructure.Configuration.Environment;
using ApiProjects.Infrastructure.Data.Mapping;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace ApiProjects.Infrastructure.IoC;

/// <summary>
/// Provides extension methods for configuring database-related services in the application's dependency injection container.
/// </summary>
public static class DatabaseIoC
{
    /// <summary>
    /// Registers the database connection service into the dependency injection container.
    /// </summary>
    /// <param name="serviceCollection">The service collection to which the database service is added.</param>
    /// <param name="configuration">The application configuration from which the connection string is retrieved.</param>
    public static void AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        SqlMapper.AddTypeHandler(new GuidTypeHandler());
        SqlMapper.RemoveTypeMap(typeof(Guid));
        SqlMapper.RemoveTypeMap(typeof(Guid?));
        
        serviceCollection.AddTransient(_ =>
            new MySqlConnection(configuration.GetConnectionString(EnvironmentConstants.MySqlConfigName)));
        
    }
}