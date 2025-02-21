namespace ApiProjects.Application.DTOs.Authenticate;

/// <summary>
/// Represents a request to register a new user in the system.
/// Contains the necessary information required for user registration.
/// </summary>
public class RegisterUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}