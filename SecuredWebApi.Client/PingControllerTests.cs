using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssert;
using Xunit;

namespace SecuredWebApi.Client
{
    public class PingControllerTests
    {
        [Fact]
        public void ShouldReturnHelloWorld()
        {
            var jwt = JwtTokenBroker.GetJwtFromTokenIssuer();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

            var result = client.GetStringAsync("http://localhost:5000/api/ping/123").Result;

            result.ShouldBeEqualTo("\"Hello World!\"");
        }
    }
}
