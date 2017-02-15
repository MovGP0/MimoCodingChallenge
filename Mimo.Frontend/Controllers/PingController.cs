using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mimo.Frontend.Controllers
{
    [Authorize]
    [Route("ping")]
    public class PingController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }

        [AllowAnonymous]
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return $"Hello {name}";
        }
    }
}
