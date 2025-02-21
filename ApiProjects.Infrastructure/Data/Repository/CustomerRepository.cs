using ApiProjects.Application.DTOs.Customer;
using ApiProjects.Application.Ports;
using ApiProjects.Domain.Entities;
using Dapper;
using MySqlConnector;

namespace ApiProjects.Infrastructure.Data.Repository;

/// <summary>
/// CustomerRepository is a MySQL-based implementation of the ICustomerRepository interface.
/// This class provides methods to interact with customer data.
/// </summary>
/// <remarks>
/// It allows retrieving customer records by CPF and adding new customers to the repository.
/// </remarks>
public class CustomerRepository(MySqlConnection connection) : ICustomerRepository
{
    /// <summary>
    /// Retrieves a customer by their CPF number from the repository.
    /// </summary>
    /// <param name="cpf">The CPF number of the customer to retrieve.</param>
    /// <returns>A <see cref="Customer"/> object if found, otherwise null.</returns>
    public async Task<Customer?> GetByCpf(string cpf)
    {
        const string query = "SELECT * FROM Customers WHERE CPF = @CPF LIMIT 1;";
        var customer = await connection.QueryFirstOrDefaultAsync<Customer>(query, new { cpf = cpf });

        return customer;
    }

    /// <summary>
    /// Adds a new customer to the repository.
    /// </summary>
    /// <param name="customer">The customer entity to be added to the repository.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddCustomer(Customer customer)
    {
        const string query = @"
            INSERT INTO Customers (Id, Name, CPF, LimitValue)
            VALUES (@Id, @Name, @CPF, @LimitValue);";

        await connection.ExecuteAsync(query, customer);
    }

    /// <summary>
    /// Retrieves all customers from the repository asynchronously.
    /// </summary>
    /// <returns>An enumerable collection of <see cref="CustomerDto"/> objects representing the customers.</returns>
    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        const string query = "SELECT Id, Name, CPF, LimitValue FROM Customers;";
        
        return await connection.QueryAsync<CustomerDto>(query);
    }

    /// <summary>
    /// Retrieves a customer's details by their unique identifier from the repository.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer to retrieve.</param>
    /// <returns>A <see cref="CustomerDto"/> object containing the customer's details if found.</returns>
    public async Task<CustomerDto> GetById(string customerId)
    {
        const string query = "SELECT Id, Name, CPF, LimitValue FROM Customers WHERE Id = @Id LIMIT 1;";
        var customer = await connection.QueryFirstOrDefaultAsync<CustomerDto>(query, new { Id = customerId });

        return customer;
    }

    /// <summary>
    /// Updates the credit limit of a specific customer in the repository.
    /// </summary>
    /// <param name="customerId">The unique identifier of the customer whose limit is to be updated.</param>
    /// <param name="newLimit">The new credit limit value to set for the customer.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task UpdateCustomerLimit(string customerId, decimal newLimit)
    {
        const string query = @"
            UPDATE customers
            SET LimitValue = @NewLimit
            WHERE Id = @Id;";
        
        await connection.ExecuteAsync(query, new { Id = customerId, NewLimit = newLimit });
    }
}