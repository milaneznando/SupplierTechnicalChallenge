using ApiProjects.Domain.Entities;

namespace ApiProjects.Tests;

/// <summary>
/// Contains unit tests for the <see cref="Customer"/> class, ensuring proper behavior and validation of its properties and methods.
/// </summary>
public class CustomerTests
{
    /// <summary>
    /// Verifies that a new instance of the <see cref="Customer"/> class is initialized with a valid non-empty identifier.
    /// </summary>
    [Fact]
    public void InitiateWithValidCustomer()
    {
        var customer = new Customer();

        Assert.NotEqual(Guid.Empty, customer.Id);
    }

    /// <summary>
    /// Assigns a valid, non-negative limit value to the <see cref="Customer.LimitValue"/> property
    /// and verifies that the assigned value is stored correctly.
    /// </summary>
    [Fact]
    public void SetValidLimitValue()
    {
        var customer = new Customer();

        customer.LimitValue = 100;

        Assert.Equal(100, customer.LimitValue);
    }

    /// <summary>
    /// Ensures that assigning a negative value to the <see cref="Customer.LimitValue"/> property
    /// throws an <see cref="ArgumentException"/> with the correct error message.
    /// </summary>
    [Fact]
    public void LimitValueWithNegativeValueThrowException()
    {
        var customer = new Customer();

        var exception = Assert.Throws<ArgumentException>(() => customer.LimitValue = -1);
        Assert.Equal("Limit value must be greater or equal to zero", exception.Message);
    }

    /// <summary>
    /// Updates the limit value of a <see cref="Customer"/> instance with a valid, non-negative value
    /// and verifies that the updated value is correctly stored.
    /// </summary>
    [Fact]
    public void UpdateLimitValidValue()
    {
        var customer = new Customer();
        decimal newLimit = 200;

        customer.UpdateLimit(newLimit);

        Assert.Equal(newLimit, customer.LimitValue);
    }

    /// <summary>
    /// Verifies that invoking the <see cref="Customer.UpdateLimit"/> method with a negative value
    /// throws an <see cref="InvalidOperationException"/> with the appropriate error message.
    /// </summary>
    [Fact]
    public void UpdateLimitWithNegativeValueThrowException()
    {
        var customer = new Customer();

        var exception = Assert.Throws<InvalidOperationException>(() => customer.UpdateLimit(-10));
        Assert.Equal("Limit value must be greater or equal to zero", exception.Message);
    }

    /// <summary>
    /// Ensures that the <see cref="Customer.Name"/> and <see cref="Customer.CPF"/> properties
    /// are successfully updated and reflect the new values assigned.
    /// </summary>
    [Fact]
    public void CustomerUpdateNameAndCpf()
    {
        var customer = new Customer
        {
            Name = "John Doe",
            CPF = "12345678900"
        };

        customer.Name = "Jane Doe";
        customer.CPF = "09876543211";

        Assert.Equal("Jane Doe", customer.Name);
        Assert.Equal("09876543211", customer.CPF);
    }
}
