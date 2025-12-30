using LogiTrackLite.Shared.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LogiTrackLite.Shared;

public class RabbitMqPersistentConnection : IRabbitMqConnection
{
    private readonly IConnectionFactory _connectionFactory;
    private IConnection? _connection; // IConnection ahora es la interfaz base
    private bool _disposed;
    private readonly object _lock = new();

    public RabbitMqPersistentConnection(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    // En v7, IsOpen sigue existiendo pero se recomienda manejar estados asíncronos
    public bool IsConnected => _connection is { IsOpen: true } && !_disposed;

    // AHORA ES ASÍNCRONO: Retorna Task<IChannel> en lugar de IModel
    public async Task<IChannel> CreateChannelAsync()
    {
        if (!IsConnected)
        {
            await TryConnectAsync();
        }

        if (_connection == null) throw new InvalidOperationException("No hay conexión a RabbitMQ");

        return await _connection.CreateChannelAsync();
    }

    public async Task<bool> TryConnectAsync()
    {
        if (IsConnected) return true;

        // Nota: En v7 se prefiere CreateConnectionAsync
        _connection = await _connectionFactory.CreateConnectionAsync();

        if (IsConnected)
        {
            // Los eventos ahora pueden tener sufijo Async según la configuración
            _connection.ConnectionShutdownAsync += OnConnectionShutdown;
            return true;
        }

        return false;
    }

    private Task OnConnectionShutdown(object sender, ShutdownEventArgs reason)
    {
        // Lógica de reconexión asíncrona
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _connection?.Dispose();
    }

}