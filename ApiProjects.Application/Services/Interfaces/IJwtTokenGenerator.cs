namespace ApiProjects.Application.Services.Interfaces;

/// <summary>
/// Represents a contract for generating JSON Web Tokens (JWT) used for authentication and authorization.
/// </summary>
public interface IJwtTokenGenerator
{
    /// <summary>
    /// Generates a JWT token based on the provided user ID, email, and expiration time.
    /// </summary>
    /// <param name="userId">The unique identifier of the user for whom the token is generated.</param>
    /// <param name="email">The email address of the user.</param>
    /// <param name="expiration">The duration for which the token will be valid.</param>
    /// <returns>Returns a JWT token as a string.</returns>
    string GenerateToken(Guid userId, string email, TimeSpan expiration);
}