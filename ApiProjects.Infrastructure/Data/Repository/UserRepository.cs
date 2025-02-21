using ApiProjects.Application.Ports;
using ApiProjects.Domain.Entities;
using Dapper;
using MySqlConnector;

namespace ApiProjects.Infrastructure.Data.Repository;

/// <summary>
/// The UserRepository class provides methods for managing user data in a database.
/// It implements the IUserRepository interface.
/// </summary>
public class UserRepository(MySqlConnection connection) : IUserRepository
{
    /// <summary>
    /// Retrieves a user by their email address asynchronously.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>A task representing the asynchronous operation, containing the user if found.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the user is not found.</exception>
    public async Task<User?> GetUserByEmail(string email)
    {
        const string query = "SELECT * FROM Users WHERE Email = @Email LIMIT 1;";
        var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { Email = email });

        return user;
    }

    /// <summary>
    /// Adds a new user to the database asynchronously.
    /// </summary>
    /// <param name="user">The user object containing user details to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(User user)
    {
        const string query = @"
            INSERT INTO Users (Id, Email, Password)
            VALUES (@Id, @Email, @Password);";

        await connection.ExecuteAsync(query, user);
    }
}