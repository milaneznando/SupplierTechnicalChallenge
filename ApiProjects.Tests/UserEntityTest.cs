using ApiProjects.Domain.Entities;

namespace ApiProjects.Tests;

/// <summary>
/// Test class for the User entity in the domain.
/// </summary>
/// <remarks>
/// This class contains unit tests to verify the behavior and functionality of the User entity.
/// Tests include initialization, email assignment, and password assignment.
/// </remarks>
public class UserTests
{
    /// <summary>
    /// Verifies that creating a new instance of the <see cref="User"/> class generates
    /// a valid <see cref="Guid"/> for the <c>Id</c> property.
    /// </summary>
    /// <remarks>
    /// This test ensures that the <c>Id</c> property of a <see cref="User"/> instance
    /// is not equal to <see cref="Guid.Empty"/> upon initialization, confirming
    /// proper instantiation of the entity.
    /// </remarks>
    [Fact]
    public void InitiateWithValidUser()
    {
        var user = new User();

        Assert.NotEqual(Guid.Empty, user.Id);
    }

    /// <summary>
    /// Verifies that the <c>Email</c> property of the <see cref="User"/> class
    /// is properly set and retains the assigned value.
    /// </summary>
    /// <remarks>
    /// This test ensures that assigning a value to the <c>Email</c> property
    /// correctly stores the value, enabling accurate retrieval of the email address.
    /// </remarks>
    [Fact]
    public void SetEmailCorrectly()
    {
        var user = new User();
        var email = "user@example.com";

        user.Email = email;

        Assert.Equal(email, user.Email);
    }

    /// <summary>
    /// Verifies that the password is correctly assigned to the <see cref="User"/> entity.
    /// </summary>
    /// <remarks>
    /// This test ensures that the <c>Password</c> property of a <see cref="User"/> instance
    /// correctly retains the value that is assigned to it. This confirms that the setter
    /// and storage mechanism for the <c>Password</c> property function as expected.
    /// </remarks>
    [Fact]
    public void SetPasswordCorrectly()
    {
        var user = new User();
        var password = "SecurePassword123";

        user.Password = password;

        Assert.Equal(password, user.Password);
    }
}
