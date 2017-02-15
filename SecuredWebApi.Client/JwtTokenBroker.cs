using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace SecuredWebApi.Client
{
    public static class JwtTokenBroker
    {
        // creating the token manually is just for demonstration 
        public static string GetJwtFromTokenIssuer()
        {
            var key = Convert.FromBase64String("ZzXLrqfHwpYY0snL2+0FagmGX+4FrnwO5CrP51YCFxc=");
            var symmetricKey = new InMemorySymmetricSecurityKey(key);

            var descriptor = new SecurityTokenDescriptor
            {
                TokenIssuerName = "http://mimo.com",
                AppliesToAddress = "http://localhost:5000/api",
                Lifetime = new Lifetime(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(1)),
                SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "johny"),
                })
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}