using System.Text;
using ApiProjects.Application.MessageBus;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ApiProjects.Infrastructure.MessageBus;

/// <summary>
/// A RabbitMQ-based implementation of the <see cref="IMessageProducer"/> interface
/// that provides functionality for publishing messages to a specified queue.
/// </summary>
public class RabbitMqProducer(IConnection connection) : IMessageProducer
{
    public void Publish<T>(T message, string queueName) where T : class
    {
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "",
            routingKey: queueName,
            basicProperties: null,
            body: body);
    }
}