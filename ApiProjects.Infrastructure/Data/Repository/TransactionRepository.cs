using ApiProjects.Application.DTOs.Transaction;
using ApiProjects.Application.Ports;
using ApiProjects.Domain.Entities;
using Dapper;
using MySqlConnector;

namespace ApiProjects.Infrastructure.Data.Repository;

/// <summary>
/// Handles operations for managing transactions in the underlying data store.
/// Provides methods to perform actions like creating a transaction.
/// </summary>
public class TransactionRepository(MySqlConnection connection) : ITransactionRepository
{
    /// <summary>
    /// Creates a new transaction in the data store.
    /// </summary>
    /// <param name="transaction">The transaction object containing details such as the associated customer ID and transaction value.</param>
    /// <returns>A task representing the asynchronous operation of creating the transaction.</returns>
    public async Task CreateTransaction(Transaction transaction)
    {
        const string query = @"
            INSERT INTO Transactions (Id, CustomerId, Value)
            VALUES (@Id, @CustomerId, @Value);";
        
        await connection.ExecuteAsync(query, transaction);
    }
}