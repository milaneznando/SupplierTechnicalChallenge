namespace ApiProjects.Application.MessageBus;

/// <summary>
/// Represents a producer for publishing messages to a message queue.
/// </summary>
public interface IMessageProducer
{
    /// <summary>
    /// Publishes a message to a specified message queue.
    /// </summary>
    /// <typeparam name="T">The type of the message to be published. Must be a reference type.</typeparam>
    /// <param name="message">The message to be published to the queue.</param>
    /// <param name="queueName">The name of the message queue to which the message will be published.</param>
    void Publish<T>(T message, string queueName) where T : class;
}