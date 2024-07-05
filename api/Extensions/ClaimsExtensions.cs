using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace api.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetEmail(this ClaimsPrincipal user){
            // return user.Claims.SingleOrDefault(x => x.Type.Equals("https://schemas.")).Value
            // https://schemas.xmlsoap.org/ws/2009/09/identity/claims/givenname
            // string email = user.FindFirstValue(ClaimTypes.Email);
            
            var email = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            return email;

            // return  user.FindFirstValue(ClaimTypes.Email);
            // return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }
        
    }
}