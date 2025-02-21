using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiProjects.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiProjects.Application.Services;

/// <summary>
/// Provides functionality to generate and validate JSON Web Tokens (JWT) for authentication and authorization purposes.
/// </summary>
public class JwtTokenGenerator(IConfiguration configuration) : IJwtTokenGenerator
{
    private readonly string _jwtSecret = configuration["JwtSettings:Secret"] ??
                                         throw new InvalidOperationException(
                                             "JwtSettings: Secret in not configured as a environment variable.");

    private readonly string _jwtIssuer = configuration["JwtSettings:Issuer"] ??
                                         throw new InvalidOperationException(
                                             "JwtSettings: Issuer in not configured as a environment variable.");

    private readonly string _jwtAudience = configuration["JwtSettings:Audience"] ??
                                         throw new InvalidOperationException(
                                             "JwtSettings: Audience in not configured as a environment variable.");

    /// <summary>
    /// Generates a JWT token for a specific user with the provided claims and expiration time.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="email">The email address of the user.</param>
    /// <param name="expiration">The timespan after which the token will expire.</param>
    /// <returns>Returns a JWT token as a string.</returns>
    public string GenerateToken(Guid userId, string email, TimeSpan expiration)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.Add(expiration),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}