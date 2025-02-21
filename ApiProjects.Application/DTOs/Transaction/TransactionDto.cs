namespace ApiProjects.Application.DTOs.Transaction;

/// <summary>
/// Represents a data transfer object for a transaction.
/// </summary>
public class TransactionDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public decimal Value { get; set; }
}