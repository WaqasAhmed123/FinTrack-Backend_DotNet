using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetEmail(this ClaimsPrincipal user){
            // return user.Claims.SingleOrDefault(x => x.Type.Equals("https://schemas.")).Value
            // https://schemas.xmlsoap.org/ws/2009/09/identity/claims/givenname
            return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }
        
    }
}