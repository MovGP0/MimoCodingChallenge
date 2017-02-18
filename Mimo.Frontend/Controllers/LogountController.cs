using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mimo.Frontend.Controllers
{
    [Authorize]
    [Route("logout")]
    public class LogountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task Get()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");
        }
    }
}