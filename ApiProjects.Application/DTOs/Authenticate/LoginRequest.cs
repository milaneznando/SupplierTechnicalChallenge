namespace ApiProjects.Application.DTOs;

/// <summary>
/// Represents a Data Transfer Object for user login information.
/// Provides properties for storing user credentials like Email and Password.
/// </summary>
public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}