namespace ApiProjects.Domain.Entities;

/// <summary>
/// Represents a customer entity within the domain model.
/// </summary>
public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string CPF { get; set; }
    
    private decimal _limitValue;
    public decimal LimitValue
    {
        get => _limitValue;
        set => _limitValue = value >= 0
            ? value
            : throw new ArgumentException("Limit value must be greater or equal to zero");
    }

    /// <summary>
    /// Updates the customer's limit value with a new specified value.
    /// </summary>
    /// <param name="newLimit">The new limit value to be set for the customer. Must be greater or equal to zero.</param>
    /// <exception cref="InvalidOperationException">Thrown when the provided limit value is less than zero.</exception>
    public void UpdateLimit(decimal newLimit)
    {
        if (newLimit < 0)
            throw new InvalidOperationException("Limit value must be greater or equal to zero");
        
        LimitValue = newLimit;
    }
}