using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AGP.Mvc.Security
{
    public static class ExtensionMethod
    {
        public static int GetUserId(this ClaimsPrincipal claims)
        {
            var strUserId = claims.FindFirst(AGP.Mvc.Security.ClaimTypes.UserId).Value;
            return Convert.ToInt32(strUserId);
        }
    }
}
