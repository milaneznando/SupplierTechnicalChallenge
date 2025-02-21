using ApiProjects.Application.DTOs.Customer;
using ApiProjects.Domain.Entities;

namespace ApiProjects.Application.Ports;

/// <summary>
/// Represents a contract for a repository responsible for managing customer data.
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Retrieves a customer entity from the repository using the provided CPF.
    /// </summary>
    /// <param name="cpf">The CPF (Cadastro de Pessoas Físicas) of the customer to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the customer entity that matches the specified CPF, or null if no match is found.</returns>
    Task<Customer?> GetByCpf(string cpf);

    /// <summary>
    /// Adds a new customer entity to the repository.
    /// </summary>
    /// <param name="customer">The customer entity to be added to the repository.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates the completion status of the operation.</returns>
    Task AddCustomer(Customer customer);

    /// <summary>
    /// Retrieves all customer entities from the repository asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="CustomerDto"/> representing all customers.</returns>
    Task<IEnumerable<CustomerDto>> GetAllAsync();

    /// <summary>
    /// Retrieves a customer entity from the repository using the provided customer ID.
    /// </summary>
    /// <param name="requestCustomerId">The unique identifier of the customer to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the customer entity that matches the specified customer ID, or null if no match is found.</returns>
    Task<CustomerDto> GetById(string customerId);

    /// <summary>
    /// Updates the credit limit of a customer with the specified identifier.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer whose credit limit is to be updated.</param>
    /// <param name="newLimit">The new credit limit value to be assigned to the customer.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates the completion status of the update operation.</returns>
    Task UpdateCustomerLimit(string customerId, decimal newLimit);
}