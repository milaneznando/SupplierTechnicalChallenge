namespace ApiProjects.Domain.Entities;

/// <summary>
/// Represents a user entity within the domain.
/// </summary>
/// <remarks>
/// Provides properties including a unique identifier (Id), an email, and a password.
/// This entity is utilized for authentication and user management features within the system.
/// The constructor initializes the email and password properties for a new user instance.
/// </remarks>
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string Password { get; set; }
}