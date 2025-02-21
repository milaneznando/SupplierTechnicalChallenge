namespace ApiProjects.Application.DTOs.Customer;

/// <summary>
/// Represents a request object used for registering a new customer.
/// </summary>
/// <remarks>
/// This class contains the necessary information required to create a customer,
/// including the name, CPF (Cadastro de Pessoas Físicas), and a limit value.
public class RegisterCustomerRequest
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public decimal LimitValue { get; set; }
}