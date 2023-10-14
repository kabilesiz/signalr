using Microsoft.AspNetCore.SignalR;
using SignalR.ClientHubs;
using SignalR.Collections;

namespace SignalR.Hubs;

public class ChatHub : Hub<IMessageHub>
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }
    public override async Task OnConnectedAsync()
    {
        var clientId = Context.GetHttpContext()?.Request.Headers["client_id"].ToString();
        if (!string.IsNullOrWhiteSpace(clientId) && !Participants.ParticipantsCollection.ContainsKey(clientId))
        {
            Participants.ParticipantsCollection.Add(clientId, Context.ConnectionId);
        }
        _logger.LogInformation($"{Context.ConnectionId} is connected");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var clientId = Context.GetHttpContext()?.Request.Headers["client_id"].ToString();
        if (!string.IsNullOrWhiteSpace(clientId) && Participants.ParticipantsCollection.ContainsKey(clientId))
        {
            Participants.ParticipantsCollection.Remove(clientId);
        }
        _logger.LogInformation($"{Context.ConnectionId} is disconnected");
    }

    // public async Task JoinGroup(string groupName)
    // {
    //     await this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
    //     await this.Clients.Group(groupName).SendAsync("Send", $"{this.Context.ConnectionId} joined {groupName}");
    // }
}