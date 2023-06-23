using Genius.Infraestructure.Model;

namespace Genius.Domain;

public interface IUserDomain
{
    Task<string> Login (User user);
    Task<int> Signup(User user);
    Task<User> GetByUsername(string username);
}