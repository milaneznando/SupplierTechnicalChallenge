using ApiProjects.Application.Ports;
using ApiProjects.Application.Services.Interfaces;

namespace ApiProjects.Application.UseCases;

/// <summary>
/// Use case responsible for authenticating a user using provided email and password.
/// </summary>
/// <remarks>
/// Validates user credentials against the repository and generates a JWT token upon successful validation.
/// </remarks>
/// <example>
/// This use case is utilized to handle authentication logic in the application's authentication flow,
/// such as verifying user credentials and generating access tokens.
/// </example>
/// <exception cref="Exception">Thrown when the provided credentials are invalid.</exception>
/// <param name="userRepository">Repository interface for performing user-related operations.</param>
/// <param name="jwtTokenGenerator">Interface responsible for generating JWT tokens.</param>
public class AuthenticateUserUseCase(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
{
    /// <summary>
    /// Authenticates a user using the provided email and password, and generates a JSON Web Token (JWT) upon successful verification.
    /// </summary>
    /// <param name="email">The email address of the user attempting to authenticate.</param>
    /// <param name="password">The password corresponding to the provided email address.</param>
    /// <returns>A JWT string representing the authenticated user's session.</returns>
    /// <exception cref="Exception">Thrown when the provided email or password is invalid.</exception>
    public async Task<string> Execute(string email, string password)
    {
        var user = await userRepository.GetUserByEmail(email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new Exception("Invalid credentials");

        return jwtTokenGenerator.GenerateToken(user.Id, user.Email, TimeSpan.FromHours(1));
    }
}