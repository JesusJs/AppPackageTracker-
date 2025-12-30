using RabbitMQ.Client;

namespace LogiTrackLite.Shared.Interfaces
{
    public interface IRabbitMqConnection: IDisposable
    {
        bool IsConnected { get; }
        Task<bool> TryConnectAsync();
        Task<IChannel> CreateChannelAsync();
    }
}
