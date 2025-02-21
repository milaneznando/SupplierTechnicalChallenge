using ApiProjects.Application.DTOs.Customer;
using ApiProjects.Application.Ports;
using ApiProjects.Domain.Entities;

namespace ApiProjects.Application.UseCases;

/// <summary>
/// Use case responsible for registering new customers in the system.
/// </summary>
public class RegisterCustomerUseCase(ICustomerRepository customerRepository)
{
    /// <summary>
    /// Handles the registration of a new customer.
    /// </summary>
    /// <param name="name">The name of the customer to be registered.</param>
    /// <param name="cpf">The CPF (Cadastro de Pessoas Físicas) of the customer to be registered.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown when a customer with the provided CPF already exists.</exception>
    public async Task<string> Execute(RegisterCustomerRequest request)
    {
        if (await customerRepository.GetByCpf(request.CPF) != null)
            throw new Exception("Customer already exists");

        var customer = new Customer
        {
            Name = request.Name,
            CPF = request.CPF,
            LimitValue = request.LimitValue,
        };
        
        await customerRepository.AddCustomer(customer);
        return customer.Id.ToString();
    }
}