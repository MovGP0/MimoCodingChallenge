using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Mimo.Frontend.Controllers
{
    [Authorize]
    [Route("login")]
    public class LoginController : Controller
    {
        private const string Issuer = "https://mimo.com";
        
        [AllowAnonymous]
        [HttpGet("{username}")]
        public async Task Get(string username, CancellationToken cancellationToken)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username, ClaimValueTypes.String, Issuer)
            };

            IIdentity identity = new ClaimsIdentity("Account", claims)
            {
                AuthenticationType = "auto", 
                IsAuthenticated = true
            };

            var userPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                IsPersistent = false,
                AllowRefresh = false
            });
        }
    }
}