using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Model;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Signingkey"]));
        }

        public string createToken(User user)
        {
            var claims = new List<Claim>
            {
new Claim(JwtRegisteredClaimNames.Email, user.Email),
new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };
            throw new NotImplementedException();
        }
    }
}