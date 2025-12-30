using LogiTrackLite.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Tracking.Application.Interfaces;
using Tracking.Infrastructure.Messaging.RabbitMQ.Abstractions;
using Tracking.Infrastructure.Messaging.RabbitMQ.Events;

public class PackageCreatedConsumer : ITrackingConsumer
{
    private readonly IRabbitMqConnection _connection;
    private readonly IServiceProvider _serviceProvider;

    public PackageCreatedConsumer(IRabbitMqConnection connection, IServiceProvider serviceProvider)
    {
        _connection = connection;
        _serviceProvider = serviceProvider;
    }

    public async Task StartConsuming(CancellationToken ct)
    {
        // 1. Creamos el canal usando la conexión global
        using var channel = await _connection.CreateChannelAsync();

        await channel.ExchangeDeclareAsync(exchange: "package_events", type: ExchangeType.Topic);
        QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync(queue: "tracking.package.queue",
                                            durable: true,
                                            exclusive: false,
                                            autoDelete: false);
        string queueName = queueDeclareResult.QueueName;


        await channel.QueueBindAsync(queue: "tracking.package.queue", exchange: "package_events", routingKey: "package.*");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"{message}");
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync("tracking.package.queue", autoAck: true, consumer: consumer);

    }
}