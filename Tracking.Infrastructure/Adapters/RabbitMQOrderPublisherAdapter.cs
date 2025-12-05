using Tracking.Domain.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Infrastructure.Adapters
{
    //public class RabbitMQOrderPublisherAdapter: IMensajePublisherPort
    //{
    //    private readonly IConnectionFactory _factory;
    //    private const string ExchangeName = "order_events_exchange";
    //    public RabbitMQOrderPublisherAdapter(IConnectionFactory factory)
    //    {
    //        _factory = factory;
    //    }
    //    public void Publicar(string mensaje, string routingKey)
    //    {
    //        using var connection = _factory.CreateConnectionAsync();
    //        using var channel = connection.CreateModel();

    //        channel.ExchangeDeclare(
    //            exchange: ExchangeName,
    //            type: ExchangeType.Topic,
    //            durable: true 
    //        );

    //        var body = Encoding.UTF8.GetBytes(mensaje);

    //        channel.BasicPublish(
    //            exchange: ExchangeName,
    //            routingKey: routingKey,
    //            basicProperties: null, 
    //            body: body
    //        );

    //        Console.WriteLine($" [x] Sent '{routingKey}':'{mensaje}'");
    //    }
    //}
}
