namespace ApiProjects.Application.DTOs.Customer;

/// <summary>
/// Represents a data transfer object for customer information.
/// </summary>
public class CustomerDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string CPF { get; set; }
    public decimal LimitValue { get; set; }
}