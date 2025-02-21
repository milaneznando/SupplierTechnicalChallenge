using Microsoft.Extensions.DependencyInjection;

namespace ApiProjects.Infrastructure.IoC;

/// <summary>
/// Provides an extension method to configure dependency injection setup for the application.
/// </summary>
public static class InjectionDependencySetup
{
    /// <summary>
    /// Configures and registers dependency injection services for the application.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance used to register services with the dependency injection container.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="services"/> parameter is null.</exception>
    public static void AddDependencyInjectionSetup(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        
        services.RegisterServices();
    }
}