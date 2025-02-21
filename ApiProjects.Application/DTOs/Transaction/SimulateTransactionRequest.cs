namespace ApiProjects.Application.DTOs.Transaction;

/// <summary>
/// Represents a request to simulate a financial transaction.
/// </summary>
public class SimulateTransactionRequest
{
    public string CustomerId { get; set; }
    public decimal Limit { get; set; }
}