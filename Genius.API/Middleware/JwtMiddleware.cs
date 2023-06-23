using Genius.Domain;

namespace Genius.API.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    
    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Autenticación
    /// </summary>
    /// <param name="context"></param>
    /// <param name="tokenDomain"></param>
    /// <param name="userDomain"></param>
    public async Task Invoke(HttpContext context, ITokenDomain tokenDomain, IUserDomain userDomain)
    {

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var username = tokenDomain.ValidateJwt(token);

        if (username != null)
        {
            context.Items["User"] = await userDomain.GetByUsername(username);
        }
        
        await _next(context);
    }
}