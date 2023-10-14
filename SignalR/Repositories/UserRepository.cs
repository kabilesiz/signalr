using SignalR.Models;

namespace SignalR.Repositories;

public class UserRepository
{
    private List<User> Users { get; set; } = new();

    public List<User> GetUsers()
    {
        return Users;
    }

    public User? GetUserById(string id)
    {
        return Users.FirstOrDefault(x => string.Equals(x.Id, id));
    }
    
    public User? GetUserByName(string name)
    {
        return Users.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));
    }
    
    public User AddUser(User user)
    {
        Users.Add(user);
        return user;
    }
    
    public bool DeleteUser(string clientId)
    {
        var user = Users.FirstOrDefault(x => string.Equals(x.Id, clientId));
        if (user == null) return false;
        Users.Remove(user);
        return true;

    }
}