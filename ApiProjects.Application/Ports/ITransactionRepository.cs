using ApiProjects.Domain.Entities;

namespace ApiProjects.Application.Ports;

public interface ITransactionRepository
{
    Task CreateTransaction(Transaction transaction);
}