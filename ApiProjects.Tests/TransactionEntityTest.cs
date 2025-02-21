using ApiProjects.Domain.Entities;

namespace ApiProjects.Tests;

/// <summary>
/// Provides unit tests for the <see cref="Transaction"/> class to verify its behavior and properties.
/// </summary>
/// <remarks>
/// Includes test cases to validate initialization, property assignments, and constraints such as
/// allowing negative, zero, or positive values for the transaction.
/// </remarks>
public class TransactionTests
{
    /// <summary>
    /// Tests the initialization of a transaction instance, verifying that it is properly instantiated
    /// with a non-empty unique identifier.
    /// </summary>
    /// <remarks>
    /// Ensures the <see cref="Transaction.Id"/> is assigned a valid unique value upon object creation.
    /// </remarks>
    [Fact]
    public void InitiateWithValidTransaction()
    {
        var transaction = new Transaction();

        Assert.NotEqual(Guid.Empty, transaction.Id);
    }

    /// <summary>
    /// Verifies that the <see cref="Transaction.CustomerId"/> property can be correctly set
    /// and retrieves the assigned value as expected.
    /// </summary>
    /// <remarks>
    /// Ensures that assigning a valid <see cref="Guid"/> to the <see cref="Transaction.CustomerId"/>
    /// property results in the property storing and returning the same value without alteration.
    /// </remarks>
    [Fact]
    public void SetCustomerIdCorrectly()
    {
        var transaction = new Transaction();
        var customerId = Guid.NewGuid();

        transaction.CustomerId = customerId;

        Assert.Equal(customerId, transaction.CustomerId);
    }

    /// <summary>
    /// Verifies that the <see cref="Transaction.Value"/> property can be correctly
    /// set and retrieves the assigned value as expected.
    /// </summary>
    /// <remarks>
    /// Ensures that assigning a valid <see cref="decimal"/> value to the <see cref="Transaction.Value"/>
    /// property results in the property storing and returning the same value without alteration.
    /// </remarks>
    [Fact]
    public void SetValueCorrectly()
    {
        var transaction = new Transaction();
        decimal value = 500.75m;

        transaction.Value = value;

        Assert.Equal(value, transaction.Value);
    }

    /// <summary>
    /// Validates that the <see cref="Transaction.Value"/> property permits assignment of zero and positive values,
    /// ensuring the property accurately stores and retrieves these values without modification.
    /// </summary>
    /// <remarks>
    /// Confirms that when the <see cref="Transaction.Value"/> property is set to zero or a positive decimal value,
    /// it correctly maintains the assigned values, verifying expected behavior for non-negative inputs.
    /// </remarks>
    [Fact]
    public void ValueAllowsZeroOrPositive()
    {
        var transaction = new Transaction();

        transaction.Value = 0;
        var resultWithZero = transaction.Value;

        transaction.Value = 100;
        var resultWithPositiveValue = transaction.Value;

        Assert.Equal(0, resultWithZero);
        Assert.Equal(100, resultWithPositiveValue);
    }

    /// <summary>
    /// Verifies that the <see cref="Transaction.Value"/> property allows assignment of negative values
    /// and accurately stores and retrieves the assigned value.
    /// </summary>
    /// <remarks>
    /// Ensures that assigning a negative decimal value to <see cref="Transaction.Value"/> is permitted
    /// and that the assigned value is retained without modification.
    /// </remarks>
    [Fact]
    public void ShouldAllowNegativeValue()
    {
        var transaction = new Transaction();
        decimal negativeValue = -200.50m;

        transaction.Value = negativeValue;

        Assert.Equal(negativeValue, transaction.Value);
    }
}