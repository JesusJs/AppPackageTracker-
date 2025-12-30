using LogiTrackLite.Shared;
using LogiTrackLite.Shared.Interfaces;
using Package.Application.Interfaces;
using Package.Domain.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Package.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMqPackageEventPublisher : IPackageEventPublisher
    {
        private readonly IRabbitMqConnection _rabbitConnection;
        public RabbitMqPackageEventPublisher(IRabbitMqConnection rabbitConnection)
        {
            _rabbitConnection = rabbitConnection;
        }
        public async Task<string> PublishPackageCreated(string message)
        {


            using var channel = await _rabbitConnection.CreateChannelAsync();

            var mgJ = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(mgJ);
            await channel.ExchangeDeclareAsync(exchange: "package_events", type: ExchangeType.Topic,
            durable: false);
            await channel.BasicPublishAsync(exchange: "package_events", routingKey: "package.created", body: body);
            return "enviado";
        }
    }
}
