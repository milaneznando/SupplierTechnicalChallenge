using ApiProjects.Application.Ports;
using ApiProjects.Domain.Entities;

namespace ApiProjects.Application.UseCases;

/// <summary>
/// Represents the use case for adding a new customer.
/// </summary>
public class RegisterUserUseCase(IUserRepository userRepository)
{
    /// <summary>
    /// Executes the registration process for a new user.
    /// </summary>
    /// <param name="email">The email address of the user to be registered.</param>
    /// <param name="password">The password for the user to be registered.</param>
    /// <returns>A task that represents the asynchronous execution of the registration process.</returns>
    /// <exception cref="Exception">Thrown when a user with the specified email already exists.</exception>
    public async Task Execute(string email, string password)
    {
        if (await userRepository.GetUserByEmail(email) != null)
            throw new Exception("User already exists");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User
        {
            Email = email,
            Password = passwordHash,
        };

        await userRepository.AddAsync(user);
    }
}