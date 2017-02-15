using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace Mimo.Frontend
{
    public class ClaimsIdentity : IIdentity
    {
        public ClaimsIdentity(string name, IEnumerable<Claim> claims)
        {
            Name = name;
            Claims = claims;
        }

        public string Name { get; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public IEnumerable<Claim> Claims { get; }
        string IIdentity.AuthenticationType => AuthenticationType;
        bool IIdentity.IsAuthenticated => IsAuthenticated;
    }
}