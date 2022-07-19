using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServicesOrange.Model.User
{
    public class AuthenticatedUser
    {

        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Id => GetClaimsIdentity().FirstOrDefault(e => e.Type == ClaimTypes.Sid)?.Value;
        public string User => GetClaimsIdentity().FirstOrDefault(e => e.Type == ClaimTypes.UserData)?.Value;
        public string Nome => _accessor.HttpContext.User.Identity.Name;
        public string Email => GetClaimsIdentity().FirstOrDefault(e => e.Type == ClaimTypes.Email)?.Value;
        public string Type => GetClaimsIdentity().FirstOrDefault(e => e.Type == ClaimTypes.AuthorizationDecision)?.Value;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
