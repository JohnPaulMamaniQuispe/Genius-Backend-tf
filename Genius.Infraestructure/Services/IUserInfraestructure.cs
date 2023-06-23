using Genius.Infraestructure.Model;

namespace Genius.Infraestructure;

public interface IUserInfraestructure
{
    Task<User> GetByUsername(string username);
    Task<int> Signup(User user);
}