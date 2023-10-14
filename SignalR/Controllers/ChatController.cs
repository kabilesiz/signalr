using Microsoft.AspNetCore.Mvc;
using SignalR.Models;
using SignalR.SignalRBusiness;

namespace SignalR.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ChatBusiness _chatBusiness;

    public ChatController(ILogger<WeatherForecastController> logger, ChatBusiness chatBusiness)
    {
        _logger = logger;
        _chatBusiness = chatBusiness;
    }
    
    [HttpGet("hello")]
    public string GetHello()
    {
        return "Hello for Test";

    }

    [HttpPost("message")]
    public async Task<IActionResult> SendMessage(SendMessageModel model)
    {
        try
        {
            await _chatBusiness.SendMessage(model);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new {message = e.Message});
        }
        
    }
}