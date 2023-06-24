using Genius.Infraestructure.Context;
using Genius.Infraestructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Genius.Infraestructure;

public class UserInfraestructure : IUserInfraestructure
{

    private GeniusDBContext _geniusDbContext;

    public async Task<List<User>> GetAll()
    {
        return await _geniusDbContext.Users.Where(user=> user.IsActive).ToListAsync();
    }
    
    public UserInfraestructure(GeniusDBContext geniusDbContext)
    {
        _geniusDbContext = geniusDbContext;
    }
    public async Task<User> GetByUsername(string username)
    {
        return await _geniusDbContext.Users.SingleAsync(u=> u.Username == username);
    }
    public async Task<int> Signup(User user)
    {
        user.DateCreated = DateTime.Now;
        _geniusDbContext.Users.Add(user);
        await _geniusDbContext.SaveChangesAsync();
        return user.Id;
    }
}