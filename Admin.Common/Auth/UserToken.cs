using Admin.Common.Configs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;

namespace Admin.Common.Auth
{
    public class UserToken : IUserToken
    {
        private readonly JwtConfig _jwtConfig;
        public UserToken(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public string Create(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecurityKey));
            var signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var timestamp = DateTime.Now.AddMinutes(_jwtConfig.Expires+_jwtConfig.RefreshExpires);
            //claims = claims.Append(new Claim(ClaimAttributes.refreshExpires,));
            return "";
        }

        public Claim[] Decode(string token)
        {
            throw new NotImplementedException();
        }
    }
}
