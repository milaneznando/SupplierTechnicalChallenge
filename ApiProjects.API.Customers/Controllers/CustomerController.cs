using ApiProjects.Application.DTOs.Customer;
using ApiProjects.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ApiProjects.API.Customers.Controllers;

/// <summary>
/// The CustomerController handles all API endpoints related to customer management,
/// including retrieving customer lists and registering new customers.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CustomerController(
    RegisterCustomerUseCase registerCustomerUseCase,
    GetAllCustomersUseCase getAllCustomersUseCase) : ControllerBase
{
    private static readonly MemoryCache _cache = new(new MemoryCacheOptions());
    
    /// <summary>
    /// Retrieves a list of all customers in the system.
    /// </summary>
    /// <returns>An IActionResult containing the list of customer details.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        const string cacheKey = "GetAllCustomersCacheKey";
        
        if(!_cache.TryGetValue(cacheKey, out List<CustomerDto>? customers))
        {
            customers = (await getAllCustomersUseCase.Execute()).ToList();

            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            _cache.Set(cacheKey, customers, cacheOptions);
        }

        return Ok(customers);
    }
    
    /// <summary>
    /// Registers a new customer by processing the provided customer information.
    /// </summary>
    /// <param name="request">The request object containing the customer details to be registered.</param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCustomerRequest request)
    {
        try
        {
            var idCliente = await registerCustomerUseCase.Execute(request);

            // Return a success response
            var response = new RegisterCustomerResponse
            {
                idCliente = idCliente,
                status = "OK"
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            var response = new RegisterCustomerResponse
            {
                status = "ERRO",
                detalheErro = e.Message
            };

            return BadRequest(response);
        }
    }
}