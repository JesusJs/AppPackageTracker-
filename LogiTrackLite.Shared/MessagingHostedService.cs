
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tracking.Infrastructure.Messaging.RabbitMQ.Abstractions;
namespace LogiTrackLite.Shared
{
    public class MessagingHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public MessagingHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // 1. Creamos un scope para poder resolver los consumidores
            using var scope = _serviceProvider.CreateScope();

            // 2. Obtenemos los consumidores de los módulos
            // Agrega aquí cada consumidor nuevo que crees
            var trackingConsumer = scope.ServiceProvider.GetService<ITrackingConsumer>();

            // 3. Los encendemos
            if (trackingConsumer != null)
            {
                // No usamos await aquí para que no bloquee el arranque de la app
                _ = trackingConsumer.StartConsuming(stoppingToken);
            }

            // Mantener el servicio vivo mientras la app corra
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
