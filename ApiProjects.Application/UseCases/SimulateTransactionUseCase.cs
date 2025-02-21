using ApiProjects.Application.DTOs.Customer;
using ApiProjects.Application.DTOs.Transaction;
using ApiProjects.Application.Ports;

namespace ApiProjects.Application.UseCases;

/// <summary>
/// Simulates a transaction for a customer based on their ID and returns customer information.
/// </summary>
/// <remarks>
/// This use case retrieves a customer's details from the repository, constructs a DTO with their
/// information, and returns it for further processing or use within the application.
/// </remarks>
/// <param name="customerRepository">
/// The repository interface for accessing customer-related data.
/// It provides methods to interact with the customer's data source, such as retrieving by ID.
/// </param>
public class SimulateTransactionUseCase(
    ICustomerRepository customerRepository)
{
    /// <summary>
    /// Executes the process of retrieving customer information and mapping it to a DTO.
    /// </summary>
    /// <param name="customerId">The unique identifier for the customer to be retrieved.</param>
    /// <returns>A <see cref="CustomerDto"/> instance containing customer data.</returns>
    public async Task<CustomerDto> Execute(SimulateTransactionRequest request)
    {
        var customer = await customerRepository.GetById(request.CustomerId);

        return customer;
    }
}