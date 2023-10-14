using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs;

public class ChatHub : Hub
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }

    public async Task TestMe(string someRandomText)
    {
        await Clients.All.SendAsync(
            $"{Context.ConnectionId} : {someRandomText}",
            CancellationToken.None);
    }
    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation($"{Context.ConnectionId} is connected");
    }
    
    public async Task JoinGroup(string groupName)
    {
        await this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        await this.Clients.Group(groupName).SendAsync("Send", $"{this.Context.ConnectionId} joined {groupName}");
    }
}