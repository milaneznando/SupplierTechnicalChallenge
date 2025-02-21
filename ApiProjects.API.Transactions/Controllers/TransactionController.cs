using ApiProjects.Application.DTOs.Transaction;
using ApiProjects.Application.MessageBus;
using ApiProjects.Application.UseCases;
using ApiProjects.Domain.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjects.API.Transactions.Controllers;

/// <summary>
/// Handles transaction-related operations within the API, such as simulating
/// financial transactions while ensuring customer data validation and limit enforcement.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TransactionController(
    SimulateTransactionUseCase simulateTransactionUseCase,
    CompleteTransactionUseCase completeTransactionUseCase,
    IMessageProducer messageProducer) : ControllerBase
{
    /// <summary>
    /// Simulates a financial transaction by verifying customer data, ensuring the requested limit does not exceed
    /// the customer's available limit, and updates the customer's limit if approved.
    /// </summary>
    /// <param name="request">The transaction simulation request, including customer ID and requested transaction limit.</param>
    /// <returns>
    /// A response indicating whether the transaction was approved or rejected, along with relevant details,
    /// such as a message and transaction ID if approved.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> SimulateTransaction([FromBody] SimulateTransactionRequest request)
    {
        var customer = await simulateTransactionUseCase.Execute(request);
        if (customer == null)
            return BadRequest(new { message = "Customer not found." });

        if(request.Limit > customer.LimitValue)
            return BadRequest(new { Approved = false, Message = "Requested value exceeds the customer limit." });
        
        var completeTransactionId = await completeTransactionUseCase.Execute(customer, request.Limit);
        
        var updateLimitEvent = new UpdateLimitEvent
        {
            ClientId = customer.Id,
            NewLimit = customer.LimitValue - request.Limit
        };

        messageProducer.Publish(updateLimitEvent, "limit_update_queue");

        return Ok(new
        {
            Approved = true,
            Message = "Transaction approved.",
            TransactionId = completeTransactionId
        });
    }
}