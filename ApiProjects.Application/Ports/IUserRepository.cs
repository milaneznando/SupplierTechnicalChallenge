using ApiProjects.Domain.Entities;

namespace ApiProjects.Application.Ports;

/// <summary>
/// Represents a contract for user-related data operations.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user entity based on the provided email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>The user entity corresponding to the specified email address.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no user with the specified email address is found.</exception>
    Task<User?> GetUserByEmail(string email);

    /// <summary>
    /// Adds a user entity asynchronously to the storage.
    /// </summary>
    /// <param name="user">The user entity to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided user entity is null.</exception>
    Task AddAsync(User user);
    
}