using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Infrastructure.Messaging.RabbitMQ.Abstractions
{
    public interface ITrackingConsumer
    {
        Task StartConsuming(CancellationToken ct);
    }
}
