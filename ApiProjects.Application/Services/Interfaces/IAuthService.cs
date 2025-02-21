
using ApiProjects.Application.DTOs.Authenticate;
using ApiProjects.Domain.Entities;

namespace ApiProjects.Application.Services.Interfaces;

/// <summary>
/// Interface for authentication services within the application.
/// </summary>
/// <remarks>
/// Provides methods for user authentication and retrieval, including login and token generation functionalities.
/// </remarks>
public interface IAuthService
{
    TokenResponseDto Login(string email, string password);
    User GetCustomerByEmail(string email);
    Task<TokenResponseDto> Authenticate(string email, string password);
}