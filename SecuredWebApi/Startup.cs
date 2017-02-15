using System.Web.Http;
using Microsoft.Owin.Security.Jwt;
using Owin;

namespace SecuredWebApi
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string key = "ZzXLrqfHwpYY0snL2+0FagmGX+4FrnwO5CrP51YCFxc="; 
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = new[] { "http://localhost:5000/api" },
                IssuerSecurityTokenProviders = new[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider("http://mimo.com", key)
                }
            });
            
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("ping", "api/ping", new { controller = "Ping" });
            app.UseWebApi(config);
        }
    }
}