namespace ApiProjects.Application.DTOs.Authenticate;

/// <summary>
/// Represents a Data Transfer Object (DTO) for token responses.
/// </summary>
/// <remarks>
/// This DTO is used to encapsulate the token information returned upon successful
/// authentication or login operation. It contains the generated token as a property.
/// </remarks>
public class TokenResponseDto(string token)
{
    public string Token { get; set; } = token;
}