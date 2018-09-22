using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGP.Mvc.Security
{
    public class CookieValidateService
    {
        public async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            await handleUnauthorizedRequest(context);
        }
        private Task handleUnauthorizedRequest(CookieValidatePrincipalContext context)
        {
            context.RejectPrincipal();

            return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
