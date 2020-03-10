using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace CarWorkshops.Infrastructure
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles)
        {
            if (roles?.Any() != true) { throw new ArgumentNullException(nameof(roles)); }

            Roles = string.Join(',', roles);
        }
    }
}
