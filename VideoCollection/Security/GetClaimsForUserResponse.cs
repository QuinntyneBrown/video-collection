using System.Collections.Generic;
using System.Security.Claims;

namespace VideoCollection.Security
{
    public class GetClaimsForUserResponse
    {
        public ICollection<Claim> Claims { get; set; }
    }
}
