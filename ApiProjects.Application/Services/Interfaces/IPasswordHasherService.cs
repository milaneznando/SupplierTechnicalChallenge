namespace ApiProjects.Application.Services.Interfaces;

/// <summary>
/// Provides services for hashing and verifying passwords.
/// </summary>
public interface IPasswordHasherService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}