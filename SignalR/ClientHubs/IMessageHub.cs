using SignalR.Models;

namespace SignalR.ClientHubs;

public interface IMessageHub
{
    Task ReceivedMessage(string message, CancellationToken cancellationToken);
}