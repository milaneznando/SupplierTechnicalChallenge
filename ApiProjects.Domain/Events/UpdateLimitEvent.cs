namespace ApiProjects.Domain.Events;

/// <summary>
/// Represents an event that is triggered to update the limit of a specific client.
/// </summary>
public class UpdateLimitEvent
{
    public Guid ClientId { get; set; }
    public decimal NewLimit { get; set; }
}
