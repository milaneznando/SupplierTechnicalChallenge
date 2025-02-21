using ApiProjects.Application.MessageBus;
using ApiProjects.Application.Ports;
using ApiProjects.Application.Services;
using ApiProjects.Application.Services.Interfaces;
using ApiProjects.Application.UseCases;
using ApiProjects.Infrastructure.Data.Repository;
using ApiProjects.Infrastructure.MessageBus;
using ApiProjects.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ApiProjects.Infrastructure.IoC;

/// <summary>
/// Provides a method to register multiple services and dependencies
/// for the application's Inversion of Control (IoC) container.
/// </summary>
public static class Bootstrapper
{
    /// <summary>
    /// Registers application services, use cases, MediatR services, password hashing services,
    /// and repository dependencies into the provided service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services and dependencies to.</param>
    public static void RegisterServices(this IServiceCollection services)
    {
        // Use Cases
        services.AddScoped<RegisterUserUseCase>();
        services.AddScoped<AuthenticateUserUseCase>();
        services.AddScoped<RegisterCustomerUseCase>();
        services.AddScoped<GetAllCustomersUseCase>();
        services.AddScoped<SimulateTransactionUseCase>();
        services.AddScoped<CompleteTransactionUseCase>();

        // RabbitMQ
        services.AddScoped<IMessageProducer, RabbitMqProducer>();
        
        // Application Services
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        services.AddScoped<IPasswordHasher<object>, PasswordHasher<object>>();
        services.AddScoped<PasswordHasherService>();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
    }
}