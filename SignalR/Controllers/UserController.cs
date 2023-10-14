using Microsoft.AspNetCore.Mvc;
using SignalR.Models;
using SignalR.Repositories;

namespace SignalR.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private UserRepository _userRepository;

    public UserController()
    {
        _userRepository = new UserRepository();
        _userRepository.AddUser(new User("1", "Huseyin"));
        _userRepository.AddUser(new User("2", "Batur"));
        _userRepository.AddUser(new User("3", "Furkan"));
        _userRepository.AddUser(new User("4", "Gokmen"));
    }

    [HttpGet("users")]
    public List<User> GetUsers()
    {
       return _userRepository.GetUsers();
    }
    
    [HttpGet("user/{id}")]
    public User? GeTUserById(string id)
    {
        return _userRepository.GetUserById(id);
    }
    
    [HttpGet("user")]
    public User? GeTUserByName(string name)
    {
        return _userRepository.GetUserByName(name);
    }
    
    [HttpPost("user")]
    public User AddUser([FromBody] User user)
    {
        return _userRepository.AddUser(user);
    }
    
    [HttpDelete("user")]
    public bool DeleteUserById(string id)
    {
        return _userRepository.DeleteUser(id);
    }
}