using Microsoft.AspNetCore.Identity;

namespace TodoApp.Api.Repository
{
    public interface ITokenRepository
    {
        string GetToken(IdentityUser user);
        Guid GetUserId(string token);
    }
}
