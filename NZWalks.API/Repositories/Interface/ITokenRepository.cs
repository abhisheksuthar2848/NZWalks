using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        public string CreateJWTToken(IdentityUser user,List<string> roles);
    }
}
