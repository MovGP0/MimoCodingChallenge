using System.Net.Http;
using System.Web.Http;

namespace SecuredWebApi
{
    public class PingController : ApiController
    {
        [Authorize]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse("Hello World!");
        }
    }
}