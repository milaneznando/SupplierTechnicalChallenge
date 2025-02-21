using ApiProjects.Application.DTOs;
using ApiProjects.Application.DTOs.Authenticate;
using ApiProjects.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjects.API.Controllers;

/// <summary>
/// Controller responsible for handling user authentication-related operations.
/// </summary>
/// <remarks>
/// Provides actions for managing authentication processes such as user login.
/// Utilizes the mediator pattern to delegate operational logic to the respective handlers.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class AuthController(
    RegisterUserUseCase registerUserUseCase,
    AuthenticateUserUseCase authenticateUserUseCase) : ControllerBase
{
    /// <summary>
    /// Handles the registration of a new user by accepting user details,
    /// validating the information, and creating a new user in the system.
    /// </summary>
    /// <param name="request">An object containing the user's email and password for registration.</param>
    /// <returns>An HTTP response indicating the success or failure of the user registration process.</returns>
    /// <exception cref="Exception">Thrown when a user with the provided email already exists in the system.</exception>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        await registerUserUseCase.Execute(request.Email, request.Password);
        return Ok("User registered successfully");
    }

    /// <summary>
    /// Handles the user authentication process by validating credentials
    /// and returning a JWT token if the credentials are valid.
    /// </summary>
    /// <param name="request">An object containing user login details, including email and password.</param>
    /// <returns>An HTTP response containing a generated JWT token if the login is successful.</returns>
    /// <exception cref="Exception">Thrown when the provided credentials are invalid.</exception>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var jwt = await authenticateUserUseCase.Execute(request.Email, request.Password);
        return Ok(new { Token = jwt });
    }
}
