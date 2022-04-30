using System.Security.Claims;

namespace Admin.Common.Auth
{
    public interface IUserToken
    {
        string Create(Claim[] claims);

        Claim[] Decode(string token);
    }
}
