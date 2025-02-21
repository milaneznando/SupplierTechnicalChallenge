using ApiProjects.Application.DTOs.Customer;
using ApiProjects.Application.DTOs.Transaction;
using ApiProjects.Application.Ports;
using ApiProjects.Domain.Entities;

namespace ApiProjects.Application.UseCases;

public class CompleteTransactionUseCase(
    ITransactionRepository transactionRepository,
    ICustomerRepository customerRepository)
{
    public async Task<string> Execute(CustomerDto customer, decimal limit)
    {
        var transaction = new Transaction
        {
            CustomerId = customer.Id,
            Value = limit,
        };
        
        await transactionRepository.CreateTransaction(transaction);
        await customerRepository.UpdateCustomerLimit(customer.Id.ToString(), customer.LimitValue - limit);
        
        var tsId = transaction.Id.ToString();
        return tsId;
    }
}