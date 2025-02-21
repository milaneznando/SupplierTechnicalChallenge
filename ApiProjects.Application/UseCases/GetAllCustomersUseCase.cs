using ApiProjects.Application.DTOs.Customer;
using ApiProjects.Application.Ports;

namespace ApiProjects.Application.UseCases;

/// <summary>
/// Represents a use case for retrieving all customers from the repository.
/// </summary>
public class GetAllCustomersUseCase(ICustomerRepository customerRepository)
{
    /// <summary>
    /// Executes the use case for retrieving all customers from the repository.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains an enumerable collection of <see cref="CustomerDto"/> objects representing all customers.</returns>
    public async Task<IEnumerable<CustomerDto>> Execute()
    {
        return await customerRepository.GetAllAsync();
    }
}