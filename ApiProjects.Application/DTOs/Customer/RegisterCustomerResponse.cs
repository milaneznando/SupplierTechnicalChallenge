using System.Text.Json.Serialization;

namespace ApiProjects.Application.DTOs.Customer;

/// <summary>
/// Represents the response data for registering a customer.
/// </summary>
public class RegisterCustomerResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string idCliente { get; set; }
    public string status { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string detalheErro { get; set; }
}