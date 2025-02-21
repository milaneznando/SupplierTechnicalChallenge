using ApiProjects.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApiProjects.Infrastructure.Security;

public class PasswordHasherService(IPasswordHasher<object> passwordHasher) : IPasswordHasherService
{
    /// <summary>
    /// Generates a hashed representation of the provided plain-text password.
    /// </summary>
    /// <param name="password">The plain-text password to hash.</param>
    /// <return>Returns the hashed representation of the input password.</return>
    public string HashPassword(string password)
    {
        return passwordHasher.HashPassword(null, password);
    }

    /// <summary>
    /// Verifies a provided password against a hashed password to determine if they match.
    /// </summary>
    /// <param name="password">The plain-text password to verify.</param>
    /// <param name="hashedPassword">The hashed password to compare against.</param>
    /// <return>Returns true if the password matches the hashed password, otherwise false.</return>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
        
        return result == PasswordVerificationResult.Success;
    }
}