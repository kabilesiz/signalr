using Microsoft.AspNetCore.SignalR;
using SignalR.ClientHubs;
using SignalR.Collections;
using SignalR.Hubs;
using SignalR.Models;

namespace SignalR.SignalRBusiness;

public class ChatBusiness
{
    private readonly IHubContext<ChatHub, IMessageHub> _hubContext;

    public ChatBusiness(IHubContext<ChatHub, IMessageHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessage(SendMessageModel model)
    {
        if (!Participants.ParticipantsCollection.TryGetValue(model.From, out var fromSessionId))
        {
            throw new Exception("You have to invoke the system before messaging");
        }

        if (!Participants.ParticipantsCollection.TryGetValue(model.To, out var toSessionId))
        {
            var responseModel = new ReceivedMessageModel("Server",
                "The user who you want to message is not active right now !");
            await _hubContext.Clients.Client(fromSessionId).ReceivedMessage(responseModel.Message,
                CancellationToken.None);
        }
        else
        {
            var responseModel = new ReceivedMessageModel($"Client {model.From}",
                model.Message);
            await _hubContext.Clients.Client(toSessionId).ReceivedMessage(responseModel.Message, CancellationToken.None);
        }
    }
}