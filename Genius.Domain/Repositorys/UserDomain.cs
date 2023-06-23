using Genius.Infraestructure;
using Genius.Infraestructure.Model;

namespace Genius.Domain;

public class UserDomain:IUserDomain
{
    private IUserInfraestructure _userInfraestructure;
    private IEncryptDomain _encryptDomain;
    private ITokenDomain _tokenDomain;

    public UserDomain(IUserInfraestructure userInfraestructure, IEncryptDomain encryptDomain, ITokenDomain tokenDomain)
    {
        _userInfraestructure = userInfraestructure;
        _encryptDomain = encryptDomain;
        _tokenDomain = tokenDomain;
    }

    public async Task<string> Login(User user)
    {
        var foundUser = await _userInfraestructure.GetByUsername(user.Username);
            
        if (_encryptDomain.Ecnrypt(user.Password) == foundUser.Password)
        {
            return _tokenDomain.GenerateJwt(foundUser.Username);
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<int> Signup(User user)
    {
        user.Password = _encryptDomain.Ecnrypt(user.Password);
        return await _userInfraestructure.Signup(user);
    }

    public async Task<User> GetByUsername(string username)
    {
        return  await _userInfraestructure.GetByUsername(username);
    }
}