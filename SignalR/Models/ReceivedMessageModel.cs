namespace SignalR.Models;

public class ReceivedMessageModel
{
    public ReceivedMessageModel(string from, string message)
    {
        From = from;
        Message = message;
    }

    public string From { get; set; }
    public string Message { get; set; }
}