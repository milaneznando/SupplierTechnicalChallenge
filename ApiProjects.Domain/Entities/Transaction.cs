namespace ApiProjects.Domain.Entities;

/// <summary>
/// Represents a monetary transaction linked to a customer.
/// </summary>
public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public decimal Value { get; set; }
}